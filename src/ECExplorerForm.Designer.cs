/*
 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 +                                                                  +
 +                                                                  +
 + EC Explorer  An Embedded Controller viewer and hardware          +
 +                                                                  +
 +              resource monitoring                                 +
 +                                                                  +
 +              This file is part of the EC Explorer distribution.  +
 +                                                                  +
 +                                                                  +
 +                                                                  +
 +                                                                  +  
 + Author:  Andrew McGregor, <andrew.drunkyduck@gmail.com>          +
 +                                                                  +
 +          Copyright 2025 Andrew McGregor.                         +
 +                                                                  +
 +                                                                  +
 +                                                                  +
 +                                                                  +  
 +  This Source Code Form is subject to the terms of the            +
 +  Mozilla Public License, v. 2.0. If a copy of the MPL            +
 +  was not distributed with this file, You can obtain              +
 +  one at http://mozilla.org/MPL/2.0/.                             +
 +                                                                  +
 +                                                                  +
 +                                                                  +
 ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
 */



namespace ECExplorerFormsApp
{
    partial class ECExplorerForm
    {

        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Dispose components
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region ECExplorer Forms App


        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();

	//Timers

            this.ReadingTimer = new System.Windows.Forms.Timer(this.components);
            this.ECTableTimer = new System.Windows.Forms.Timer(this.components);

	//Help Page

            this.HelpTabPage = new System.Windows.Forms.TabPage();
            this.HelpRichTextBox = new System.Windows.Forms.RichTextBox();
            this.QuitButton = new System.Windows.Forms.Button();
            this.UnloadButton = new System.Windows.Forms.Button();
            this.LoadButton = new System.Windows.Forms.Button();

	//ECTable Page

            this.ECTabPage = new System.Windows.Forms.TabPage();
            this.ECTableRefreshTrackBar = new System.Windows.Forms.TrackBar();
            this.ECTableListBox = new System.Windows.Forms.ListBox();
            this.ECTableUpdateButton = new System.Windows.Forms.Button();

	//Settings Page

            this.SettingsTabPage = new System.Windows.Forms.TabPage();
            this.SettingSaveButton = new System.Windows.Forms.Button();
            this.SettingsApplyButton = new System.Windows.Forms.Button();
            this.SettingsComboBox = new System.Windows.Forms.ComboBox();

            this.groupBoxBat = new System.Windows.Forms.GroupBox();
            this.BatAMregisterCheckBox = new System.Windows.Forms.CheckBox();
            this.BatAMregisterComboBox = new System.Windows.Forms.ComboBox();
            this.BatAMregisterLabel = new System.Windows.Forms.Label();
            this.BatADregisterCheckBox = new System.Windows.Forms.CheckBox();
            this.BatADregisterComboBox = new System.Windows.Forms.ComboBox();
            this.BatADregisterLabel = new System.Windows.Forms.Label();
            this.BatAregisterCheckBox = new System.Windows.Forms.CheckBox();
            this.BatAregisterComboBox = new System.Windows.Forms.ComboBox();
            this.BatAregisterLabel = new System.Windows.Forms.Label();
            this.BatVregisterCheckBox = new System.Windows.Forms.CheckBox();
            this.BatVregisterComboBox = new System.Windows.Forms.ComboBox();
            this.BatVregisterLabel = new System.Windows.Forms.Label();

            this.groupBoxFan = new System.Windows.Forms.GroupBox();
            this.Fan2registerCheckBox = new System.Windows.Forms.CheckBox();
            this.Fan1registerCheckBox = new System.Windows.Forms.CheckBox();
            this.Fan2registerLabel = new System.Windows.Forms.Label();
            this.Fan2registerComboBox = new System.Windows.Forms.ComboBox();
            this.Fan1registerComboBox = new System.Windows.Forms.ComboBox();
            this.Fan1registerLlabel = new System.Windows.Forms.Label();

            this.groupBoxTemp = new System.Windows.Forms.GroupBox();
            this.Temp3registerCheckBox = new System.Windows.Forms.CheckBox();
            this.Temp2registerCheckBox = new System.Windows.Forms.CheckBox();
            this.Temp1registerCheckBox = new System.Windows.Forms.CheckBox();
            this.Temp3registerComboBox = new System.Windows.Forms.ComboBox();
            this.Temp2registerComboBox = new System.Windows.Forms.ComboBox();
            this.Temp3registerLabel = new System.Windows.Forms.Label();
            this.Temp2registerLabel = new System.Windows.Forms.Label();
            this.Temp1registerComboBox = new System.Windows.Forms.ComboBox();
            this.Temp1registerLabel = new System.Windows.Forms.Label();

            this.groupBoxLaptop = new System.Windows.Forms.GroupBox();
            this.LaptopPictureBox = new System.Windows.Forms.PictureBox();

	//Readings Page

            this.ReadingsTabPage = new System.Windows.Forms.TabPage();
            this.ReadingsDisplayRichTextBox = new System.Windows.Forms.RichTextBox();
            this.ReadingRefreshGroupBox = new System.Windows.Forms.GroupBox();
            this.ReadingRefreshTrackBar = new System.Windows.Forms.TrackBar();
            this.ReadingsApplyButton = new System.Windows.Forms.Button();
            this.Temp1ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Temp2ProgressBar = new System.Windows.Forms.ProgressBar();
            this.TemperatureListBox = new System.Windows.Forms.ListBox();
            this.Fan1CGroupBox = new System.Windows.Forms.GroupBox();
            this.Fan2CGroupBox = new System.Windows.Forms.GroupBox();
            this.Fan2speedProgressBar = new System.Windows.Forms.ProgressBar();
            this.Fan1speedProgressBar = new System.Windows.Forms.ProgressBar();
            this.FanSpeedListBox = new System.Windows.Forms.ListBox();
            this.SetSpeedFan1CTrackBar = new System.Windows.Forms.TrackBar();
            this.SetSpeedFan2CTrackBar = new System.Windows.Forms.TrackBar();
            this.BatteryListBox = new System.Windows.Forms.ListBox();
            this.BatteryProgressBar = new System.Windows.Forms.ProgressBar();

            this.MaintabControl = new System.Windows.Forms.TabControl();


	//Layout

            this.HelpTabPage.SuspendLayout();
            this.ECTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ECTableRefreshTrackBar)).BeginInit();
            this.SettingsTabPage.SuspendLayout();
            this.groupBoxBat.SuspendLayout();
            this.groupBoxFan.SuspendLayout();
            this.groupBoxTemp.SuspendLayout();
            this.groupBoxLaptop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LaptopPictureBox)).BeginInit();
            this.ReadingsTabPage.SuspendLayout();
            this.Fan2CGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetSpeedFan2CTrackBar)).BeginInit();
            this.Fan1CGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetSpeedFan1CTrackBar)).BeginInit();
            this.ReadingRefreshGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReadingRefreshTrackBar)).BeginInit();
            this.MaintabControl.SuspendLayout();
            this.SuspendLayout();


        // Property

            // timer1 ReadingTimer

            this.ReadingTimer.Enabled = true;
            this.ReadingTimer.Interval = 2000;
            this.ReadingTimer.Tick += new System.EventHandler(this.ReadingTimer_Tick);

            // timer2 ECTabletimer

            this.ECTableTimer.Interval = 3000;
            this.ECTableTimer.Tick += new System.EventHandler(this.ECTableTimer_Tick);

            // HelpTabPage

            this.HelpTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.HelpTabPage.Controls.Add(this.HelpRichTextBox);
            this.HelpTabPage.Controls.Add(this.QuitButton);
            this.HelpTabPage.Controls.Add(this.UnloadButton);
            this.HelpTabPage.Controls.Add(this.LoadButton);
            this.HelpTabPage.Location = new System.Drawing.Point(4, 22);
            this.HelpTabPage.Name = "HelpTabPage";
            this.HelpTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.HelpTabPage.Size = new System.Drawing.Size(431, 348);
            this.HelpTabPage.TabIndex = 3;
            this.HelpTabPage.Text = "Help";
 
            // HelpRichTextBox

            this.HelpRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HelpRichTextBox.Location = new System.Drawing.Point(34, 34);
            this.HelpRichTextBox.Name = "HelpRichTextBox";
            this.HelpRichTextBox.Size = new System.Drawing.Size(359, 209);
            this.HelpRichTextBox.TabIndex = 4;
            this.HelpRichTextBox.Text = "";

            // QuitButton

            this.QuitButton.Location = new System.Drawing.Point(325, 279);
            this.QuitButton.Name = "QuitButton";
            this.QuitButton.Size = new System.Drawing.Size(68, 35);
            this.QuitButton.TabIndex = 0;
            this.QuitButton.Text = "Quit";
            this.QuitButton.UseVisualStyleBackColor = true;
            this.QuitButton.Click += new System.EventHandler(this.QuitButton_Click);

            // UnloadButton

            this.UnloadButton.Location = new System.Drawing.Point(236, 278);
            this.UnloadButton.Name = "UnloadButton";
            this.UnloadButton.Size = new System.Drawing.Size(70, 36);
            this.UnloadButton.TabIndex = 3;
            this.UnloadButton.Text = "Stop";
            this.UnloadButton.UseVisualStyleBackColor = true;
            this.UnloadButton.Click += new System.EventHandler(this.UnloadButton_Click);

            // LoadButton

            this.LoadButton.Location = new System.Drawing.Point(150, 278);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(67, 35);
            this.LoadButton.TabIndex = 2;
            this.LoadButton.Text = "Start";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);

            // ECTablePage

            this.ECTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ECTabPage.Controls.Add(this.ECTableRefreshTrackBar);
            this.ECTabPage.Controls.Add(this.ECTableListBox);
            this.ECTabPage.Controls.Add(this.ECTableUpdateButton);
            this.ECTabPage.Location = new System.Drawing.Point(4, 22);
            this.ECTabPage.Name = "ECTabPage";
            this.ECTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ECTabPage.Size = new System.Drawing.Size(431, 348);
            this.ECTabPage.TabIndex = 4;
            this.ECTabPage.Text = "EC Table";

            // ECTableRefreshTrackBar

            this.ECTableRefreshTrackBar.LargeChange = 2;
            this.ECTableRefreshTrackBar.SmallChange = 1;
            this.ECTableRefreshTrackBar.Location = new System.Drawing.Point(22, 286);
            this.ECTableRefreshTrackBar.Name = "ECTableRefreshTrackBar";
            this.ECTableRefreshTrackBar.Size = new System.Drawing.Size(246, 45);
            this.ECTableRefreshTrackBar.TabIndex = 3;
            this.ECTableRefreshTrackBar.Minimum = 0;
            this.ECTableRefreshTrackBar.Maximum = 8;
            this.ECTableRefreshTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ECTableRefreshTrackBar.Scroll += new System.EventHandler(this.ECTableRefreshTrackBar_Scroll);

            // ECTableListBox

            this.ECTableListBox.FormattingEnabled = true;
            this.ECTableListBox.Location = new System.Drawing.Point(22, 19);
            this.ECTableListBox.Name = "ECTableListBox";
            this.ECTableListBox.Size = new System.Drawing.Size(385, 251);
            this.ECTableListBox.TabIndex = 2;

            // ECTableUpdateButton

            this.ECTableUpdateButton.Location = new System.Drawing.Point(342, 300);
            this.ECTableUpdateButton.Name = "ECTableUpdateButton";
            this.ECTableUpdateButton.Size = new System.Drawing.Size(65, 31);
            this.ECTableUpdateButton.TabIndex = 1;
            this.ECTableUpdateButton.Text = "Update";
            this.ECTableUpdateButton.UseVisualStyleBackColor = true;
            this.ECTableUpdateButton.Click += new System.EventHandler(this.ECTableUpdateButton_Click);

            // SettingsTabPage

            this.SettingsTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.SettingsTabPage.Controls.Add(this.SettingSaveButton);
            this.SettingsTabPage.Controls.Add(this.groupBoxBat);
            this.SettingsTabPage.Controls.Add(this.SettingsApplyButton);
            this.SettingsTabPage.Controls.Add(this.groupBoxFan);
            this.SettingsTabPage.Controls.Add(this.groupBoxTemp);
            this.SettingsTabPage.Controls.Add(this.SettingsComboBox);
            this.SettingsTabPage.Controls.Add(this.groupBoxLaptop);
            this.SettingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.SettingsTabPage.Name = "SettingsTabPage";
            this.SettingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SettingsTabPage.Size = new System.Drawing.Size(431, 348);
            this.SettingsTabPage.TabIndex = 2;
            this.SettingsTabPage.Text = "Settings";

            // SettingSaveButton

            this.SettingSaveButton.Enabled = false;
            this.SettingSaveButton.Location = new System.Drawing.Point(22, 299);
            this.SettingSaveButton.Name = "SettingSaveButton";
            this.SettingSaveButton.Size = new System.Drawing.Size(64, 30);
            this.SettingSaveButton.TabIndex = 22;
            this.SettingSaveButton.Text = "Save";
            this.SettingSaveButton.UseVisualStyleBackColor = true;
            this.SettingSaveButton.Click += new System.EventHandler(this.SettingSaveButton_Click);

            // groupBoxBat

            this.groupBoxBat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxBat.Controls.Add(this.BatAMregisterCheckBox);
            this.groupBoxBat.Controls.Add(this.BatAMregisterComboBox);
            this.groupBoxBat.Controls.Add(this.BatAMregisterLabel);
            this.groupBoxBat.Controls.Add(this.BatADregisterCheckBox);
            this.groupBoxBat.Controls.Add(this.BatADregisterComboBox);
            this.groupBoxBat.Controls.Add(this.BatADregisterLabel);
            this.groupBoxBat.Controls.Add(this.BatAregisterCheckBox);
            this.groupBoxBat.Controls.Add(this.BatAregisterComboBox);
            this.groupBoxBat.Controls.Add(this.BatAregisterLabel);
            this.groupBoxBat.Controls.Add(this.BatVregisterCheckBox);
            this.groupBoxBat.Controls.Add(this.BatVregisterComboBox);
            this.groupBoxBat.Controls.Add(this.BatVregisterLabel);
            this.groupBoxBat.Enabled = false;
            this.groupBoxBat.Location = new System.Drawing.Point(294, 20);
            this.groupBoxBat.Name = "groupBoxBat";
            this.groupBoxBat.Size = new System.Drawing.Size(109, 263);
            this.groupBoxBat.TabIndex = 21;
            this.groupBoxBat.TabStop = false;
            this.groupBoxBat.Text = "Bat registers";

            // BatAMregisterCheckBox
 
            this.BatAMregisterCheckBox.AutoSize = true;
            this.BatAMregisterCheckBox.Checked = true;
            this.BatAMregisterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatAMregisterCheckBox.Location = new System.Drawing.Point(25, 170);
            this.BatAMregisterCheckBox.Name = "BatAMregisterCheckBox";
            this.BatAMregisterCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BatAMregisterCheckBox.Size = new System.Drawing.Size(60, 17);
            this.BatAMregisterCheckBox.TabIndex = 11;
            this.BatAMregisterCheckBox.Text = "Double";
            this.BatAMregisterCheckBox.UseVisualStyleBackColor = true;

            // BatAMregisterComboBox

            this.BatAMregisterComboBox.FormattingEnabled = true;
            this.BatAMregisterComboBox.IntegralHeight = false;
            this.BatAMregisterComboBox.Location = new System.Drawing.Point(52, 140);
            this.BatAMregisterComboBox.Name = "BatAMregisterComboBox";
            this.BatAMregisterComboBox.Size = new System.Drawing.Size(40, 21);
            this.BatAMregisterComboBox.TabIndex = 10;

            // BatAMregisterLabel

            this.BatAMregisterLabel.AutoSize = true;
            this.BatAMregisterLabel.Location = new System.Drawing.Point(8, 145);
            this.BatAMregisterLabel.Name = "BatAMregisterLabel";
            this.BatAMregisterLabel.Size = new System.Drawing.Size(39, 13);
            this.BatAMregisterLabel.TabIndex = 9;
            this.BatAMregisterLabel.Text = "BatAM";

            // BatADregisterCheckBox

            this.BatADregisterCheckBox.AutoSize = true;
            this.BatADregisterCheckBox.Checked = true;
            this.BatADregisterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatADregisterCheckBox.Location = new System.Drawing.Point(22, 230);
            this.BatADregisterCheckBox.Name = "BatADregisterCheckBox";
            this.BatADregisterCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BatADregisterCheckBox.Size = new System.Drawing.Size(60, 17);
            this.BatADregisterCheckBox.TabIndex = 8;
            this.BatADregisterCheckBox.Text = "Double";
            this.BatADregisterCheckBox.UseVisualStyleBackColor = true;

            // BatADregisterComboBox

            this.BatADregisterComboBox.DropDownHeight = 120;
            this.BatADregisterComboBox.DropDownWidth = 44;
            this.BatADregisterComboBox.FormattingEnabled = true;
            this.BatADregisterComboBox.IntegralHeight = false;
            this.BatADregisterComboBox.Location = new System.Drawing.Point(52, 200);
            this.BatADregisterComboBox.Name = "BatADregisterComboBox";
            this.BatADregisterComboBox.Size = new System.Drawing.Size(43, 21);
            this.BatADregisterComboBox.TabIndex = 7;

            // BatADregisterLabel

            this.BatADregisterLabel.AutoSize = true;
            this.BatADregisterLabel.Location = new System.Drawing.Point(8, 205);
            this.BatADregisterLabel.Name = "BatADregisterLabel";
            this.BatADregisterLabel.Size = new System.Drawing.Size(38, 13);
            this.BatADregisterLabel.TabIndex = 6;
            this.BatADregisterLabel.Text = "BatAD";

            // BatAregisterCheckBox

            this.BatAregisterCheckBox.AutoSize = true;
            this.BatAregisterCheckBox.Checked = true;
            this.BatAregisterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatAregisterCheckBox.Location = new System.Drawing.Point(25, 110);
            this.BatAregisterCheckBox.Name = "BatAregisterCheckBox";
            this.BatAregisterCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BatAregisterCheckBox.Size = new System.Drawing.Size(60, 17);
            this.BatAregisterCheckBox.TabIndex = 5;
            this.BatAregisterCheckBox.Text = "Double";
            this.BatAregisterCheckBox.UseVisualStyleBackColor = true;

            // BatAregisterComboBox

            this.BatAregisterComboBox.DropDownHeight = 120;
            this.BatAregisterComboBox.FormattingEnabled = true;
            this.BatAregisterComboBox.IntegralHeight = false;
            this.BatAregisterComboBox.Location = new System.Drawing.Point(52, 80);
            this.BatAregisterComboBox.Name = "BatAregisterComboBox";
            this.BatAregisterComboBox.Size = new System.Drawing.Size(44, 21);
            this.BatAregisterComboBox.TabIndex = 4;

            // BatAregisterLabel

            this.BatAregisterLabel.AutoSize = true;
            this.BatAregisterLabel.Location = new System.Drawing.Point(8, 85);
            this.BatAregisterLabel.Name = "BatAregisterLabel";
            this.BatAregisterLabel.Size = new System.Drawing.Size(30, 13);
            this.BatAregisterLabel.TabIndex = 3;
            this.BatAregisterLabel.Text = "BatA";

            // BatVregisterCheckBox

            this.BatVregisterCheckBox.AutoSize = true;
            this.BatVregisterCheckBox.Checked = true;
            this.BatVregisterCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatVregisterCheckBox.Location = new System.Drawing.Point(25, 50);
            this.BatVregisterCheckBox.Name = "BatVregisterCheckBox";
            this.BatVregisterCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BatVregisterCheckBox.Size = new System.Drawing.Size(60, 17);
            this.BatVregisterCheckBox.TabIndex = 2;
            this.BatVregisterCheckBox.Text = "Double";
            this.BatVregisterCheckBox.UseVisualStyleBackColor = true;

            // BatVregisterComboBox

            this.BatVregisterComboBox.DropDownHeight = 120;
            this.BatVregisterComboBox.FormattingEnabled = true;
            this.BatVregisterComboBox.IntegralHeight = false;
            this.BatVregisterComboBox.Location = new System.Drawing.Point(52, 20);
            this.BatVregisterComboBox.Name = "BatVregisterComboBox";
            this.BatVregisterComboBox.Size = new System.Drawing.Size(44, 21);
            this.BatVregisterComboBox.TabIndex = 1;

            // BatVregisterLabel

            this.BatVregisterLabel.AutoSize = true;
            this.BatVregisterLabel.Location = new System.Drawing.Point(8, 25);
            this.BatVregisterLabel.Name = "BatVregisterLabel";
            this.BatVregisterLabel.Size = new System.Drawing.Size(30, 13);
            this.BatVregisterLabel.TabIndex = 0;
            this.BatVregisterLabel.Text = "BatV";

            // SettingsApplyButton

            this.SettingsApplyButton.Enabled = false;
            this.SettingsApplyButton.Location = new System.Drawing.Point(339, 299);
            this.SettingsApplyButton.Name = "SettingsApplyButton";
            this.SettingsApplyButton.Size = new System.Drawing.Size(64, 30);
            this.SettingsApplyButton.TabIndex = 17;
            this.SettingsApplyButton.Text = "Apply";
            this.SettingsApplyButton.UseVisualStyleBackColor = true;
            this.SettingsApplyButton.Click += new System.EventHandler(this.SettingsApplyButton_Click);

            // groupBoxFan

            this.groupBoxFan.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxFan.Controls.Add(this.Fan2registerCheckBox);
            this.groupBoxFan.Controls.Add(this.Fan1registerCheckBox);
            this.groupBoxFan.Controls.Add(this.Fan2registerLabel);
            this.groupBoxFan.Controls.Add(this.Fan2registerComboBox);
            this.groupBoxFan.Controls.Add(this.Fan1registerComboBox);
            this.groupBoxFan.Controls.Add(this.Fan1registerLlabel);
            this.groupBoxFan.Enabled = false;
            this.groupBoxFan.Location = new System.Drawing.Point(156, 20);
            this.groupBoxFan.Name = "groupBoxFan";
            this.groupBoxFan.Size = new System.Drawing.Size(120, 145);
            this.groupBoxFan.TabIndex = 13;
            this.groupBoxFan.TabStop = false;
            this.groupBoxFan.Text = "Fan registers";

            // Fan2registerCheckBox

            this.Fan2registerCheckBox.AutoSize = true;
            this.Fan2registerCheckBox.Checked = true;
            this.Fan2registerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Fan2registerCheckBox.Location = new System.Drawing.Point(25, 110);
            this.Fan2registerCheckBox.Name = "Fan2registerCheckBox";
            this.Fan2registerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Fan2registerCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Fan2registerCheckBox.TabIndex = 17;
            this.Fan2registerCheckBox.Text = "Double";
            this.Fan2registerCheckBox.UseVisualStyleBackColor = true;

            // Fan1registerCheckBox

            this.Fan1registerCheckBox.AutoSize = true;
            this.Fan1registerCheckBox.Checked = true;
            this.Fan1registerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Fan1registerCheckBox.Location = new System.Drawing.Point(23, 50);
            this.Fan1registerCheckBox.Name = "Fan1registerCheckBox";
            this.Fan1registerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Fan1registerCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Fan1registerCheckBox.TabIndex = 16;
            this.Fan1registerCheckBox.Text = "Double";
            this.Fan1registerCheckBox.UseVisualStyleBackColor = true;

            // Fan2registerLabel

            this.Fan2registerLabel.AutoSize = true;
            this.Fan2registerLabel.Location = new System.Drawing.Point(8, 85);
            this.Fan2registerLabel.Name = "Fan2registerLabel";
            this.Fan2registerLabel.Size = new System.Drawing.Size(31, 13);
            this.Fan2registerLabel.TabIndex = 15;
            this.Fan2registerLabel.Text = "Fan2";

            // Fan2registerComboBox

            this.Fan2registerComboBox.DropDownHeight = 120;
            this.Fan2registerComboBox.FormattingEnabled = true;
            this.Fan2registerComboBox.IntegralHeight = false;
            this.Fan2registerComboBox.Location = new System.Drawing.Point(52, 80);
            this.Fan2registerComboBox.Name = "Fan2registerComboBox";
            this.Fan2registerComboBox.Size = new System.Drawing.Size(44, 21);
            this.Fan2registerComboBox.TabIndex = 13;

            // Fan1registerComboBox

            this.Fan1registerComboBox.DropDownHeight = 120;
            this.Fan1registerComboBox.FormattingEnabled = true;
            this.Fan1registerComboBox.IntegralHeight = false;
            this.Fan1registerComboBox.Location = new System.Drawing.Point(52, 20);
            this.Fan1registerComboBox.Name = "Fan1registerComboBox";
            this.Fan1registerComboBox.Size = new System.Drawing.Size(44, 21);
            this.Fan1registerComboBox.TabIndex = 12;

            // Fan1registerLlabel

            this.Fan1registerLlabel.AutoSize = true;
            this.Fan1registerLlabel.Location = new System.Drawing.Point(8, 25);
            this.Fan1registerLlabel.Name = "Fan1registerLlabel";
            this.Fan1registerLlabel.Size = new System.Drawing.Size(31, 13);
            this.Fan1registerLlabel.TabIndex = 11;
            this.Fan1registerLlabel.Text = "Fan1";

            // groupBoxTemp

            this.groupBoxTemp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxTemp.Controls.Add(this.Temp1registerLabel);
            this.groupBoxTemp.Controls.Add(this.Temp3registerLabel);
            this.groupBoxTemp.Controls.Add(this.Temp2registerLabel);
            this.groupBoxTemp.Controls.Add(this.Temp3registerCheckBox);
            this.groupBoxTemp.Controls.Add(this.Temp2registerCheckBox);
            this.groupBoxTemp.Controls.Add(this.Temp1registerCheckBox);
            this.groupBoxTemp.Controls.Add(this.Temp3registerComboBox);
            this.groupBoxTemp.Controls.Add(this.Temp2registerComboBox);
            this.groupBoxTemp.Controls.Add(this.Temp1registerComboBox);
            this.groupBoxTemp.Enabled = false;
            this.groupBoxTemp.Location = new System.Drawing.Point(22, 20);
            this.groupBoxTemp.Name = "groupBoxTemp";
            this.groupBoxTemp.Size = new System.Drawing.Size(117, 203);
            this.groupBoxTemp.TabIndex = 10;
            this.groupBoxTemp.TabStop = false;
            this.groupBoxTemp.Text = "Temp registers";

            // Temp3registerCheckBox

            this.Temp3registerCheckBox.AutoSize = true;
            this.Temp3registerCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.Temp3registerCheckBox.Location = new System.Drawing.Point(23, 170);
            this.Temp3registerCheckBox.Name = "Temp3registerCheckBox";
            this.Temp3registerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Temp3registerCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Temp3registerCheckBox.TabIndex = 12;
            this.Temp3registerCheckBox.Text = "Double";
            this.Temp3registerCheckBox.UseVisualStyleBackColor = false;

            // Temp2registerCheckBox

            this.Temp2registerCheckBox.AutoSize = true;
            this.Temp2registerCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.Temp2registerCheckBox.Location = new System.Drawing.Point(23, 110);
            this.Temp2registerCheckBox.Name = "Temp2registerCheckBox";
            this.Temp2registerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Temp2registerCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Temp2registerCheckBox.TabIndex = 11;
            this.Temp2registerCheckBox.Text = "Double";
            this.Temp2registerCheckBox.UseVisualStyleBackColor = false;

            // Temp1registerCheckBox

            this.Temp1registerCheckBox.AutoSize = true;
            this.Temp1registerCheckBox.BackColor = System.Drawing.Color.Transparent;
            this.Temp1registerCheckBox.Location = new System.Drawing.Point(23, 50);
            this.Temp1registerCheckBox.Name = "Temp1registerCheckBox";
            this.Temp1registerCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Temp1registerCheckBox.Size = new System.Drawing.Size(60, 17);
            this.Temp1registerCheckBox.TabIndex = 10;
            this.Temp1registerCheckBox.Text = "Double";
            this.Temp1registerCheckBox.UseVisualStyleBackColor = false;

            // Temp3registerComboBox

            this.Temp3registerComboBox.DropDownHeight = 120;
            this.Temp3registerComboBox.FormattingEnabled = true;
            this.Temp3registerComboBox.IntegralHeight = false;
            this.Temp3registerComboBox.Location = new System.Drawing.Point(55, 140);
            this.Temp3registerComboBox.Name = "Temp3registerComboBox";
            this.Temp3registerComboBox.Size = new System.Drawing.Size(44, 21);
            this.Temp3registerComboBox.TabIndex = 9;

            // Temp2registerComboBox

            this.Temp2registerComboBox.DropDownHeight = 120;
            this.Temp2registerComboBox.FormattingEnabled = true;
            this.Temp2registerComboBox.IntegralHeight = false;
            this.Temp2registerComboBox.Location = new System.Drawing.Point(55, 80);
            this.Temp2registerComboBox.Name = "Temp2registerComboBox";
            this.Temp2registerComboBox.Size = new System.Drawing.Size(44, 21);
            this.Temp2registerComboBox.TabIndex = 8;

            // Temp1registerComboBox

            this.Temp1registerComboBox.DropDownHeight = 120;
            this.Temp1registerComboBox.FormattingEnabled = true;
            this.Temp1registerComboBox.IntegralHeight = false;
            this.Temp1registerComboBox.Location = new System.Drawing.Point(55, 20);
            this.Temp1registerComboBox.Name = "Temp1registerComboBox";
            this.Temp1registerComboBox.Size = new System.Drawing.Size(44, 21);
            this.Temp1registerComboBox.TabIndex = 5;

            // Temp3registerLabel

            this.Temp3registerLabel.AutoSize = true;
            this.Temp3registerLabel.Location = new System.Drawing.Point(8, 145);
            this.Temp3registerLabel.Name = "Temp3registerLabel";
            this.Temp3registerLabel.Size = new System.Drawing.Size(40, 13);
            this.Temp3registerLabel.TabIndex = 7;
            this.Temp3registerLabel.Text = "Temp3";

            // Temp2registerLabel

            this.Temp2registerLabel.AutoSize = true;
            this.Temp2registerLabel.BackColor = System.Drawing.Color.Transparent;
            this.Temp2registerLabel.Location = new System.Drawing.Point(8, 85);
            this.Temp2registerLabel.Name = "Temp2registerLabel";
            this.Temp2registerLabel.Size = new System.Drawing.Size(40, 13);
            this.Temp2registerLabel.TabIndex = 6;
            this.Temp2registerLabel.Text = "Temp2";

            // Temp1registerLabel

            this.Temp1registerLabel.AutoSize = true;
            this.Temp1registerLabel.BackColor = System.Drawing.Color.Transparent;
            this.Temp1registerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Temp1registerLabel.Location = new System.Drawing.Point(8, 25);
            this.Temp1registerLabel.Name = "Temp1registerLabel";
            this.Temp1registerLabel.Size = new System.Drawing.Size(40, 13);
            this.Temp1registerLabel.TabIndex = 4;
            this.Temp1registerLabel.Text = "Temp1";

            // SettingsComboBox

            this.SettingsComboBox.FormattingEnabled = true;
            //this.SettingsComboBox.Items.AddRange(new object[] {});
            this.SettingsComboBox.Location = new System.Drawing.Point(156, 309);
            this.SettingsComboBox.Name = "SettingsComboBox";
            this.SettingsComboBox.Size = new System.Drawing.Size(166, 21);
            this.SettingsComboBox.TabIndex = 2;
            this.SettingsComboBox.SelectedIndexChanged += new System.EventHandler(this.SettingsComboBox_SelectedIndexChanged);
 
            // groupBoxLaptop

            this.groupBoxLaptop.Controls.Add(this.LaptopPictureBox);
            this.groupBoxLaptop.Location = new System.Drawing.Point(156, 171);
            this.groupBoxLaptop.Name = "groupBoxLaptop";
            this.groupBoxLaptop.Size = new System.Drawing.Size(120, 125);
            this.groupBoxLaptop.TabIndex = 3;
            this.groupBoxLaptop.TabStop = false;

            // LaptopPictureBox

            this.LaptopPictureBox.Location = new System.Drawing.Point(6, 10);
            this.LaptopPictureBox.Name = "LaptopPictureBox";
            this.LaptopPictureBox.Size = new System.Drawing.Size(108, 109);
            this.LaptopPictureBox.TabIndex = 0;
            this.LaptopPictureBox.TabStop = false;

            // ReadingsTabPage

            this.ReadingsTabPage.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReadingsTabPage.Controls.Add(this.Temp2ProgressBar);
            this.ReadingsTabPage.Controls.Add(this.Fan2CGroupBox);
            this.ReadingsTabPage.Controls.Add(this.Fan2speedProgressBar);
            this.ReadingsTabPage.Controls.Add(this.Temp1ProgressBar);
            this.ReadingsTabPage.Controls.Add(this.Fan1speedProgressBar);
            this.ReadingsTabPage.Controls.Add(this.BatteryProgressBar);
            this.ReadingsTabPage.Controls.Add(this.ReadingsApplyButton);
            this.ReadingsTabPage.Controls.Add(this.Fan1CGroupBox);
            this.ReadingsTabPage.Controls.Add(this.BatteryListBox);
            this.ReadingsTabPage.Controls.Add(this.ReadingsDisplayRichTextBox);
            this.ReadingsTabPage.Controls.Add(this.TemperatureListBox);
            this.ReadingsTabPage.Controls.Add(this.FanSpeedListBox);
            this.ReadingsTabPage.Controls.Add(this.ReadingRefreshGroupBox);
            this.ReadingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.ReadingsTabPage.Name = "ReadingsTabPage";
            this.ReadingsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ReadingsTabPage.Size = new System.Drawing.Size(431, 348);
            this.ReadingsTabPage.TabIndex = 0;
            this.ReadingsTabPage.Text = "Readings";

            // Temp2ProgressBar
 
            this.Temp2ProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Temp2ProgressBar.Location = new System.Drawing.Point(316, 115);
            this.Temp2ProgressBar.Name = "Temp2ProgressBar";
            this.Temp2ProgressBar.Size = new System.Drawing.Size(88, 11);
            this.Temp2ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Temp2ProgressBar.TabIndex = 17;
 
            // Fan2CGroupBox

            this.Fan2CGroupBox.Controls.Add(this.SetSpeedFan2CTrackBar);
            this.Fan2CGroupBox.Location = new System.Drawing.Point(351, 228);
            this.Fan2CGroupBox.Name = "Fan2CGroupBox";
            this.Fan2CGroupBox.Size = new System.Drawing.Size(58, 94);
            this.Fan2CGroupBox.TabIndex = 16;
            this.Fan2CGroupBox.TabStop = false;
            this.Fan2CGroupBox.Text = "Fan2";

            // SetSpeedFan2CTrackBar

            this.SetSpeedFan2CTrackBar.Enabled = false;
            this.SetSpeedFan2CTrackBar.Location = new System.Drawing.Point(6, 19);
            this.SetSpeedFan2CTrackBar.Maximum = 4;
            this.SetSpeedFan2CTrackBar.Name = "SetSpeedFan2CTrackBar";
            this.SetSpeedFan2CTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SetSpeedFan2CTrackBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.SetSpeedFan2CTrackBar.Size = new System.Drawing.Size(45, 65);
            this.SetSpeedFan2CTrackBar.TabIndex = 0;
            this.SetSpeedFan2CTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;

            // Fan2speedProgressBar

            this.Fan2speedProgressBar.Location = new System.Drawing.Point(123, 115);
            this.Fan2speedProgressBar.Maximum = 5000;
            this.Fan2speedProgressBar.Name = "Fan2speedProgressBar";
            this.Fan2speedProgressBar.Size = new System.Drawing.Size(88, 11);
            this.Fan2speedProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Fan2speedProgressBar.TabIndex = 15;

            // Temp1ProgressBar

            this.Temp1ProgressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Temp1ProgressBar.Location = new System.Drawing.Point(218, 115);
            this.Temp1ProgressBar.Name = "Temp1ProgressBar";
            this.Temp1ProgressBar.Size = new System.Drawing.Size(88, 11);
            this.Temp1ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Temp1ProgressBar.TabIndex = 14;

            // Fan1speedProgressBar

            this.Fan1speedProgressBar.Location = new System.Drawing.Point(26, 115);
            this.Fan1speedProgressBar.Maximum = 5000;
            this.Fan1speedProgressBar.Name = "Fan1speedProgressBar";
            this.Fan1speedProgressBar.Size = new System.Drawing.Size(88, 11);
            this.Fan1speedProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.Fan1speedProgressBar.TabIndex = 13;

            // BatteryProgressBar

            this.BatteryProgressBar.BackColor = System.Drawing.Color.White;
            this.BatteryProgressBar.Location = new System.Drawing.Point(26, 231);
            this.BatteryProgressBar.Maximum = 4800;
            this.BatteryProgressBar.Name = "BatteryProgressBar";
            this.BatteryProgressBar.Size = new System.Drawing.Size(187, 11);
            this.BatteryProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.BatteryProgressBar.TabIndex = 12;

            // ReadingsApplyButton

            this.ReadingsApplyButton.Enabled = false;
            this.ReadingsApplyButton.Location = new System.Drawing.Point(331, 67);
            this.ReadingsApplyButton.Name = "ReadingsApplyButton";
            this.ReadingsApplyButton.Size = new System.Drawing.Size(73, 27);
            this.ReadingsApplyButton.TabIndex = 11;
            this.ReadingsApplyButton.Text = "Apply";
            this.ReadingsApplyButton.UseVisualStyleBackColor = true;
            this.ReadingsApplyButton.Click += new System.EventHandler(this.ReadingsApplyButton_Click);

            // Fan1CGroupBox

            this.Fan1CGroupBox.Controls.Add(this.SetSpeedFan1CTrackBar);
            this.Fan1CGroupBox.Location = new System.Drawing.Point(284, 228);
            this.Fan1CGroupBox.Name = "Fan1CGroupBox";
            this.Fan1CGroupBox.Size = new System.Drawing.Size(58, 94);
            this.Fan1CGroupBox.TabIndex = 10;
            this.Fan1CGroupBox.TabStop = false;
            this.Fan1CGroupBox.Text = "Fan1";

            // SetSpeedFan1CTrackBar

            this.SetSpeedFan1CTrackBar.Enabled = false;
            this.SetSpeedFan1CTrackBar.LargeChange = 1;
            this.SetSpeedFan1CTrackBar.Location = new System.Drawing.Point(6, 19);
            this.SetSpeedFan1CTrackBar.Maximum = 5;
            this.SetSpeedFan1CTrackBar.Name = "SetSpeedFan1CTrackBar";
            this.SetSpeedFan1CTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.SetSpeedFan1CTrackBar.Size = new System.Drawing.Size(45, 65);
            this.SetSpeedFan1CTrackBar.TabIndex = 0;
            this.SetSpeedFan1CTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;

            // BatteryListBox

            this.BatteryListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BatteryListBox.FormattingEnabled = true;
            this.BatteryListBox.ItemHeight = 14;
            this.BatteryListBox.Location = new System.Drawing.Point(26, 248);
            this.BatteryListBox.Name = "BatteryListBox";
            this.BatteryListBox.Size = new System.Drawing.Size(187, 74);
            this.BatteryListBox.TabIndex = 7;

            // ReadingsDisplayRichTextBox

            this.ReadingsDisplayRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ReadingsDisplayRichTextBox.Location = new System.Drawing.Point(26, 22);
            this.ReadingsDisplayRichTextBox.Name = "ReadingsDisplayRichTextBox";
            this.ReadingsDisplayRichTextBox.Size = new System.Drawing.Size(285, 72);
            this.ReadingsDisplayRichTextBox.TabIndex = 4;
            this.ReadingsDisplayRichTextBox.Text = "";

            // TemperatureListBox

            this.TemperatureListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TemperatureListBox.FormattingEnabled = true;
            this.TemperatureListBox.ItemHeight = 14;
            this.TemperatureListBox.Location = new System.Drawing.Point(219, 132);
            this.TemperatureListBox.Name = "TemperatureListBox";
            this.TemperatureListBox.Size = new System.Drawing.Size(185, 74);
            this.TemperatureListBox.TabIndex = 1;

            // FanSpeedListBox

            this.FanSpeedListBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FanSpeedListBox.FormattingEnabled = true;
            this.FanSpeedListBox.ItemHeight = 14;
            this.FanSpeedListBox.Location = new System.Drawing.Point(26, 132);
            this.FanSpeedListBox.Name = "FanSpeedListBox";
            this.FanSpeedListBox.Size = new System.Drawing.Size(185, 74);
            this.FanSpeedListBox.TabIndex = 0;

            // ReadingRefreshGroupBox

            this.ReadingRefreshGroupBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReadingRefreshGroupBox.Controls.Add(this.ReadingRefreshTrackBar);
            this.ReadingRefreshGroupBox.Location = new System.Drawing.Point(219, 228);
            this.ReadingRefreshGroupBox.Name = "ReadingRefreshGroupBox";
            this.ReadingRefreshGroupBox.Size = new System.Drawing.Size(58, 94);
            this.ReadingRefreshGroupBox.TabIndex = 9;
            this.ReadingRefreshGroupBox.TabStop = false;
            this.ReadingRefreshGroupBox.Text = "Refresh";

            // ReadingRefreshTrackBar

            this.ReadingRefreshTrackBar.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ReadingRefreshTrackBar.LargeChange = 1;
            this.ReadingRefreshTrackBar.Location = new System.Drawing.Point(6, 19);
            this.ReadingRefreshTrackBar.Maximum = 5;
            this.ReadingRefreshTrackBar.Name = "ReadingRefreshTrackBar";
            this.ReadingRefreshTrackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.ReadingRefreshTrackBar.Size = new System.Drawing.Size(45, 65);
            this.ReadingRefreshTrackBar.TabIndex = 8;
            this.ReadingRefreshTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ReadingRefreshTrackBar.Value = 2;
            this.ReadingRefreshTrackBar.Scroll += new System.EventHandler(this.trackBar2_Scroll);

            // MaintabControl

            this.MaintabControl.Controls.Add(this.ReadingsTabPage);
            this.MaintabControl.Controls.Add(this.SettingsTabPage);
            this.MaintabControl.Controls.Add(this.ECTabPage);
            this.MaintabControl.Controls.Add(this.HelpTabPage);
            this.MaintabControl.Location = new System.Drawing.Point(12, 12);
            this.MaintabControl.Name = "MaintabControl";
            this.MaintabControl.SelectedIndex = 0;
            this.MaintabControl.Size = new System.Drawing.Size(439, 368);
            this.MaintabControl.TabIndex = 7;

            // ECExplorerForm

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 412);
            this.ControlBox = false;
            this.Controls.Add(this.MaintabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ECExplorerForm";
            this.Text = "EC Explorer";

	//Layout section

            this.HelpTabPage.ResumeLayout(false);
            this.ECTabPage.ResumeLayout(false);
            this.ECTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ECTableRefreshTrackBar)).EndInit();
            this.SettingsTabPage.ResumeLayout(false);
            this.groupBoxBat.ResumeLayout(false);
            this.groupBoxBat.PerformLayout();
            this.groupBoxFan.ResumeLayout(false);
            this.groupBoxFan.PerformLayout();
            this.groupBoxTemp.ResumeLayout(false);
            this.groupBoxTemp.PerformLayout();
            this.groupBoxLaptop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LaptopPictureBox)).EndInit();
            this.ReadingsTabPage.ResumeLayout(false);
            this.Fan2CGroupBox.ResumeLayout(false);
            this.Fan2CGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetSpeedFan2CTrackBar)).EndInit();
            this.Fan1CGroupBox.ResumeLayout(false);
            this.Fan1CGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SetSpeedFan1CTrackBar)).EndInit();
            this.ReadingRefreshGroupBox.ResumeLayout(false);
            this.ReadingRefreshGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReadingRefreshTrackBar)).EndInit();
            this.MaintabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

	// Objects

        private System.Windows.Forms.Timer ReadingTimer;
        private System.Windows.Forms.Timer ECTableTimer;

        private System.Windows.Forms.TabPage HelpTabPage;
        private System.Windows.Forms.TabPage ECTabPage;
        private System.Windows.Forms.TabPage SettingsTabPage;
        private System.Windows.Forms.TabPage ReadingsTabPage;

        private System.Windows.Forms.RichTextBox HelpRichTextBox;
        private System.Windows.Forms.RichTextBox ReadingsDisplayRichTextBox;

        private System.Windows.Forms.GroupBox groupBoxBat;
        private System.Windows.Forms.GroupBox groupBoxFan;
        private System.Windows.Forms.GroupBox groupBoxTemp;
        private System.Windows.Forms.GroupBox groupBoxLaptop;
        private System.Windows.Forms.GroupBox Fan1CGroupBox;
        private System.Windows.Forms.GroupBox Fan2CGroupBox;
        private System.Windows.Forms.GroupBox ReadingRefreshGroupBox;

        private System.Windows.Forms.Button QuitButton;
        private System.Windows.Forms.Button UnloadButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button ECTableUpdateButton;
        private System.Windows.Forms.Button SettingSaveButton;
        private System.Windows.Forms.Button SettingsApplyButton;
        private System.Windows.Forms.Button ReadingsApplyButton;

        private System.Windows.Forms.TrackBar ECTableRefreshTrackBar;
        private System.Windows.Forms.TrackBar SetSpeedFan1CTrackBar;
        private System.Windows.Forms.TrackBar SetSpeedFan2CTrackBar;
        private System.Windows.Forms.TrackBar ReadingRefreshTrackBar;

        private System.Windows.Forms.ListBox ECTableListBox;
        private System.Windows.Forms.ListBox BatteryListBox;
        private System.Windows.Forms.ListBox TemperatureListBox;
        private System.Windows.Forms.ListBox FanSpeedListBox;

        private System.Windows.Forms.Label BatAMregisterLabel;
        private System.Windows.Forms.Label BatADregisterLabel;
        private System.Windows.Forms.Label BatAregisterLabel;
        private System.Windows.Forms.Label BatVregisterLabel;
        private System.Windows.Forms.Label Fan2registerLabel;
        private System.Windows.Forms.Label Fan1registerLlabel;
        private System.Windows.Forms.Label Temp3registerLabel;
        private System.Windows.Forms.Label Temp2registerLabel;
        private System.Windows.Forms.Label Temp1registerLabel;

        private System.Windows.Forms.CheckBox BatAMregisterCheckBox;
        private System.Windows.Forms.CheckBox BatADregisterCheckBox;
        private System.Windows.Forms.CheckBox BatAregisterCheckBox;
        private System.Windows.Forms.CheckBox BatVregisterCheckBox;
        private System.Windows.Forms.CheckBox Fan2registerCheckBox;
        private System.Windows.Forms.CheckBox Fan1registerCheckBox;
        private System.Windows.Forms.CheckBox Temp3registerCheckBox;
        private System.Windows.Forms.CheckBox Temp2registerCheckBox;
        private System.Windows.Forms.CheckBox Temp1registerCheckBox;

        private System.Windows.Forms.ComboBox Temp3registerComboBox;
        private System.Windows.Forms.ComboBox Temp2registerComboBox;
        private System.Windows.Forms.ComboBox Temp1registerComboBox;
        private System.Windows.Forms.ComboBox BatAMregisterComboBox;
        private System.Windows.Forms.ComboBox BatADregisterComboBox;
        private System.Windows.Forms.ComboBox BatAregisterComboBox;
        private System.Windows.Forms.ComboBox BatVregisterComboBox;
        private System.Windows.Forms.ComboBox Fan2registerComboBox;
        private System.Windows.Forms.ComboBox Fan1registerComboBox;
        private System.Windows.Forms.ComboBox SettingsComboBox;

        private System.Windows.Forms.PictureBox LaptopPictureBox;

        private System.Windows.Forms.ProgressBar Temp1ProgressBar;
        private System.Windows.Forms.ProgressBar Temp2ProgressBar;
        private System.Windows.Forms.ProgressBar Fan1speedProgressBar;
        private System.Windows.Forms.ProgressBar Fan2speedProgressBar;
        private System.Windows.Forms.ProgressBar BatteryProgressBar;

        private System.Windows.Forms.TabControl MaintabControl;

    }

}

