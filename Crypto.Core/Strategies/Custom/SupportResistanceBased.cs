﻿using Crypto.Core.Indicators;
using Crypto.Core.Strategies.Arbitrages.Statistical;
using CryptoMarketClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using CryptoMarketClient.Common;
using System.Xml.Serialization;
using Crypto.Core.Helpers;

namespace Crypto.Core.Strategies.Custom {
    public class SupportResistanceBasedStrategy : CustomTickerStrategy {
        public override string TypeName => "SR Based";

        protected override void OnTickCore() {
            ProcessTicker(Ticker);
        }

        public override bool SupportSimulation => true;

        public override List<StrategyValidationError> Validate() {
            List<StrategyValidationError> res = base.Validate();
            if(StrategyInfo.Tickers.Count != 1) {
                res.Add(new StrategyValidationError() { DataObject = this, PropertyName = "Tickers", Description = "Right now only one ticker is suported per strategy", Value = StrategyInfo.Tickers.Count.ToString() });
            }
            return res;
        }
        
        [InputParameter]
        public double MinBreakPercent { get; set; } = 120;
        [InputParameter]
        public int MinSupportPower { get; set; } = 5;
        [InputParameter]
        public int MinSupportLength { get; set; } = 8;
        [InputParameter]
        public double MinAtrValue { get; set; } = 30;
        protected SupportResistanceIndicator SRIndicator { get; private set; }
        protected AtrIndicator AtrIndicator { get; private set; }

        protected int LastCount { get; set; } = -1;
        protected RedWaterfallDataItem LastBreak { get; set; }
        protected List<RedWaterfallDataItem> Breaks { get; } = new List<RedWaterfallDataItem>();
        protected virtual void ProcessTicker(Ticker ticker) {
            if(SRIndicator.Result.Count > 2 && LastCount != SRIndicator.Result.Count) {
                LastCount = SRIndicator.Result.Count;
                int index = LastCount - 2; // save finished candlestick
                AddStrategyData();
            }
            ProcessTickerCore();
        }

        protected int SimulationStartItemsCount { get { return 100; } }
        protected virtual void ProcessTickerCore() {
            RedWaterfallDataItem item = StrategyData.Count > 0 ? (RedWaterfallDataItem)StrategyData.Last() : null;
            if(Ticker.CandleStickData.Count < SimulationStartItemsCount) /// need back data for simulation
                return;
            SRValue lastResistance = GetLastResistance();
            SRValue lastSupport = GetLastSupport();
            if(lastSupport != null & lastResistance != null) {
                item.SRSpread = lastResistance.Value - lastSupport.Value;
                item.ResIndex = lastResistance.Index;
                item.SupIndex = lastSupport.Index;
                double breakDelta = item.Close - lastSupport.Value;
                double range = lastResistance.Value - lastSupport.Value;
                item.BreakPercent = (-breakDelta) / range * 100;
                item.BreakPercent2 = (item.BreakPercent - ((RedWaterfallDataItem)StrategyData[StrategyData.Count - 2]).BreakPercent);
                if(Math.Abs(lastSupport.Value - lastResistance.Value) / lastSupport.Value < 0.003) {
                    item.BreakPercent = 0;
                    item.BreakPercent2 = 0;
                }
                if(item.BreakPercent > MinBreakPercent && item.Atr >= MinAtrValue && breakDelta < 0) {
                    if(LastBreak == null || LastBreak.ResIndex != item.ResIndex || LastBreak.SupIndex != item.SupIndex) {
                        item.Break = true;
                        item.BreakResistanceLevel = lastResistance.Value;
                        item.BreakSupportLevel = lastSupport.Value;
                        item.BreakSupportPower = lastSupport.Power;
                        LastBreak = item;
                        Breaks.Add(item);
                    }
                }
            }
            //foreach(RedWaterfallDataItem bItem in Breaks) {
            //    if((item.Close - bItem.Close) >= (bItem.BreakSupportLevel - bItem.Close) * 0.8) {
            //        bItem.CloseLength = item.Index - bItem.Index;
            //        bItem.Closed = true;
            //    }
            //}

            //if(IsRedWaterfallDetected(ticker)) {

            //}
        }

        private SRValue GetSupportBeforeResistance(SRValue lastResistance) {
            for(int i = SRIndicator.Support.Count - 1; i >= 0; i--) {
                SRValue val = SRIndicator.Support[i];
                if(val.Index <= lastResistance.Index)
                    return val;
            }
            return null;
        }

        private SRValue GetLastResistance() {
            return SRIndicator.Resistance.Count > 0 ? SRIndicator.Resistance.Last() : null;
        }

        private SRValue GetLastSupport() {
            return SRIndicator.Support.Count > 0 ? SRIndicator.Support.Last() : null;
        }

        protected override void InitializeDataItems() {
            DataItem("Index").Visibility = DataVisibility.Table;
            TimeItem("Time");
            CandleStickItem();

            //StrategyDataItemInfo res = DataItem("ResistanceLength"); res.Color = System.Drawing.Color.Red; res.ChartType = ChartType.Bar; res.PanelIndex = 1;
            //StrategyDataItemInfo sup = DataItem("SupportLength"); sup.Color = System.Drawing.Color.Green; sup.ChartType = ChartType.Bar; sup.PanelIndex = 1;
            
            //StrategyDataItemInfo atr = DataItem("Atr"); atr.Name = "Atr Indicator"; atr.Color = System.Drawing.Color.Red; atr.ChartType = ChartType.Line; atr.PanelIndex = 1;
            StrategyDataItemInfo resValue = DataItem("Value"); resValue.BindingSource = "SRIndicator.Resistance"; resValue.Color = Color.FromArgb(0x40, Color.Red); resValue.ChartType = ChartType.StepLine;
            StrategyDataItemInfo supValue = DataItem("Value"); supValue.BindingSource = "SRIndicator.Support"; supValue.Color = Color.FromArgb(0x40, Color.Blue); supValue.ChartType = ChartType.StepLine;

            //AnnotationItem("Support", "Support", System.Drawing.Color.Green, "SRLevel");
            //AnnotationItem("Resistance", "Resistance", System.Drawing.Color.Red, "SRLevel");
            StrategyDataItemInfo br = AnnotationItem("Break", "Break", System.Drawing.Color.Blue, "Value"); br.Visibility = DataVisibility.Both; br.AnnotationText = "Br"; //"Br={BreakPercent:0.00} Closed={Closed} CloseStickCount={CloseLength}";
            //StrategyDataItemInfo bp = DataItem("BreakPercent"); bp.Color = Color.Green; bp.ChartType = ChartType.Bar; bp.PanelIndex = 2;

            StrategyDataItemInfo cl = AnnotationItem("ClosedOrder", "Closed", System.Drawing.Color.Green, "Value"); cl.Visibility = DataVisibility.Both; cl.AnnotationText = "Cl"; //"Br={BreakPercent:0.00} Closed={Closed} CloseStickCount={CloseLength}";


            //StrategyDataItemInfo sc = DataItem("SupportChange", Color.FromArgb(0x40, Color.Green), 1); sc.PanelIndex = 4; sc.ChartType = ChartType.Area;
            //StrategyDataItemInfo rc = DataItem("ResistanceChange", Color.FromArgb(0x40, Color.Red), 1); rc.PanelIndex = 4; rc.ChartType = ChartType.Area;
            //StrategyDataItemInfo bp2 = DataItem("BreakPercent2"); bp2.Color = Color.FromArgb(0x20, Color.Green);  bp2.ChartType = ChartType.Area; bp2.PanelIndex = 5;

            DataItem("Closed").Visibility = DataVisibility.Table;
            DataItem("CloseLength").Visibility = DataVisibility.Table;

            //br = AnnotationItem("Break", "Break", System.Drawing.Color.Blue, "Atr"); br.PanelIndex = 1; br.Visibility = DataVisibility.Chart; br.AnnotationText = "Br"; //"Br={BreakPercent:0.00} Closed={Closed} CloseStickCount={CloseLength}";

            //StrategyDataItemInfo sp = DataItem("SRSpread"); sp.Color = Color.FromArgb(0x20, Color.Green); sp.ChartType = ChartType.Area; sp.PanelIndex = 3;
            DataItem("Profit", Color.Green).Visibility = DataVisibility.Table;
            var ear = DataItem("Earned", Color.Green);
            ear.PanelIndex = 1;
        }

        protected List<RedWaterfallDataItem> PostProcessItems { get; } = new List<RedWaterfallDataItem>();
        protected virtual RedWaterfallDataItem AddStrategyData() {
            if(Ticker.CandleStickData.Count < SimulationStartItemsCount) /// need back data for simulation
                return null;
            RedWaterfallDataItem item = new RedWaterfallDataItem();
            item.Earned = Earned;
            item.Candle = Ticker.CandleStickData[Ticker.CandleStickData.Count - 2];
            item.Atr = AtrIndicator.Result[AtrIndicator.Result.Count - 2].Value;
            if(double.IsNaN(item.Atr))
                throw new Exception();
            item.Index = StrategyData.Count;
            StrategyData.Add(item);

            PostProcessItems.Add(item);
            if(PostProcessItems.Count > 10)
                PostProcessItems.RemoveAt(0);
            SRValue sr = (SRValue)SRIndicator.Result.Last();
            if(sr.Type == SupResType.None)
                return null;
            RedWaterfallDataItem srItem = PostProcessItems.FirstOrDefault(i => i.Time == sr.Time);
            if(srItem != null)
                srItem.SRValue = sr;
            return srItem;
        }

        private bool IsRedWaterfallDetected(Ticker ticker) {
            if(ticker.CandleStickData.Count < 100)
                return false;
            int index = ticker.CandleStickData.Count - 1;
            CandleStickData l3 = ticker.CandleStickData[index];

            CandleStickData l2 = ticker.CandleStickData[index - 1];
            CandleStickData l1 = ticker.CandleStickData[index - 2];
            CandleStickData l0 = ticker.CandleStickData[index - 3];

            //if(l3.Close < l3.Open && l3.Open <= l2.Close && l2.Close < l2.Open && l2.Open <= l1.Close && l1.Close < l1.Open) {
            //    StrategyData.Add(new RedWaterfallDataItem() { Time = l3.Time, StartPrice = l0.High, EndPrice = l3.Close, RedWaterfall = true });
            //    return true;
            //}
            return false;
        }

        public override void Assign(StrategyBase from) {
            base.Assign(from);
            SupportResistanceBasedStrategy st = from as SupportResistanceBasedStrategy;
            if(st == null)
                return;
            Range = st.Range;
            ClasterizationRange = st.ClasterizationRange;
            ThresoldPerc = st.ThresoldPerc;
            MinAtrValue = st.MinAtrValue;
            MinBreakPercent = st.MinBreakPercent;
            MinSupportLength = st.MinSupportLength;
            MinSupportPower = st.MinSupportPower;

        }

        public int Range { get; set; } = 3;
        public int ClasterizationRange { get; set; } = 24;
        public double ThresoldPerc { get; set; } = 0.6;

        public override bool Start() {
            bool res = base.Start();
            if(!res)
                return res;
            SRIndicator = new SupportResistanceIndicator() { Ticker = Ticker, Range = Range, ClasterizationRange = ClasterizationRange, ThresoldPerc = ThresoldPerc };
            AtrIndicator = new AtrIndicator() { Ticker = Ticker };
            return res;
        }
    }

    public class RedWaterfallDataItem {
        public DateTime Time { get { return Candle.Time; } }
        public double Open { get { return Candle.Open; } }
        public double Close { get { return Candle.Close; } }
        public double High { get { return Candle.High; } }
        public double Low { get { return Candle.Low; } }
        public CandleStickData Candle { get; set; }
        public bool RedWaterfall { get; set; }
        public double StartPrice { get; set; }
        public double Spread { get { return StartPrice - EndPrice; } }
        public double EndPrice { get; set; }
        public SRValue SRValue { get; set; }
        public double Atr { get; set; }
        public int Index { get; set; }
        public bool Resistance { get { return SRValue == null ? false : SRValue.Type == SupResType.Resistance; } }
        public bool Support { get { return SRValue == null ? false : SRValue.Type == SupResType.Support; } }

        public double ResistancePower { get { return SRValue == null || SRValue.Type != SupResType.Resistance ? 0 : SRValue.Power; } }
        public double SupportPower { get { return SRValue == null || SRValue.Type != SupResType.Support ? 0 : SRValue.Power; } }

        public double ResistanceChange { get { return SRValue == null || SRValue.Type != SupResType.Resistance ? 0 : SRValue.ChangePc; } }
        public double SupportChange { get { return SRValue == null || SRValue.Type != SupResType.Support ? 0 : SRValue.ChangePc; } }

        public double ResistanceLength { get { return SRValue == null || SRValue.Type != SupResType.Resistance ? 0 : SRValue.Length; } }
        public double SupportLength { get { return SRValue == null || SRValue.Type != SupResType.Support ? 0 : SRValue.Length; } }

        public double BreakResistanceLevel { get; set; }
        public double BreakSupportLevel { get; set; }
        public double BreakSupportPower { get; set; }
        public double BreakPercent { get; set; }
        public double BreakPercent2 { get; set; }

        public double SRLevel { get { return SRValue == null ? 0 : SRValue.Value; } }
        public bool Break { get; set; }
        public double Value { get; set; }
        public bool BreakUp { get; set; }
        public int ResIndex { get; set; }
        public int SupIndex { get; set; }

        public int CloseLength { get; set; }
        public bool Closed { get; set; }
        public bool ClosedOrder { get; set; }
        public double Profit { get; set; }
        public double SRSpread { get; internal set; }
        public object BreakValue { get; internal set; }
        public double Earned { get; set; }
        public string Mark { get; set; }
        public double PercentChangeFromSupport { get; set; }
    }

    public class OpenPositionInfo {
        public DateTime Time { get; set; }
        public DateTime CloseTime { get; set; }
        public TimeSpan Length { get { return CloseTime - Time; } }

        public bool AllowHistory { get; set; } = false;
        public TimeSpan AggregationTime { get; set; } = new TimeSpan(0, 0, 30); 

        public OrderType Type { get; set; }
        public bool AllowTrailing { get; set; }
        public string MarketName { get; set; }
        public double StopLossPercent { get; set; } = 5;
        public double OpenValue { get; set; }
        public double CloseValue { get; set; }
        public double Change { get { return (CloseValue - OpenValue) / OpenValue * 100; } }
        double currentValue;
        public void UpdateCurrentValue(DateTime time, double value) {
            if(CurrentValue == value)
                return;
            currentValue = value;
            UpdateStopLoss();
            OnCurrentValueChanged(time, value);
        }
        public double CurrentValue {
            get { return currentValue; }
            //set {
            //    if(CurrentValue == value)
            //        return;
            //    currentValue = value;
            //    UpdateStopLoss();
            //    OnCurrentValueChanged();
            //}
        }

        public void OnCurrentValueChanged(DateTime time, double value) {
            if(!AllowHistory)
                return;
            DateTime lastValueTime = DateTime.MinValue;
            if(ValueHistory.Count > 0)
                lastValueTime = ValueHistory.Last().Time;
            if(time - lastValueTime > AggregationTime)
                ValueHistory.Add(new TimeBaseValue() { Time = time, Value = value });
            DateTime stopLossTime = DateTime.MinValue;
            if(StopLossHistory.Count > 0)
                stopLossTime = StopLossHistory.Last().Time;
            if(time - stopLossTime > AggregationTime)
                StopLossHistory.Add(new TimeBaseValue() { Time = time, Value = StopLoss });
        }

        public ResizeableArray<TimeBaseValue> ValueHistory { get; } = new ResizeableArray<TimeBaseValue>();
        public ResizeableArray<TimeBaseValue> StopLossHistory { get; } = new ResizeableArray<TimeBaseValue>();

        protected double[] PreviewFromHistory(ResizeableArray<TimeBaseValue> history) {
            if(history.Count == 0)
                return new double[0];
            int count = Math.Min(50, history.Count);
            int delta = Math.Max(1, history.Count / count);
            double[] data = new double[count];
            for(int i = 0, j = 0; i < count && j < history.Count; i++, j += delta) {
                data[i] = history[j].Value;
            }
            return data;
        }

        double[] valuePreview;
        public double[] ValuePreview {
            get {
                if(valuePreview == null)
                    valuePreview = PreviewFromHistory(ValueHistory);
                return valuePreview;
            }
        }

        double[] stopLossPreview;
        public double[] StopLossPreview {
            get {
                if(stopLossPreview == null)
                    stopLossPreview = PreviewFromHistory(StopLossHistory);
                return stopLossPreview;
            }
        }

        public double Earned { get; set; }
        public double Spent { get; set; }
        public double Profit { get { return Earned - Spent; } }
        public double StopLoss { get; set; }
        public double Amount { get; set; }
        public double Total { get; set; }
        [XmlIgnore]
        public object Tag { get; set; }
        [XmlIgnore]
        public object Tag2 { get; set; }
        public string Mark { get; set; }

        public void UpdateStopLoss() {
            double newStopLoss = CurrentValue * (100 - StopLossPercent) * 0.01;
            StopLoss = Math.Max(newStopLoss, StopLoss);
        }
    }

    public class OpenPositionVisualDataProvider : IStrategyDataItemInfoOwner {
        public OpenPositionVisualDataProvider(ResizeableArray<OpenPositionInfo> items) {
            Items = items;
            InitializeDataItemInfos();
        }

        protected virtual void InitializeDataItemInfos() {
            StrategyDataItemInfo.TimeItem(DataItemInfos, "Time").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.TimeItem(DataItemInfos, "CloseTime").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.TimeSpanItem(DataItemInfos, "Length").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.TimeItem(DataItemInfos, "Mark").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.EnumItem(DataItemInfos, "Type").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "OpenValue").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "CloseValue").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "Change").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "StopLoss").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "Spent").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "Earned").Visibility = DataVisibility.Table;
            StrategyDataItemInfo.DataItem(DataItemInfos, "Profit").Visibility = DataVisibility.Table;

            var vp = StrategyDataItemInfo.DataItem(DataItemInfos, "ValuePreview"); vp.Visibility = DataVisibility.Table;
            var sp = StrategyDataItemInfo.DataItem(DataItemInfos, "StopLossPreview"); sp.Visibility = DataVisibility.Table;

            var vh = StrategyDataItemInfo.DataItem(DataItemInfos, "Value"); vh.Visibility = DataVisibility.Chart; vh.Type = DataType.ChartData; vh.Color = Color.Green; vh.BindingSource = "ValueHistory";
            var sh = StrategyDataItemInfo.DataItem(DataItemInfos, "Value"); sh.Visibility = DataVisibility.Chart; sh.Type = DataType.ChartData; sh.Color = Color.Red; sh.BindingSource = "StopLossHistory";

            vp.DetailInfo = vh;
            sp.DetailInfo = sh;
        }

        public List<StrategyDataItemInfo> DataItemInfos { get; } = new List<StrategyDataItemInfo>();

        public ResizeableArray<OpenPositionInfo> Items { get; private set; }

        string IStrategyDataItemInfoOwner.Name => "Opened Positions";

        List<StrategyDataItemInfo> IStrategyDataItemInfoOwner.DataItemInfos => DataItemInfos;

        ResizeableArray<object> IStrategyDataItemInfoOwner.Items {
            get {
                ResizeableArray<object> res = new ResizeableArray<object>();
                for(int i = 0; i < Items.Count; i++) {
                    res.Add(Items[i]);
                }
                return res;
            }
        }
    }

    public class OpenPositionTrailingHistoryItem {
        public DateTime Time { get; set; }
        public double Current { get; set; }
        public double NextClose { get; set; }
        public double StopLoss { get; set; }
    }
}