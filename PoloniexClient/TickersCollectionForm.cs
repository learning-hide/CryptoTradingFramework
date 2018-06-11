﻿using CryptoMarketClient.Common;
using CryptoMarketClient.Poloniex;
using DevExpress.Skins;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoMarketClient {
    public partial class TickersCollectionForm : XtraForm {
        public TickersCollectionForm(Exchange exchange) {
            InitializeComponent();
            Exchange = exchange;
            Text = Exchange.Name;
            this.gridView1.RowHeight = (int)(48 * DpiProvider.Default.DpiScaleFactor);
            this.colIsSelected.MaxWidth = this.gridView1.RowHeight;
            this.gcLogo.MaxWidth = this.gridView1.RowHeight + 10;
            this.gcLogo.MinWidth = this.gridView1.RowHeight + 10;
        }

        public Exchange Exchange { get; set; }

        System.Threading.Timer threadTimer;
        public System.Threading.Timer ThreadTimer {
            get {
                if(threadTimer == null) {
                    threadTimer = new System.Threading.Timer(OnThreadUpdate);
                    threadTimer.Change(0, 9000);
                }
                return threadTimer;
            }
        }

        System.Windows.Forms.Timer connectionCheckTimer;
        public System.Windows.Forms.Timer ConnectionCheckTimer {
            get {
                if(connectionCheckTimer == null) {
                    connectionCheckTimer = new System.Windows.Forms.Timer();
                    connectionCheckTimer.Interval = 3000;
                    connectionCheckTimer.Tick += OnConnectionTimerTick;
                }
                return connectionCheckTimer;
            }
        }

        private void OnConnectionTimerTick(object sender, EventArgs e) {
            if((DateTime.Now - Exchange.LastWebSocketRecvTime).TotalSeconds > 5) {
                this.biConnectionStatus.ImageOptions.SvgImage = this.biDisconnected.ImageOptions.SvgImage;
                this.biConnectionStatus.Caption = "Disconnected";
            }
            else {
                SetInfoConnected();
            }
        }

        private void SetInfoConnected() {
            this.biConnectionStatus.ImageOptions.SvgImage = this.biConnected.ImageOptions.SvgImage;
            this.biConnectionStatus.Caption = "Connected";
        }

        void SubscribeWebSocket() {
            Exchange.StartListenTickersStream();
            ConnectionCheckTimer.Start();
            this.gridView1.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
        }

        protected override void OnShown(EventArgs e) {
            base.OnShown(e);
            Exchange.ObtainExchangeSettings();
            Exchange.LoadTickers();
            this.gridControl1.DataSource = Exchange.Tickers;
            HasShown = true;
            UpdateSelectedTickersFromExchange();
            if(!Exchange.SupportWebSocket(WebSocketType.Tickers)) {
                ThreadTimer.InitializeLifetimeService();
                SetInfoConnected();
            }
            else {
                Exchange.TickerUpdate += OnWebSocketTickerUpdate;
                SubscribeWebSocket();
            }
        }

        private void OnWebSocketTickerUpdate(object sender, TickerUpdateEventArgs e) {
            UpdateRow(e.Ticker);
        }

        void UpdateSelectedTickersFromExchange() {
            UpdatePinnedItems();
        }
        protected bool IsUpdating { get; set; }
        void OnThreadUpdate(object state) {
            if(IsUpdating || !Exchange.IsInitialized)
                return;
            IsUpdating = true;
            try {
                Exchange.UpdateTickersInfo();
                foreach(TickerBase ticker in Exchange.Tickers)
                    ticker.UpdateTrailings();
            }
            finally {
                IsUpdating = false;
            }
            if(IsHandleCreated)
                BeginInvoke(new Action(UpdateGridAll));
        }
        void UpdateRow(TickerBase t) {
            int index = Exchange.Tickers.IndexOf(t);
            int rowHandle = this.gridView1.GetRowHandle(index);
            this.gridView1.RefreshRow(rowHandle);
        }
        void UpdateGrid(TickerBase info) {
            int rowHandle = this.gridView1.GetRowHandle(info.Index);
            this.gridView1.RefreshRow(rowHandle);
        }
        void UpdateGridAll() {
            this.gridView1.RefreshData();
        }

        protected bool HasShown { get; set; }
        
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            ShowDetailsForSelectedItemCore();
        }

        void ShowDetailsForSelectedItemCore() {
            ShowDetailsForSelectedItemCore((TickerBase)this.gridView1.GetRow(this.gridView1.FocusedRowHandle));
        }
        void ShowDetailsForSelectedItemCore(TickerBase t) {
            if(this.gridView1.FocusedRowHandle == GridControl.InvalidRowHandle)
                return;
            TickerForm form = new TickerForm();
            form.MarketName = t.HostName;
            form.Ticker = t;
            form.MdiParent = MdiParent;
            form.Show();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e) {
            ShowDetailsForSelectedItemCore();
        }

        //PoloniexAccountBalancesForm accountForm;
        //protected PoloniexAccountBalancesForm AccountForm {
        //    get {
        //        if(accountForm == null || accountForm.IsDisposed)
        //            accountForm = new PoloniexAccountBalancesForm();
        //        return accountForm;
        //    }
        //}

        Form accountForm;
        protected Form AccountForm {
            get {
                if(accountForm == null || accountForm.IsDisposed) {
                    accountForm = Exchange.CreateAccountForm();
                }
                return accountForm;
            }
        }

        private void bbShowBalances_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            if(AccountForm == null) {
                XtraMessageBox.Show("AccountForm not realized for Exchanged - " + Exchange.Name);
                return;
            }
            AccountForm.MdiParent = MdiParent;
            AccountForm.Show();
            AccountForm.Activate();
        }

        OpenedOrdersForm ordersForm;
        protected OpenedOrdersForm OrdersForm {
            get {
                if(ordersForm == null || ordersForm.IsDisposed)
                    ordersForm = new OpenedOrdersForm(Exchange);
                return ordersForm;
            }
        }
        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            OrdersForm.MdiParent = MdiParent;
            OrdersForm.Show();
            OrdersForm.Activate();
        }
        protected void UpdatePinnedItems() {
            List<BarItem> addItems = new List<BarItem>();
            List<BarItem> removeItems = new List<BarItem>();
            foreach(PinnedTickerInfo info in Exchange.PinnedTickers) {
                BarItemLink link = this.bar1.ItemLinks.FirstOrDefault(l => l.Item.Tag == info);
                if(link == null) {
                    BarLargeButtonItem item = new BarLargeButtonItem(this.barManager1, info.ToString());
                    item.PaintStyle = BarItemPaintStyle.CaptionGlyph;
                    item.ImageOptions.Image = Exchange.GetTicker(info).Logo32;
                    item.Tag = info;
                    addItems.Add(item);
                }
            }
            foreach(BarItemLink link in this.bar1.ItemLinks) {
                PinnedTickerInfo info = link.Item.Tag as PinnedTickerInfo;
                if(info == null) continue;
                if(!Exchange.PinnedTickers.Contains(info))
                    removeItems.Add(link.Item);
            }
            this.barManager1.BeginUpdate();
            try {
                foreach(BarItem item in removeItems) {
                    this.barManager1.Items.Remove(item);
                }
                foreach(BarItem item in addItems) {
                    this.barManager1.Items.Add(item);
                    this.bar1.ItemLinks.Add(item);
                }
            }
            finally {
                this.barManager1.EndUpdate();
            }
        }
        private void repositoryItemCheckEdit1_EditValueChanged(object sender, EventArgs e) {
            this.gridView1.CloseEditor();
            TickerBase ticker = (TickerBase)this.gridView1.GetFocusedRow();
            UpdatePinnedItems();
        }

        private void barManager1_ItemClick(object sender, ItemClickEventArgs e) {
            if(e.Item.Tag is PinnedTickerInfo) {
                TickerBase t = Exchange.GetTicker((PinnedTickerInfo)e.Item.Tag);
                this.gridView1.FocusedRowHandle = this.gridView1.GetRowHandle(Exchange.Tickers.IndexOf(t));
                //ShowDetailsForSelectedItemCore(t);
            }
        }

        private void gridView1_MouseDown(object sender, MouseEventArgs e) {
            if(e.Button != MouseButtons.Right)
                return;
            TickerBase ticker = (TickerBase)this.gridView1.GetFocusedRow();
            if(IsTickerPinned(ticker)) {
                this.bbAddQuickPanel.Visibility = BarItemVisibility.Never;
                this.bbRemoveQuickPanel.Visibility = BarItemVisibility.Always;
            }
            else {
                this.bbAddQuickPanel.Visibility = BarItemVisibility.Always;
                this.bbRemoveQuickPanel.Visibility = BarItemVisibility.Never;
            }
            this.popupMenu1.ShowPopup(this.barManager1, this.gridControl1.PointToScreen(e.Location));
        }
        bool IsTickerPinned(TickerBase t) {
            return Exchange.PinnedTickers.FirstOrDefault(i => i.BaseCurrency == t.BaseCurrency && i.MarketCurrency == t.MarketCurrency) != null;
        }

        private void bbAddQuickPanel_ItemClick(object sender, ItemClickEventArgs e) {
            TickerBase ticker = (TickerBase)this.gridView1.GetFocusedRow();
            Exchange.PinnedTickers.Add(new Common.PinnedTickerInfo() { BaseCurrency = ticker.BaseCurrency, MarketCurrency = ticker.MarketCurrency });
            UpdatePinnedItems();
            Exchange.Save();
        }

        private void bbRemoveQuickPanel_ItemClick(object sender, ItemClickEventArgs e) {
            TickerBase t = (TickerBase)this.gridView1.GetFocusedRow();
            PinnedTickerInfo info = Exchange.PinnedTickers.FirstOrDefault(i => i.BaseCurrency == t.BaseCurrency && i.MarketCurrency == t.MarketCurrency);
            Exchange.PinnedTickers.Remove(info);
            UpdatePinnedItems();
            Exchange.Save();
        }

        private void barManager1_ItemPress(object sender, ItemClickEventArgs e) {
            if(Control.MouseButtons != MouseButtons.Right)
                return;
            PinnedTickerInfo info = e.Item.Tag as PinnedTickerInfo;
            if(info == null)

                return;
            if(Exchange.PinnedTickers.Contains(info)) {
                this.bbAddQuickPanel.Visibility = BarItemVisibility.Never;
                this.bbRemoveQuickPanel.Visibility = BarItemVisibility.Always;
            }
            else {
                this.bbAddQuickPanel.Visibility = BarItemVisibility.Always;
                this.bbRemoveQuickPanel.Visibility = BarItemVisibility.Never;
            }
            this.popupMenu1.ShowPopup(this.barManager1, Control.MousePosition);
        }

        private void barManager1_ShowToolbarsContextMenu(object sender, ShowToolbarsContextMenuEventArgs e) {
            e.ItemLinks.Clear();
            Point pt = Control.MousePosition;
            foreach(BarItemLink link in this.bar1.ItemLinks) {
                if(link.ScreenBounds.Contains(pt)) {
                    this.bbRemoveByRightClick.Tag = link.Item.Tag;
                    e.ItemLinks.Insert(0, this.bbRemoveByRightClick);
                    return;
                }
            }
        }

        private void bbRemoveByRightClick_ItemClick(object sender, ItemClickEventArgs e) {
            PinnedTickerInfo info = (PinnedTickerInfo)e.Item.Tag;
            Exchange.PinnedTickers.Remove(info);
            UpdatePinnedItems();
            Exchange.Save();
        }

        private void gridControl1_Click(object sender, EventArgs e) {

        }

        private void bbMonitorOnlySelected_CheckedChanged(object sender, ItemClickEventArgs e) {

        }

        private void barManager1_ItemDoubleClick(object sender, ItemClickEventArgs e) {
            if(e.Item.Tag is PinnedTickerInfo) {
                TickerBase t = Exchange.GetTicker((PinnedTickerInfo)e.Item.Tag);
                ShowDetailsForSelectedItemCore(t);
            }
        }

        private void gridView1_GetThumbnailImage(object sender, DevExpress.XtraGrid.Views.Grid.GridViewThumbnailImageEventArgs e) {
            TickerBase t = (TickerBase)Exchange.Tickers[e.DataSourceIndex];
            if(t.Logo != null) 
                e.ThumbnailImage = new Bitmap(t.Logo, new Size(128, 128));
        }
    }
}
