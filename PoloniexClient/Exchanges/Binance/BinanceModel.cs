﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CryptoMarketClient.Common;
using CryptoMarketClient.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocket4Net;

namespace CryptoMarketClient.Binance {
    public class BinanceExchange : Exchange {
        static BinanceExchange defaultExchange;
        public static BinanceExchange Default {
            get {
                if(defaultExchange == null) {
                    defaultExchange = new BinanceExchange();
                    defaultExchange.Load();
                }
                return defaultExchange;
            }
        }

        public override void OnAccountRemoved(ExchangeAccountInfo info) {
            
        }

        public override string BaseWebSocketAddress => "wss://stream.binance.com:9443/ws/!ticker@arr";

        public override ExchangeType Type => ExchangeType.Binance;

        public override bool SupportWebSocket(WebSocketType type) {
            if(type == WebSocketType.Tickers)
                return true;
            return false;
        }

        string[] webSocketTickersInfo;
        protected string[] WebSocketTickersInfo {
            get {
                if(webSocketTickersInfo == null) {
                    webSocketTickersInfo = new string[] {
                        "e",
                        "E",
                        "s",
                        "p",
                        "P",
                        "w",
                        "x",
                        "c",
                        "Q",
                        "b",
                        "B",
                        "a",
                        "A",
                        "o",
                        "h",
                        "l",
                        "v",
                        "q",
                        "O",
                        "C",
                        "F",
                        "L",
                        "n"
                    };
                }
                return webSocketTickersInfo;
            }
        }
        protected override void OnTickersSocketMessageReceived(object sender, MessageReceivedEventArgs e) {
            base.OnTickersSocketMessageReceived(sender, e);
            byte[] data = Encoding.Default.GetBytes(e.Message);
            int startIndex = 0;
            List<string[]> items = JSonHelper.Default.DeserializeArrayOfObjects(data, ref startIndex, WebSocketTickersInfo);
            foreach(string[] item in items) {
                string eventType = item[0];
                if(eventType == "24hrTicker")
                    On24HourTickerRecv(item);
            }
        }

        protected void On24HourTickerRecv(string[] item) {
            string symbolName = item[2];
            BinanceTicker t = (BinanceTicker)Tickers.FirstOrDefault(tt => tt.Name == symbolName);
            if(t == null)
                throw new DllNotFoundException("binance symbol not found " + symbolName);
            t.Change = FastDoubleConverter.Convert(item[4]);
            t.HighestBid = FastDoubleConverter.Convert(item[9]);
            t.LowestAsk = FastDoubleConverter.Convert(item[11]);
            t.Hr24High = FastDoubleConverter.Convert(item[14]);
            t.Hr24Low = FastDoubleConverter.Convert(item[15]);
            t.BaseVolume = FastDoubleConverter.Convert(item[16]);
            t.Volume = FastDoubleConverter.Convert(item[17]);

            t.UpdateTrailings();

            lock(t) {
                RaiseTickerUpdate(t);
            }
        }

        public override bool GetDeposites() {
            return true;
        }

        public override Form CreateAccountForm() {
            return null;
        }
        
        public override void ObtainExchangeSettings() {
            string address = "https://api.binance.com/api/v1/exchangeInfo";
            string text = string.Empty;
            try {
                text = GetDownloadString(address);
            }
            catch(Exception) {
                return;
            }
            if(string.IsNullOrEmpty(text))
                return;

            JObject settings = JsonConvert.DeserializeObject<JObject>(text);
            JArray rateLimits = settings.Value<JArray>("rateLimits");
            RequestRate = new List<RateLimit>();
            OrderRate = new List<RateLimit>();
            foreach(JObject rateLimit in rateLimits) {
                string rateType = rateLimit.Value<string>("rateLimitType");
                if(rateType == "REQUESTS")
                    RequestRate.Add(GetRateLimit(rateLimit));
                if(rateType == "ORDERS")
                    OrderRate.Add(GetRateLimit(rateLimit));
            }

            JArray symbols = settings.Value<JArray>("symbols");
            foreach(JObject s in symbols) {
                BinanceTicker t = new BinanceTicker(this);
                t.CurrencyPair = s.Value<string>("symbol");
                t.MarketCurrency = s.Value<string>("baseAsset");
                t.BaseCurrency = s.Value<string>("quoteAsset");
                Tickers.Add(t);

                JArray filters = s.Value<JArray>("filters");
                foreach(JObject filter in filters) {
                    string filterType = filter.Value<string>("filterType");
                    if(filterType == "PRICE_FILTER")
                        t.PriceFilter = new TickerFilter() { MinValue = filter.Value<double>("minPrice"), MaxValue = filter.Value<double>("maxPrice"), TickSize = filter.Value<double>("tickSize") };
                    else if(filterType == "LOT_SIZE")
                        t.QuantityFilter = new TickerFilter() { MinValue = filter.Value<double>("minQty"), MaxValue = filter.Value<double>("maxQty"), TickSize = filter.Value<double>("stepSize") };
                }
            }
        }
        protected RateLimit GetRateLimit(JObject jObject) {
            if(jObject.Value<string>("interval") == "MINUTE")
                return new RateLimit() { Limit = jObject.Value<int>("limit") - 1, Interval = TimeSpan.TicksPerMinute };
            else if(jObject.Value<string>("interval") == "DAY")
                return new RateLimit() { Limit = jObject.Value<int>("limit") - 1, Interval = TimeSpan.TicksPerDay };
            else if(jObject.Value<string>("interval") == "SECOND")
                return new RateLimit() { Limit = jObject.Value<int>("limit") - 1, Interval = TimeSpan.TicksPerSecond };
            return new RateLimit(); 
        }

        public override bool AllowCandleStickIncrementalUpdate => false;

        public override bool CancelOrder(TickerBase ticker, OpenedOrderInfo info) {
            throw new NotImplementedException();
        }

        public override List<CandleStickIntervalInfo> GetAllowedCandleStickIntervals() {
            throw new NotImplementedException();
        }

        public override bool GetTickersInfo() {
            bool result = UpdateTickersInfo();
            IsInitialized = true;
            return result;
        }

        public override List<TradeHistoryItem> GetTrades(TickerBase ticker, DateTime starTime) {
            throw new NotImplementedException();
        }

        public override bool ProcessOrderBook(TickerBase tickerBase, string text) {
            throw new NotImplementedException();
        }

        public override bool UpdateBalances() {
            throw new NotImplementedException();
        }

        public override bool UpdateCurrencies() {
            throw new NotImplementedException();
        }

        public override bool UpdateMyTrades(TickerBase ticker) {
            throw new NotImplementedException();
        }

        public override bool UpdateOpenedOrders(TickerBase tickerBase) {
            throw new NotImplementedException();
        }

        public override bool UpdateOrderBook(TickerBase tickerBase) {
            throw new NotImplementedException();
        }

        public override bool UpdateTicker(TickerBase tickerBase) {
            throw new NotImplementedException();
        }

        public override bool UpdateTickersInfo() {
            string address = "https://api.binance.com/api/v1/ticker/24hr";
            string text = string.Empty;
            try {
                text = GetDownloadString(address);
            }
            catch(Exception) {
                return false;
            }
            if(string.IsNullOrEmpty(text))
                return false;
            JArray res = (JArray)JsonConvert.DeserializeObject(text);
            foreach(JObject item in res) {
                string currencyPair = item.Value<string>("symbol");
                BinanceTicker t = (BinanceTicker)Tickers.FirstOrDefault(tr => tr.CurrencyPair == currencyPair);
                if(t == null)
                    continue;
                t.Last = item.Value<double>("lastPrice");
                t.LowestAsk = item.Value<double>("askPrice");
                t.HighestBid = item.Value<double>("bidPrice");
                t.Change = item.Value<double>("priceChangePercent");
                t.BaseVolume = item.Value<double>("volume");
                t.Volume = item.Value<double>("quoteVolume");
                t.Hr24High = item.Value<double>("highPrice");
                t.Hr24Low = item.Value<double>("lowPrice");
            }
            return true;
        }

        public override bool UpdateTrades(TickerBase tickerBase) {
            throw new NotImplementedException();
        }
    }
}
