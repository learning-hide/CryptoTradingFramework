﻿namespace CryptoMarketClient {
    partial class TickersCollectionForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule1 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue1 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule3 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet1 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet1 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon1 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon2 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon3 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule4 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleIconSet formatConditionRuleIconSet2 = new DevExpress.XtraEditors.FormatConditionRuleIconSet();
            DevExpress.XtraEditors.FormatConditionIconSet formatConditionIconSet2 = new DevExpress.XtraEditors.FormatConditionIconSet();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon4 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon5 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraEditors.FormatConditionIconSetIcon formatConditionIconSetIcon6 = new DevExpress.XtraEditors.FormatConditionIconSetIcon();
            DevExpress.XtraGrid.GridFormatRule gridFormatRule5 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue3 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            DevExpress.Sparkline.LineSparklineView lineSparklineView1 = new DevExpress.Sparkline.LineSparklineView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TickersCollectionForm));
            this.gcPercentChange = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLast = new DevExpress.XtraGrid.Columns.GridColumn();
            this.teValueWithChange = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gcDeltaBid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHighestBid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDeltaAsk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcLowestAsk = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colIsActual = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSecond = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl1 = new CryptoMarketClient.MyGridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gcLogo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcCurrencyPair = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcBaseVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcQuoteVolume = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcIsFrozen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHr24High = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcHr24Low = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcFirst = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdateTimeMs = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemSparklineEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            this.barCheckItem2 = new DevExpress.XtraBars.BarCheckItem();
            this.ShowDetailsForSelectedItem = new DevExpress.XtraBars.BarButtonItem();
            this.bbShowBalances = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.bbAddQuickPanel = new DevExpress.XtraBars.BarButtonItem();
            this.bbRemoveQuickPanel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bbRemoveByRightClick = new DevExpress.XtraBars.BarButtonItem();
            this.biConnected = new DevExpress.XtraBars.BarStaticItem();
            this.biDisconnected = new DevExpress.XtraBars.BarStaticItem();
            this.biConnectionStatus = new DevExpress.XtraBars.BarStaticItem();
            this.biReconnect = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.popupMenu1 = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.teValueWithChange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSparklineEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // gcPercentChange
            // 
            this.gcPercentChange.Caption = "Percent Change";
            this.gcPercentChange.FieldName = "PercentChange";
            this.gcPercentChange.Name = "gcPercentChange";
            this.gcPercentChange.OptionsColumn.AllowEdit = false;
            this.gcPercentChange.Width = 86;
            // 
            // gcLast
            // 
            this.gcLast.Caption = "Last";
            this.gcLast.ColumnEdit = this.teValueWithChange;
            this.gcLast.FieldName = "LastString";
            this.gcLast.Name = "gcLast";
            this.gcLast.OptionsColumn.AllowEdit = false;
            this.gcLast.Visible = true;
            this.gcLast.VisibleIndex = 6;
            this.gcLast.Width = 86;
            // 
            // teValueWithChange
            // 
            this.teValueWithChange.AllowHtmlDraw = DevExpress.Utils.DefaultBoolean.True;
            this.teValueWithChange.AutoHeight = false;
            this.teValueWithChange.Name = "teValueWithChange";
            // 
            // gcDeltaBid
            // 
            this.gcDeltaBid.Caption = "Bid Change";
            this.gcDeltaBid.FieldName = "DeltaBid";
            this.gcDeltaBid.Name = "gcDeltaBid";
            // 
            // gcHighestBid
            // 
            this.gcHighestBid.Caption = "Highest Bid";
            this.gcHighestBid.ColumnEdit = this.teValueWithChange;
            this.gcHighestBid.FieldName = "HighestBidString";
            this.gcHighestBid.Name = "gcHighestBid";
            this.gcHighestBid.OptionsColumn.AllowEdit = false;
            this.gcHighestBid.Visible = true;
            this.gcHighestBid.VisibleIndex = 4;
            this.gcHighestBid.Width = 86;
            // 
            // gcDeltaAsk
            // 
            this.gcDeltaAsk.Caption = "Ask Change";
            this.gcDeltaAsk.FieldName = "DeltaAsk";
            this.gcDeltaAsk.Name = "gcDeltaAsk";
            // 
            // gcLowestAsk
            // 
            this.gcLowestAsk.Caption = "Lowest Ask";
            this.gcLowestAsk.ColumnEdit = this.teValueWithChange;
            this.gcLowestAsk.FieldName = "LowestAskString";
            this.gcLowestAsk.Name = "gcLowestAsk";
            this.gcLowestAsk.OptionsColumn.AllowEdit = false;
            this.gcLowestAsk.Visible = true;
            this.gcLowestAsk.VisibleIndex = 5;
            this.gcLowestAsk.Width = 86;
            // 
            // colIsActual
            // 
            this.colIsActual.Caption = "IsActual";
            this.colIsActual.FieldName = "IsActual";
            this.colIsActual.Name = "colIsActual";
            // 
            // gcSecond
            // 
            this.gcSecond.Caption = "Market Currency";
            this.gcSecond.ColumnEdit = this.repositoryItemTextEdit1;
            this.gcSecond.FieldName = "MarketCurrency";
            this.gcSecond.Name = "gcSecond";
            this.gcSecond.OptionsColumn.AllowEdit = false;
            this.gcSecond.Visible = true;
            this.gcSecond.VisibleIndex = 2;
            this.gcSecond.Width = 86;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.gridControl1.Location = new System.Drawing.Point(0, 315);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSparklineEdit1,
            this.repositoryItemCheckEdit1,
            this.repositoryItemTextEdit1,
            this.teValueWithChange});
            this.gridControl1.Size = new System.Drawing.Size(1451, 547);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseDirectXPaint = DevExpress.Utils.DefaultBoolean.True;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // gridView1
            // 
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.FontSizeDelta = 3;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.FontSizeDelta = 3;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.FontSizeDelta = 3;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.FontSizeDelta = 3;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colIsSelected,
            this.gcLogo,
            this.gcCurrencyPair,
            this.gcLast,
            this.gcLowestAsk,
            this.gcHighestBid,
            this.gcPercentChange,
            this.gcBaseVolume,
            this.gcQuoteVolume,
            this.gcIsFrozen,
            this.gcHr24High,
            this.gcHr24Low,
            this.gcTime,
            this.gcFirst,
            this.gcSecond,
            this.gcDeltaBid,
            this.gcDeltaAsk,
            this.colUpdateTimeMs,
            this.colIsActual});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.None;
            gridFormatRule1.Column = this.gcPercentChange;
            gridFormatRule1.ColumnApplyTo = this.gcLast;
            gridFormatRule1.Name = "FormatRulePercentChangeNegative";
            formatConditionRuleValue1.Condition = DevExpress.XtraEditors.FormatCondition.Less;
            formatConditionRuleValue1.PredefinedName = "Red Bold Text";
            formatConditionRuleValue1.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule1.Rule = formatConditionRuleValue1;
            gridFormatRule2.Name = "FormatRulePercentChangePositive";
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.GreaterOrEqual;
            formatConditionRuleValue2.PredefinedName = "Green Bold Text";
            formatConditionRuleValue2.Value1 = new decimal(new int[] {
            0,
            0,
            0,
            0});
            gridFormatRule2.Rule = formatConditionRuleValue2;
            gridFormatRule3.Column = this.gcDeltaBid;
            gridFormatRule3.ColumnApplyTo = this.gcHighestBid;
            gridFormatRule3.Name = "FormatRuleBidDelta";
            formatConditionIconSet1.CategoryName = "Positive/Negative";
            formatConditionIconSetIcon1.PredefinedName = "Arrows3_3.png";
            formatConditionIconSetIcon1.Value = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            formatConditionIconSetIcon1.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon2.PredefinedName = "Arrows3_2.png";
            formatConditionIconSetIcon2.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon3.PredefinedName = "Arrows3_1.png";
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon1);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon2);
            formatConditionIconSet1.Icons.Add(formatConditionIconSetIcon3);
            formatConditionIconSet1.Name = "PositiveNegativeArrows";
            formatConditionIconSet1.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleIconSet1.IconSet = formatConditionIconSet1;
            gridFormatRule3.Rule = formatConditionRuleIconSet1;
            gridFormatRule4.Column = this.gcDeltaAsk;
            gridFormatRule4.ColumnApplyTo = this.gcLowestAsk;
            gridFormatRule4.Name = "FormatRuleAskDelta";
            formatConditionIconSet2.CategoryName = "Positive/Negative";
            formatConditionIconSetIcon4.PredefinedName = "Arrows3_3.png";
            formatConditionIconSetIcon4.Value = new decimal(new int[] {
            -1,
            -1,
            -1,
            -2147483648});
            formatConditionIconSetIcon4.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon5.PredefinedName = "Arrows3_2.png";
            formatConditionIconSetIcon5.ValueComparison = DevExpress.XtraEditors.FormatConditionComparisonType.GreaterOrEqual;
            formatConditionIconSetIcon6.PredefinedName = "Arrows3_1.png";
            formatConditionIconSet2.Icons.Add(formatConditionIconSetIcon4);
            formatConditionIconSet2.Icons.Add(formatConditionIconSetIcon5);
            formatConditionIconSet2.Icons.Add(formatConditionIconSetIcon6);
            formatConditionIconSet2.Name = "PositiveNegativeArrows";
            formatConditionIconSet2.ValueType = DevExpress.XtraEditors.FormatConditionValueType.Number;
            formatConditionRuleIconSet2.IconSet = formatConditionIconSet2;
            gridFormatRule4.Rule = formatConditionRuleIconSet2;
            gridFormatRule5.Column = this.colIsActual;
            gridFormatRule5.ColumnApplyTo = this.gcSecond;
            gridFormatRule5.Name = "FormatSuspended";
            formatConditionRuleValue3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            formatConditionRuleValue3.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue3.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue3.Value1 = false;
            gridFormatRule5.Rule = formatConditionRuleValue3;
            this.gridView1.FormatRules.Add(gridFormatRule1);
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.FormatRules.Add(gridFormatRule3);
            this.gridView1.FormatRules.Add(gridFormatRule4);
            this.gridView1.FormatRules.Add(gridFormatRule5);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsDetail.EnableMasterViewMode = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.SegmentedFade;
            this.gridView1.OptionsImageLoad.AsyncLoad = true;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowHorizontalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsView.ShowIndicator = false;
            this.gridView1.OptionsView.ShowVerticalLines = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.RowHeight = 48;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gcFirst, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.GetThumbnailImage += new DevExpress.XtraGrid.Views.Grid.GridViewThumbnailImageEventHandler(this.gridView1_GetThumbnailImage);
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridView1_MouseDown);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // colIsSelected
            // 
            this.colIsSelected.Caption = " ";
            this.colIsSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.colIsSelected.CustomizationCaption = " ";
            this.colIsSelected.FieldName = "IsSelected";
            this.colIsSelected.Name = "colIsSelected";
            this.colIsSelected.Visible = true;
            this.colIsSelected.VisibleIndex = 0;
            this.colIsSelected.Width = 62;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.EditValueChanged += new System.EventHandler(this.repositoryItemCheckEdit1_EditValueChanged);
            // 
            // gcLogo
            // 
            this.gcLogo.Caption = "Logo";
            this.gcLogo.FieldName = "Logo";
            this.gcLogo.Name = "gcLogo";
            this.gcLogo.Visible = true;
            this.gcLogo.VisibleIndex = 1;
            // 
            // gcCurrencyPair
            // 
            this.gcCurrencyPair.Caption = "Market Name";
            this.gcCurrencyPair.FieldName = "CurrencyPair";
            this.gcCurrencyPair.Name = "gcCurrencyPair";
            this.gcCurrencyPair.OptionsColumn.AllowEdit = false;
            this.gcCurrencyPair.Visible = true;
            this.gcCurrencyPair.VisibleIndex = 3;
            this.gcCurrencyPair.Width = 86;
            // 
            // gcBaseVolume
            // 
            this.gcBaseVolume.Caption = "Base Volume";
            this.gcBaseVolume.FieldName = "BaseVolume";
            this.gcBaseVolume.Name = "gcBaseVolume";
            this.gcBaseVolume.OptionsColumn.AllowEdit = false;
            this.gcBaseVolume.Visible = true;
            this.gcBaseVolume.VisibleIndex = 7;
            this.gcBaseVolume.Width = 86;
            // 
            // gcQuoteVolume
            // 
            this.gcQuoteVolume.Caption = "Quote Volume";
            this.gcQuoteVolume.FieldName = "QuoteVolume";
            this.gcQuoteVolume.Name = "gcQuoteVolume";
            this.gcQuoteVolume.OptionsColumn.AllowEdit = false;
            this.gcQuoteVolume.Visible = true;
            this.gcQuoteVolume.VisibleIndex = 10;
            this.gcQuoteVolume.Width = 81;
            // 
            // gcIsFrozen
            // 
            this.gcIsFrozen.Caption = "Is Frozen";
            this.gcIsFrozen.FieldName = "IsFrozen";
            this.gcIsFrozen.Name = "gcIsFrozen";
            // 
            // gcHr24High
            // 
            this.gcHr24High.Caption = "24 Hour High";
            this.gcHr24High.FieldName = "Hr24High";
            this.gcHr24High.Name = "gcHr24High";
            this.gcHr24High.OptionsColumn.AllowEdit = false;
            this.gcHr24High.Visible = true;
            this.gcHr24High.VisibleIndex = 8;
            this.gcHr24High.Width = 86;
            // 
            // gcHr24Low
            // 
            this.gcHr24Low.Caption = "24 Hour Low";
            this.gcHr24Low.FieldName = "Hr24Low";
            this.gcHr24Low.Name = "gcHr24Low";
            this.gcHr24Low.OptionsColumn.AllowEdit = false;
            this.gcHr24Low.Visible = true;
            this.gcHr24Low.VisibleIndex = 9;
            this.gcHr24Low.Width = 86;
            // 
            // gcTime
            // 
            this.gcTime.Caption = "Time";
            this.gcTime.DisplayFormat.FormatString = "G";
            this.gcTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gcTime.FieldName = "Time";
            this.gcTime.Name = "gcTime";
            // 
            // gcFirst
            // 
            this.gcFirst.Caption = "Base Currency";
            this.gcFirst.FieldName = "BaseCurrency";
            this.gcFirst.Name = "gcFirst";
            this.gcFirst.Visible = true;
            this.gcFirst.VisibleIndex = 11;
            // 
            // colUpdateTimeMs
            // 
            this.colUpdateTimeMs.Caption = "UpdateTimeMs";
            this.colUpdateTimeMs.FieldName = "UpdateTimeMs";
            this.colUpdateTimeMs.Name = "colUpdateTimeMs";
            this.colUpdateTimeMs.OptionsColumn.AllowEdit = false;
            this.colUpdateTimeMs.Width = 44;
            // 
            // repositoryItemSparklineEdit1
            // 
            this.repositoryItemSparklineEdit1.EditValueMember = "Current";
            this.repositoryItemSparklineEdit1.Name = "repositoryItemSparklineEdit1";
            this.repositoryItemSparklineEdit1.PointValueMember = "Time";
            lineSparklineView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            lineSparklineView1.ScaleFactor = 1F;
            this.repositoryItemSparklineEdit1.View = lineSparklineView1;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.AllowGlyphSkinning = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Images = this.svgImageCollection1;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barCheckItem1,
            this.barCheckItem2,
            this.ShowDetailsForSelectedItem,
            this.bbShowBalances,
            this.barButtonItem1,
            this.bbAddQuickPanel,
            this.bbRemoveQuickPanel,
            this.barButtonItem2,
            this.bbRemoveByRightClick,
            this.biConnected,
            this.biDisconnected,
            this.biConnectionStatus,
            this.biReconnect});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.ribbonControl1.MaxItemId = 25;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.Size = new System.Drawing.Size(1451, 277);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("information", "image://devav/actions/about.svg");
            this.svgImageCollection1.Add("connected", "image://devav/actions/apply.svg");
            this.svgImageCollection1.Add("disconnected", "image://devav/actions/close.svg");
            this.svgImageCollection1.Add("download", "image://devav/actions/download.svg");
            this.svgImageCollection1.Add("connecting", "image://devav/actions/reverssort.svg");
            this.svgImageCollection1.Add("datadelay", "image://devav/people/employeenotice.svg");
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Id = 4;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // barCheckItem2
            // 
            this.barCheckItem2.Id = 5;
            this.barCheckItem2.Name = "barCheckItem2";
            // 
            // ShowDetailsForSelectedItem
            // 
            this.ShowDetailsForSelectedItem.Caption = "Enter Market";
            this.ShowDetailsForSelectedItem.Id = 3;
            this.ShowDetailsForSelectedItem.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ShowDetailsForSelectedItem.ImageOptions.Image")));
            this.ShowDetailsForSelectedItem.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("ShowDetailsForSelectedItem.ImageOptions.LargeImage")));
            this.ShowDetailsForSelectedItem.Name = "ShowDetailsForSelectedItem";
            this.ShowDetailsForSelectedItem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // bbShowBalances
            // 
            this.bbShowBalances.Caption = "Account Balances";
            this.bbShowBalances.Id = 7;
            this.bbShowBalances.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bbShowBalances.ImageOptions.Image")));
            this.bbShowBalances.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bbShowBalances.ImageOptions.LargeImage")));
            this.bbShowBalances.Name = "bbShowBalances";
            this.bbShowBalances.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbShowBalances_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Opened Orders";
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick_1);
            // 
            // bbAddQuickPanel
            // 
            this.bbAddQuickPanel.Caption = "Add To Quick Panel";
            this.bbAddQuickPanel.Id = 9;
            this.bbAddQuickPanel.Name = "bbAddQuickPanel";
            this.bbAddQuickPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbAddQuickPanel_ItemClick);
            // 
            // bbRemoveQuickPanel
            // 
            this.bbRemoveQuickPanel.Caption = "Remove From Quick Panel";
            this.bbRemoveQuickPanel.Id = 10;
            this.bbRemoveQuickPanel.Name = "bbRemoveQuickPanel";
            this.bbRemoveQuickPanel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRemoveQuickPanel_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 11;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bbRemoveByRightClick
            // 
            this.bbRemoveByRightClick.Caption = "Remove From Quick Panel";
            this.bbRemoveByRightClick.Id = 12;
            this.bbRemoveByRightClick.Name = "bbRemoveByRightClick";
            this.bbRemoveByRightClick.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbRemoveByRightClick_ItemClick);
            // 
            // biConnected
            // 
            this.biConnected.Caption = "Connected";
            this.biConnected.Id = 21;
            this.biConnected.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.biConnected.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("biConnected.ImageOptions.SvgImage")));
            this.biConnected.Name = "biConnected";
            // 
            // biDisconnected
            // 
            this.biDisconnected.Caption = "Disconnected";
            this.biDisconnected.Id = 22;
            this.biDisconnected.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.biDisconnected.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("biDisconnected.ImageOptions.SvgImage")));
            this.biDisconnected.Name = "biDisconnected";
            // 
            // biConnectionStatus
            // 
            this.biConnectionStatus.Caption = "Initializing...";
            this.biConnectionStatus.Id = 23;
            this.biConnectionStatus.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.biConnectionStatus.ImageOptions.ImageIndex = 0;
            this.biConnectionStatus.Name = "biConnectionStatus";
            // 
            // biReconnect
            // 
            this.biReconnect.Caption = "Reconnect";
            this.biReconnect.Id = 24;
            this.biReconnect.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.False;
            this.biReconnect.ImageOptions.ImageIndex = 4;
            this.biReconnect.Name = "biReconnect";
            this.biReconnect.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.biReconnect.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.biReconnect_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Connect";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.ShowDetailsForSelectedItem);
            this.ribbonPageGroup1.ItemLinks.Add(this.bbShowBalances);
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Market";
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.AutoHeight = true;
            this.ribbonStatusBar1.ItemLinks.Add(this.biConnectionStatus);
            this.ribbonStatusBar1.ItemLinks.Add(this.biReconnect);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 808);
            this.ribbonStatusBar1.Margin = new System.Windows.Forms.Padding(6);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1451, 54);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 0;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            this.barManager1.ItemDoubleClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemDoubleClick);
            this.barManager1.ItemPress += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemPress);
            this.barManager1.ShowToolbarsContextMenu += new DevExpress.XtraBars.ShowToolbarsContextMenuEventHandler(this.barManager1_ShowToolbarsContextMenu);
            // 
            // bar1
            // 
            this.bar1.BarItemHorzIndent = 16;
            this.bar1.BarItemVertIndent = 16;
            this.bar1.BarName = "Custom 2";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.bar1.FloatLocation = new System.Drawing.Point(679, 603);
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DrawBorder = false;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.bar1.Text = "Custom 2";
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.AutoSize = true;
            this.standaloneBarDockControl1.CausesValidation = false;
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 277);
            this.standaloneBarDockControl1.Manager = this.barManager1;
            this.standaloneBarDockControl1.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1451, 38);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.barDockControlTop.Size = new System.Drawing.Size(1451, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 862);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.barDockControlBottom.Size = new System.Drawing.Size(1451, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 862);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1451, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(16, 15, 16, 15);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 862);
            // 
            // popupMenu1
            // 
            this.popupMenu1.ItemLinks.Add(this.bbAddQuickPanel);
            this.popupMenu1.ItemLinks.Add(this.bbRemoveQuickPanel);
            this.popupMenu1.Name = "popupMenu1";
            this.popupMenu1.Ribbon = this.ribbonControl1;
            // 
            // TickersCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1451, 862);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.ribbonControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(24, 23, 24, 23);
            this.Name = "TickersCollectionForm";
            this.Text = "Poloniex Markets";
            ((System.ComponentModel.ISupportInitialize)(this.teValueWithChange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSparklineEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyGridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gcCurrencyPair;
        private DevExpress.XtraGrid.Columns.GridColumn gcLast;
        private DevExpress.XtraGrid.Columns.GridColumn gcLowestAsk;
        private DevExpress.XtraGrid.Columns.GridColumn gcHighestBid;
        private DevExpress.XtraGrid.Columns.GridColumn gcPercentChange;
        private DevExpress.XtraGrid.Columns.GridColumn gcBaseVolume;
        private DevExpress.XtraGrid.Columns.GridColumn gcQuoteVolume;
        private DevExpress.XtraGrid.Columns.GridColumn gcIsFrozen;
        private DevExpress.XtraGrid.Columns.GridColumn gcHr24High;
        private DevExpress.XtraGrid.Columns.GridColumn gcHr24Low;
        private DevExpress.XtraGrid.Columns.GridColumn gcTime;
        private DevExpress.XtraGrid.Columns.GridColumn gcFirst;
        private DevExpress.XtraGrid.Columns.GridColumn gcSecond;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraBars.BarCheckItem barCheckItem2;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeltaBid;
        private DevExpress.XtraGrid.Columns.GridColumn gcDeltaAsk;
        private DevExpress.XtraEditors.Repository.RepositoryItemSparklineEdit repositoryItemSparklineEdit1;
        private DevExpress.XtraBars.BarButtonItem ShowDetailsForSelectedItem;
        private DevExpress.XtraBars.BarButtonItem bbShowBalances;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraGrid.Columns.GridColumn colIsSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbAddQuickPanel;
        private DevExpress.XtraBars.BarButtonItem bbRemoveQuickPanel;
        private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem bbRemoveByRightClick;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdateTimeMs;
        private DevExpress.XtraGrid.Columns.GridColumn colIsActual;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit teValueWithChange;
        private DevExpress.XtraGrid.Columns.GridColumn gcLogo;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarStaticItem biConnected;
        private DevExpress.XtraBars.BarStaticItem biDisconnected;
        private DevExpress.XtraBars.BarStaticItem biConnectionStatus;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraBars.BarButtonItem biReconnect;
    }
}