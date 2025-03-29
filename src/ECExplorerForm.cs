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




using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenHardwareMonitor.Hardware;



namespace ECExplorerFormsApp
{

    /// <summary>
    /// Define the public partial class ECExplorerForm
    /// </summary>

    public partial class ECExplorerForm : Form
    {

        // Here are stored the register number for temperatures
        int Temp1 = 0, Temp2 = 0, Temp3 = 0, Temp4 = 0, Temp5 = 0, Temp6 = 0;

        // Here are stored the register number for get fan speed
        int Fan1 = 0, Fan2 = 0;

        // Here are stored the register number for battery
        int BatV = 0, BatA = 0, BatAM = 0, BatAD = 0;

        // Here are stored the register number for set fan speed
        int Fan1C = 0, Fan2C = 0;


        // Here are stored the byte/word setting for temperatures
        int Temp1_reg_double = 0, Temp2_reg_double = 0, Temp3_reg_double = 0;
        int Temp4_reg_double = 0, Temp5_reg_double = 0, Temp6_reg_double = 0;

        // Here are stored the byte/word setting for get fan speed
        int Fan1_reg_double = 1, Fan2_reg_double = 1;



        bool BatPresent = false;

        const string RegPathForEC   = @"SOFTWARE\Andrew McGregor Productions\EC Explorer";
        const string RegPathForCPU  = @"HARDWARE\DESCRIPTION\System\CentralProcessor\0";
        const string RegPathForSYS  = @"HARDWARE\DESCRIPTION\System";

        Computer comp;


        enum ECmodels : int
        {
            Custom = 0x00,
            Acer_Travelmate_4000,
            Asus_F3JC,
            Fujitsu_Siemens_AmiloD,
            Sony_Vaio_VGN_FE31B,
            Sony_Vaio_VGN_CS21S,
            Sony_Vaio_VGN_NW21MF,
            Notebook_Computer_Clevo_D400E,
            HP_Pavilion_ZD8000,
            HP_Compaq_NX9010,
            HP_Pavilion_DV5000,
            HP_Compaq_Evo_N1020,
            Toshiba_Satellite_SA60
        }

        // Here are stored the model number for selected PC
        ECmodels LaptopModel = ECmodels.Custom;

        /// <summary>
        /// Initialize everything
        /// </summary>
        public ECExplorerForm()
        {

            InitializeComponent();
            InitializeComputer();
            InitializeTools();
            InitializeInfo();
            InitializeHelp();

        }


        private void InitializeInfo()
        {
            string s = "";
            int i = 0;
            RegistryKey key, mainkey;
            object o;

            ReadingsDisplayRichTextBox.AppendText("System found\n");

            using (key = Registry.LocalMachine.OpenSubKey(RegPathForSYS))
            {
                s = (string)key.GetValue("Identifier") + "\n";
                ReadingsDisplayRichTextBox.AppendText(s);
            }

            using (key = Registry.LocalMachine.OpenSubKey(RegPathForSYS))
            {
                o = key.GetValue("SystemBiosVersion");
                s = string.Join("\n", (string[])o) + "\n";
                ReadingsDisplayRichTextBox.AppendText(s);
            }


            using (key = Registry.LocalMachine.OpenSubKey(RegPathForCPU))
            {
                s = (string)key.GetValue("ProcessorNameString") + "\n";
                ReadingsDisplayRichTextBox.AppendText(s);
            }



            using (mainkey = Registry.CurrentUser.OpenSubKey(RegPathForEC, true))
            {
                if (mainkey == null)
                {
                    using (key = Registry.CurrentUser.CreateSubKey(RegPathForEC))
                        if (key != null)
                        {
                            key.SetValue("Fan1", 0);
                            key.SetValue("Fan2", 0);
                            key.SetValue("Temp1", 0);
                            key.SetValue("Temp2", 0);
                            key.SetValue("Temp3", 0);
                            key.SetValue("Temp4", 0);
                            key.SetValue("Temp5", 0);
                            key.SetValue("Temp6", 0);
                            key.SetValue("BatV", 0);
                            key.SetValue("BatA", 0);
                            key.SetValue("BatAM", 0);
                            key.SetValue("BatAD", 0);
                            key.SetValue("Model", 0);
                            key.SetValue("installed", 0);
                            key.SetValue("Temp1_reg_double", 0);
                            key.SetValue("Temp2_reg_double", 0);
                            key.SetValue("Temp3_reg_double", 0);
                            key.SetValue("Temp4_reg_double", 0);
                            key.SetValue("Temp5_reg_double", 0);
                            key.SetValue("Temp6_reg_double", 0);
                            key.SetValue("Fan1_reg_double", 0);
                            key.SetValue("Fan2_reg_double", 0);
                        }

                }
            }

            using (key = Registry.CurrentUser.OpenSubKey(RegPathForEC))
            {

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Fan1");
                if (i > 0)
                {
                    Fan1registerComboBox.SelectedIndex = i;
                    Fan1 = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Fan2");
                if (i > 0)
                {
                    Fan2registerComboBox.SelectedIndex = i;
                    Fan2 = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Temp1");
                if (i > 0)
                {
                    Temp1registerComboBox.SelectedIndex = i;
                    Temp1 = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Temp2");
                if (i > 0)
                {
                    Temp2registerComboBox.SelectedIndex = i;
                    Temp2 = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Temp3");
                if (i > 0)
                {
                    Temp3registerComboBox.SelectedIndex = i;
                    Temp3 = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("BatV");
                if (i > 0)
                {
                    BatVregisterComboBox.SelectedIndex = i;
                    BatV = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("BatA");
                if (i > 0)
                {
                    BatAregisterComboBox.SelectedIndex = i;
                    BatA = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("BatAM");
                if (i > 0)
                {
                    BatAMregisterComboBox.SelectedIndex = i;
                    BatAM = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("BatAD");
                if (i > 0)
                {
                    BatADregisterComboBox.SelectedIndex = i;
                    BatAD = i;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Model");
                if (i >= 0)
                {
                    SettingsComboBox.SelectedIndex = i;
                    LaptopModel = (ECmodels)i;
                    SaveComboboxIntoLocalVarsAndInitialize();
                    SetFanSpeedChanges();
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("installed");

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Fan1_reg_double");
                if (i > 0)
                {
                    Fan1registerCheckBox.Checked = true;
                    Fan1_reg_double = 1;
                }
                else
                {
                    Fan1registerCheckBox.Checked = false;
                    Fan1_reg_double = 0;
                }

                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Fan2_reg_double");
                if (i > 0)
                {
                    Fan2registerCheckBox.Checked = true;
                    Fan2_reg_double = 1;
                }
                else
                {
                    Fan2registerCheckBox.Checked = false;
                    Fan2_reg_double = 0;
                }


                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Temp1_reg_double");
                if (i > 0)
                {
                    Temp1registerCheckBox.Checked = true;
                    Temp1_reg_double = 1;
                }
                else
                {
                    Temp1registerCheckBox.Checked = false;
                    Temp1_reg_double = 0;
                }


                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Temp2_reg_double");
                if (i > 0)
                {
                    Temp2registerCheckBox.Checked = true;
                    Temp2_reg_double = 1;
                }
                else
                {
                    Temp2registerCheckBox.Checked = false;
                    Temp2_reg_double = 0;
                }


                i = 0;
                if (key != null)
                    i = (int)key.GetValue("Temp3_reg_double");
                if (i > 0)
                {
                    Temp3registerCheckBox.Checked = true;
                    Temp3_reg_double = 1;
                }
                else
                {
                    Temp3registerCheckBox.Checked = false;
                    Temp3_reg_double = 0;
                }

                ReadingsDisplayRichTextBox.AppendText(s);
            }

        }



        //Save settings into register
        private void SettingSaveButton_Click(object sender, EventArgs e)
        {
            string s = "";
            RegistryKey key;


            using (key = Registry.CurrentUser.OpenSubKey(RegPathForEC, true))
            {
                if (key != null)
                {
                    key.SetValue("Model", (int)LaptopModel);

                    key.SetValue("Fan1",  this.Fan1);
                    key.SetValue("Fan2",  this.Fan2);
                    key.SetValue("Temp1", this.Temp1);
                    key.SetValue("Temp2", this.Temp2);
                    key.SetValue("Temp3", this.Temp3);
                    key.SetValue("Temp4", this.Temp4);
                    key.SetValue("Temp5", this.Temp5);
                    key.SetValue("Temp6", this.Temp6);
                    key.SetValue("BatA",  this.BatA);
                    key.SetValue("BatV",  this.BatV);
                    key.SetValue("BatAM", this.BatAM);
                    key.SetValue("BatAD", this.BatAD);

                    key.SetValue("Fan1_reg_double", this.Fan1_reg_double);
                    key.SetValue("Fan2_reg_double", this.Fan2_reg_double);
                    key.SetValue("Temp1_reg_double", this.Temp1_reg_double);
                    key.SetValue("Temp2_reg_double", this.Temp2_reg_double);
                    key.SetValue("Temp3_reg_double", this.Temp3_reg_double);
                    key.SetValue("Temp4_reg_double", this.Temp4_reg_double);
                    key.SetValue("Temp5_reg_double", this.Temp5_reg_double);
                    key.SetValue("Temp6_reg_double", this.Temp6_reg_double);
                }

                SettingSaveButton.Enabled = false;

                s = SettingsComboBox.SelectedText + "Setting saved into register\n";

                ReadingsDisplayRichTextBox.AppendText(s);

            }

        }





        private void InitializeHelp()
        {
            HelpRichTextBox.AppendText("HELP SYSTEM\n\n");
            HelpRichTextBox.AppendText("REQUIREMENTS\n\n");
            HelpRichTextBox.AppendText("EC Explorer requires Microsoft(TM) .NET Framework 4\n");
            HelpRichTextBox.AppendText("client in order to work. Be sure to have it installed.\n\n");

            HelpRichTextBox.AppendText("BLACK LIST\n\n");
            HelpRichTextBox.AppendText("Some laptops seem to be non fully compatible. Acer \n");
            HelpRichTextBox.AppendText("Travelmate 4000/4100 freezes when reading the EC table.\n\n");

            HelpRichTextBox.AppendText("HOW TO START\n\n");
            HelpRichTextBox.AppendText("In the Settings tab select your laptop model. \n");
            HelpRichTextBox.AppendText("Then click on Apply to confirm your choice. \n");
            HelpRichTextBox.AppendText("In the Readings tab you should see your laptop \n");
            HelpRichTextBox.AppendText("data (temps, fan speeds, battery charge...).\n");

            HelpRichTextBox.AppendText("If your laptop in unlisted, select --Custom values--\n");
            HelpRichTextBox.AppendText("then open the EC Table tab and press on Update or\n");
            HelpRichTextBox.AppendText("move the bottom bar on the right until the EC Table\n");
            HelpRichTextBox.AppendText("is displayed. Locate the value your are interested\n");
            HelpRichTextBox.AppendText("for and sum the row number and the column number.\n");
            HelpRichTextBox.AppendText("Then report it in the Settings tab on the\n");       
            HelpRichTextBox.AppendText("appropriate listbox. If the value is contained in\n");
            HelpRichTextBox.AppendText("two consecutive column, check the Double checkbox.\n");
            HelpRichTextBox.AppendText("Confirm by pressing on Apply. In the Readings tab \n");
            HelpRichTextBox.AppendText("you should see your laptop data (temps, fan \n");
            HelpRichTextBox.AppendText("speeds, battery charge...). You may save your\n");
            HelpRichTextBox.AppendText("choice by clicking on Save in the Settings tab.\n\n");

            ReadingsDisplayRichTextBox.AppendText("Help tools started.\nSystem ready.\n");
            ReadingsDisplayRichTextBox.AppendText("Awaiting orders...\n");
        }


        private void InitializeTools()
        {
            int i = 0;
            string s;

            SettingsComboBox.Items.Clear();
            SettingsComboBox.Items.Add(" -- Custom values --");
            SettingsComboBox.Items.Add("Acer Travelmate 4000/4100");
            SettingsComboBox.Items.Add("Asus F3JC");
            SettingsComboBox.Items.Add("Fujitsu Siemens Amilo D");
            SettingsComboBox.Items.Add("Sony Vaio VGN FE31B");
            SettingsComboBox.Items.Add("Sony Vaio VGN CS21S");
            SettingsComboBox.Items.Add("Sony Vaio VGN NW21MF");
            SettingsComboBox.Items.Add("Notebook Computer Clevo D400E");
            SettingsComboBox.Items.Add("HP Pavilion ZD 8000");
            SettingsComboBox.Items.Add("HP Compaq NX9010");
            SettingsComboBox.Items.Add("HP Pavilion DV 5000");
            SettingsComboBox.Items.Add("HP Compaq Evo N1020");
            SettingsComboBox.Items.Add("Toshiba Satellite SA60");

            // add register number
            Temp1registerComboBox.Items.Clear();
            Temp2registerComboBox.Items.Clear();
            Temp3registerComboBox.Items.Clear();

            Fan1registerComboBox.Items.Clear();
            Fan2registerComboBox.Items.Clear();

            BatVregisterComboBox.Items.Clear();
            BatAregisterComboBox.Items.Clear();
            BatAMregisterComboBox.Items.Clear();
            BatADregisterComboBox.Items.Clear();

            for (i=0; i<256; i++)
            {
                s = i.ToString();
                Temp1registerComboBox.Items.Add(s);
                Temp2registerComboBox.Items.Add(s);
                Temp3registerComboBox.Items.Add(s);

                Fan1registerComboBox.Items.Add(s);
                Fan2registerComboBox.Items.Add(s);

                BatVregisterComboBox.Items.Add(s);
                BatAregisterComboBox.Items.Add(s);
                BatAMregisterComboBox.Items.Add(s);
                BatADregisterComboBox.Items.Add(s);

            }

            ReadingsDisplayRichTextBox.AppendText("All tools initialized.\n");
        }


        private void InitializeComputer()
        {
            string s;

            comp = new Computer();
            comp.Open();
            comp.CPUEnabled = true;
            comp.GPUEnabled = true;
            comp.MainboardEnabled = true;
            comp.FanControllerEnabled = true;
            comp.RAMEnabled = true;

            s = "Starting basic procedures...\n";

            ReadingsDisplayRichTextBox.AppendText(s);
            ReadingsDisplayRichTextBox.AppendText("All objects initialized.\n");
        }


        //this save all the EC registers combobox selectors values into local 
        //variables for unsupported and set proper values for supported laptop
        private void SettingsApplyButton_Click(object sender, EventArgs e)
        {
                    LaptopModel = (ECmodels)SettingsComboBox.SelectedIndex;
                    SaveComboboxIntoLocalVarsAndInitialize();
                    SettingSaveButton.Enabled = true;
                    SettingsApplyButton.Enabled = false;

        }


	//this save all the EC registers combobox selectors values into local 
	//variables for unsupported and set proper values for supported laptop
        private void SaveComboboxIntoLocalVarsAndInitialize()
        {
                    //code for unsupported laptop...
                    if (this.LaptopModel == ECmodels.Custom)
                    {
                        //enable custom value selection
                        if (Temp1registerComboBox.SelectedIndex >= 0)
                            this.Temp1 = Temp1registerComboBox.SelectedIndex;
                        if (Temp2registerComboBox.SelectedIndex >= 0)
                            this.Temp2 = Temp2registerComboBox.SelectedIndex;
                        if (Temp3registerComboBox.SelectedIndex >= 0)
                            this.Temp3 = Temp3registerComboBox.SelectedIndex;

                        if (Fan1registerComboBox.SelectedIndex >= 0)
                            this.Fan1 = Fan1registerComboBox.SelectedIndex;
                        if (Fan2registerComboBox.SelectedIndex >= 0)
                            this.Fan2 = Fan2registerComboBox.SelectedIndex;

                        if (BatVregisterComboBox.SelectedIndex >= 0)
                            this.BatV = BatVregisterComboBox.SelectedIndex;
                        if (BatAregisterComboBox.SelectedIndex >= 0)
                            this.BatA = BatAregisterComboBox.SelectedIndex;
                        if (BatAMregisterComboBox.SelectedIndex >= 0)
                            this.BatAM = BatAMregisterComboBox.SelectedIndex;
                        if (BatADregisterComboBox.SelectedIndex >= 0)
                            this.BatAD = BatADregisterComboBox.SelectedIndex;

                        if (Temp1registerCheckBox.Checked)
                             this.Temp1_reg_double = 1;
                        else this.Temp1_reg_double = 0;

                        if (Temp2registerCheckBox.Checked)
                             this.Temp2_reg_double = 1;
                        else this.Temp2_reg_double = 0;

                        if (Temp3registerCheckBox.Checked)
                             this.Temp3_reg_double = 1;
                        else this.Temp3_reg_double = 0;

                        if (Fan1registerCheckBox.Checked)
                             this.Fan1_reg_double = 1;
                        else this.Fan1_reg_double = 0;

                        if (Fan2registerCheckBox.Checked)
                             this.Fan2_reg_double = 1;
                        else this.Fan2_reg_double = 0;

                    }
                    //code for Acer Travelmate 4000/4100...
                    else if (LaptopModel == ECmodels.Acer_Travelmate_4000)
                    {
                        this.Temp1 = 88;
                        this.Temp2 = 94;
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;

                        this.Fan1 = 92;
                        this.Fan1_reg_double = 1;
                        Fan1registerCheckBox.Checked = true;

                        this.BatV = 197;
                        this.BatA = 195;
                        this.BatAM = 216;
                        this.BatAD = 220;
                        BatteryProgressBar.Maximum = 5200; //used for mAh measure

                        //allow AC register changes
                        this.Fan1C = 96;
                        SetSpeedFan1CTrackBar.Enabled = true;
                        SetSpeedFan1CTrackBar.Maximum = 1;
                        ReadingsApplyButton.Enabled = true;
                    }
                    //code for Asus F3JC...
                    else if (this.LaptopModel == ECmodels.Asus_F3JC)
                    {
                        this.Temp1 = 166;
                        this.Temp2 = 167;
                        this.Temp6 = 255; // fake for Nvidia Gpu Temp
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        Temp3registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;
                        this.Temp3_reg_double = 0;

                        this.Fan1 = 147;
                        this.Fan1_reg_double = 1;
                        Fan1registerCheckBox.Checked = true;

                        this.BatV = 178;
                        this.BatA = 180;
                        BatteryProgressBar.Maximum = 4800; //used for mAh measure
                    }
                    //code for Fujitsu Siemens Amilo D...
                    else if (this.LaptopModel == ECmodels.Fujitsu_Siemens_AmiloD)
                    {
                        this.Temp1 = 65;
                        this.Temp2 = 66;
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;

                        this.Fan1 = 139;
                        this.Fan1_reg_double = 0;
                        Fan1registerCheckBox.Checked = false;

                        this.BatV = 56;
                        this.BatA = 54;
                        this.BatAD = 2;
                        this.BatAM = 4;
                        BatteryProgressBar.Maximum = 6400; //used for mAh measure

                        //allow AC register changes
                        SetSpeedFan1CTrackBar.Enabled = true;
                        SetSpeedFan1CTrackBar.Maximum = 5;
                        ReadingsApplyButton.Enabled = true;
                    }
                    //code for Sony Vaio VGN FE31B...
                    else if (this.LaptopModel == ECmodels.Sony_Vaio_VGN_FE31B)
                    {
                        this.Temp1 = 64;
                        this.Temp2 = 66;
                        this.Temp5 = 65;
                        this.Temp4 = 67;
                        this.Temp6 = 255; // fake for Nvidia Gpu Temp
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;

                        this.Fan1 = 70;
                        this.Fan1_reg_double = 1;
                        Fan1registerCheckBox.Checked = true;

                        //allow AC register changes
                        this.Fan1C = 92;
                        SetSpeedFan1CTrackBar.Enabled = true;
                        SetSpeedFan1CTrackBar.Maximum = 2;
                        SetSpeedFan1CTrackBar.Value = 1;

                        ReadingsApplyButton.Enabled = true;
                    }
                    //code for Sony Vaio VGN CS21S...
                    else if (this.LaptopModel == ECmodels.Sony_Vaio_VGN_CS21S)
                    {
                        this.Temp1 = 88;
                        this.Temp2 = 84;
                        this.Temp3 = 76;
                        this.Temp6 = 255; // fake for Nvidia Gpu Temp
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        Temp3registerCheckBox.Checked = true;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;
                        this.Temp3_reg_double = 1;

                        this.Fan1 = 102;
                        this.Fan1_reg_double = 1;
                        Fan1registerCheckBox.Checked = true;

                        this.BatV = 74;
                        this.BatA = 72;
                        BatteryProgressBar.Maximum = 4800; //used for mAh measure

                    }
                    //code for Notebook Computer Clevo D400E...
                    else if (this.LaptopModel == ECmodels.Notebook_Computer_Clevo_D400E)
                    {
                        this.Temp1 = 10;
                        this.Temp1_reg_double = 1;
                        Temp1registerCheckBox.Checked = true;
                    }
                    //code for Toshiba Satellite SA60...
                    else if (this.LaptopModel == ECmodels.Toshiba_Satellite_SA60)
                    {
                        this.Temp1 = 156;
                        //this.Temp2 = 158;
                        Temp1registerCheckBox.Checked = false;
                        //Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        //this.Temp2_reg_double = 0;

                        this.Fan1 = 252;
                        this.Fan2 = 253;
                        this.Fan1_reg_double = 0;
                        this.Fan2_reg_double = 0;
                        Fan1registerCheckBox.Checked = false;
                        Fan2registerCheckBox.Checked = false;

                        this.BatV = 255;    //fake reg number
                        this.BatA = 168;
                        this.BatAM = 170;
                        this.BatAD = 172;
                        BatteryProgressBar.Maximum = 6450; //used for mAh measure at reg 172

                        //allow AC register changes
                        this.Fan1C = 160;
                        SetSpeedFan1CTrackBar.Enabled = true;
                        SetSpeedFan1CTrackBar.Maximum = 4;

                        this.Fan2C = 161;
                        SetSpeedFan2CTrackBar.Enabled = true;
                        SetSpeedFan2CTrackBar.Maximum = 1;

                        ReadingsApplyButton.Enabled = true;
                    }
                    //code for HP Pavilion ZD 8000...
                    else if (this.LaptopModel == ECmodels.HP_Pavilion_ZD8000)
                    {
                        this.Temp1 = 88;
                        this.Temp2 = 94;
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;

                        this.Fan1 = 65;
                        this.Fan1_reg_double = 0;
                        Fan1registerCheckBox.Checked = false;

                        this.BatV = 197;
                        this.BatA = 195;
                        BatteryProgressBar.Maximum = 6600; //used for mAh measure
                    }
                    //code for HP Compaq NX9010...
                    else if (this.LaptopModel == ECmodels.HP_Compaq_NX9010)
                    {
                        this.Temp1 = 85;
                        Temp1registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;

                        this.BatV = 92;
                        this.BatA = 90;
                        BatteryProgressBar.Maximum = 4400; //used for mAh measure
                    }

                    //code for HP Pavilion DV 5000...
                    else if (this.LaptopModel == ECmodels.HP_Pavilion_DV5000)
                    {
                        this.Temp1 = 176;
                        this.Temp2 = 177;
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;
                    }

                    //code for HP Compaq Evo N1020...
                    else if (this.LaptopModel == ECmodels.HP_Compaq_Evo_N1020)
                    {
                        this.Temp1 = 219;
                        this.Temp2 = 220;
                        this.Temp3 = 224;
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        Temp3registerCheckBox.Checked = true;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;
                        this.Temp3_reg_double = 1;

                        this.Fan1 = 72;
                        this.Fan1_reg_double = 0;
                        Fan1registerCheckBox.Checked = false;
                        Fan1speedProgressBar.Maximum = 3200;
                        this.Fan2 = 73;
                        this.Fan1_reg_double = 0;
                        Fan2registerCheckBox.Checked = false;
                        Fan2speedProgressBar.Maximum = 3200;

                        this.BatV = 165;
                        this.BatA = 161;
                        this.BatAM = 141;
                        this.BatAD = 137;
                        BatteryProgressBar.Maximum = 4800; //used for mAh measure

                        //allow AC register changes
                        SetSpeedFan1CTrackBar.Enabled = true;
                        SetSpeedFan1CTrackBar.Maximum = 255;
                        SetSpeedFan1CTrackBar.TickFrequency = 32;

                        SetSpeedFan2CTrackBar.Enabled = true;
                        SetSpeedFan2CTrackBar.Maximum = 255;
                        SetSpeedFan2CTrackBar.TickFrequency = 32;

                        ReadingsApplyButton.Enabled = true;

                    }

                    //code for Sony Vaio VGN NW21MF...
                    else if (this.LaptopModel == ECmodels.Sony_Vaio_VGN_NW21MF)
                    {
                        this.Temp1 = 64;
                        this.Temp2 = 66;
                        this.Temp4 = 67;
                        this.Temp5 = 65;
                        Temp1registerCheckBox.Checked = false;
                        Temp2registerCheckBox.Checked = false;
                        this.Temp1_reg_double = 0;
                        this.Temp2_reg_double = 0;

                        this.Fan1 = 70;
                        this.Fan1_reg_double = 1;
                        Fan1registerCheckBox.Checked = true;

                        //allow AC register changes
                        //but here nothing change
                        this.Fan1C = 92;

                    }

                    //code for other supported laptop...
                    else
                    {
                        this.Temp1 = 0;
                        this.Temp2 = 0;
                        this.Temp3 = 0;

                        this.Fan1 = 0;
                        this.Fan2 = 0;

                        this.BatV = 0;
                        this.BatA = 0;
                        this.BatAM = 0;
                        this.BatAD = 0;

                    }

                    //enable save changes into register
                    SettingSaveButton.Enabled = true;


                    ReadingsDisplayRichTextBox.AppendText(SettingsComboBox.Text + " selected.\n");

        }



        //apply fan speed changes for laptops that support this feature
        private void ReadingsApplyButton_Click(object sender, EventArgs e)
        {
                    SetFanSpeedChanges();
        }



        //apply fan speed changes for laptops that support this feature
        private void SetFanSpeedChanges()
        {
                    byte b, c, c1, c2;

                    //code for Fujitsu Siemens Amilo D only...
                    if (LaptopModel == ECmodels.Fujitsu_Siemens_AmiloD)
                    {
                        b = (byte)SetSpeedFan1CTrackBar.Value;
                        SetByteOnEC(138, b);
                    }
                    //code for Acer Travelmate 4000/4100 only...
                    if (LaptopModel == ECmodels.Acer_Travelmate_4000)
                    {
                        b = (byte)SetSpeedFan1CTrackBar.Value;
                        c = (byte)GetByteOrWordFromEC((byte)this.Fan1C, false);
                        c1 = (byte)(c | 2 );   // c OR  00000010
                        c2 = (byte)(c & 253);  // c AND 11111101

                        if (b == 1)
                             SetByteOnEC((byte)this.Fan1C, c1);
                        else SetByteOnEC((byte)this.Fan1C, c2);
                    }
                    //code for  Sony Vaio VGN FE31B only...
                    if (LaptopModel == ECmodels.Sony_Vaio_VGN_FE31B)
                    {
                        b = (byte)SetSpeedFan1CTrackBar.Value;
                        if (b == 1)
                             SetByteOnEC((byte)this.Fan1C, 15);
                        else if (b == 2)
                             SetByteOnEC((byte)this.Fan1C, 11);
                        else SetByteOnEC((byte)this.Fan1C, 0);
                    }
                    //code for  Toshiba Satellite SA60 only...
                    if (LaptopModel == ECmodels.Toshiba_Satellite_SA60)
                    {
                        b = (byte)SetSpeedFan1CTrackBar.Value;
                        SetByteOnEC((byte)this.Fan1C, b);

                        b = (byte)SetSpeedFan2CTrackBar.Value;
                        SetByteOnEC((byte)this.Fan2C, b);
                    }
                    //code for HP Compaq Evo N1020 only...
                    if (LaptopModel == ECmodels.HP_Compaq_Evo_N1020)
                    {
                        b = (byte)SetSpeedFan1CTrackBar.Value;
                        SetByteOnEC(82, b);
                        SetByteOnEC(85, b);
                        SetByteOnEC(88, b);

                        b = (byte)SetSpeedFan2CTrackBar.Value;
                        SetByteOnEC(98, b);
                        SetByteOnEC(101, b);
                        SetByteOnEC(104, b);
                    }


                    ReadingsDisplayRichTextBox.AppendText("Fan speed changed.\n");
        }




        private void QuitButton_Click(object sender, EventArgs e)
        {
                    comp.Close();
                    Close();
        }



        private void LoadButton_Click(object sender, EventArgs e)
        {
                    string s = "-";

                    comp.Open();
                    HelpRichTextBox.AppendText(s);
        }


        private void UnloadButton_Click(object sender, EventArgs e)
        {
                    string s = "-";

                    comp.Close();
                    HelpRichTextBox.AppendText(s);
        }


        private string FormatString(string s)
        {
                    int i;

                    for (i = 0; i < 5; i++)
                        if (s.Length < 5)
                            s = " " + s;
                    return s;
        }



        private void ECTableUpdateButton_Click(object sender, EventArgs e)
        {
                //Acer Travelmate 4000/4100 freezes...
                if (LaptopModel != ECmodels.Acer_Travelmate_4000)
                    GetECTableSlow();
        }



        // this display the EC registers values
        private void GetECTable()
        {
              byte i, j, k, n;
              int h, z;
              string s = "  <o>   000 001 002 003 004 005 006 007 008 009 010 011 012 013 014 015";

              ECTableListBox.Items.Clear();
              ECTableListBox.Items.Add(s);
              ECTableListBox.Items.Add("");

              if (comp.WaitIsaBusMutex(EcTimeout))
              {
                        z = 0;
                        for (j = 0; j < 16; j++)
                        {
                            if (z < 10)
                                s = "  00" + z.ToString() + "   ";
                            else if (z < 100)
                                s = "  0" + z.ToString() + "   ";
                            else s = "  " + z.ToString() + "   ";


                            for (i = 0; i < 16; i++)
                            {
                                h = (ushort)i + (ushort)j * 16;
                                n = (byte)h;
                                z = h + 1;
                                k = ReadByte(n);

                                if (k < 10)
                                    s = s + "00" + k.ToString();
                                else if (k < 100)
                                    s = s + "0" + k.ToString();
                                else s = s + k.ToString();

                                s = s + " ";
                            }

                            ECTableListBox.Items.Add(s);
                        }

                        comp.ReleaseIsaBusMutex();
              }
        }

        // this display the EC registers values
        private void GetECTableSlow()
        {
              byte i, j, k, k1, n;
              int h, z;
              string s = "  <o>   000 001 002 003 004 005 006 007 008 009 010 011 012 013 014 015";

              ECTableListBox.Items.Clear();
              ECTableListBox.Items.Add(s);
              ECTableListBox.Items.Add("");

              z = 0;
              for (j = 0; j < 16; j++)
              {
                        if (z < 10)
                                s = "  00" + z.ToString() + "   ";
                        else if (z < 100)
                                s = "  0" + z.ToString() + "   ";
                        else s = "  " + z.ToString() + "   ";


                        for (i = 0; i < 16; i++)
                        {
                                h = (ushort)i + (ushort)j * 16;
                                n = (byte)h;
                                z = h + 1;

                                k = (byte)GetByteOrWordFromEC(n, false);
                                k1 = (byte)GetByteOrWordFromEC(n, false);

                                //try to correct an error of reading EC in Sony Vaio CS21S                      
                                if (k != k1)
                                    k = (byte)GetByteOrWordFromEC(n, false);

                                if (k < 10)
                                    s = s + "00" + k.ToString();
                                else if (k < 100)
                                    s = s + "0" + k.ToString();
                                else s = s + k.ToString();

                                s = s + " ";

                        }

                        ECTableListBox.Items.Add(s);
              }

        }


        private Color SetColA(int c1, int c2, int c3)
        {
               Color c;

               c = System.Drawing.Color.FromArgb(255, c1, c2, c3);

               return c;
        }


        // this timer refresh the main windows objects
        private void ReadingTimer_Tick(object sender, EventArgs e)
        {
                    string s;
                    int i = 0,  j = 0;
                    long watt = 0;
                    byte b = 0;

                    // this add all fan speeds
                    FanSpeedListBox.Items.Clear();

                    b = (byte)this.Fan1;  // acquire register number to read
                    if (b > 0)
                    {
                        i  = GetByteOrWordFromEC(b, Fan1registerCheckBox.Checked);

                        //correctfan speed x F3J
                        if (LaptopModel == ECmodels.Asus_F3JC)
                            if ((i > 100) && (i < 50000))
                            {
                                j = i / 10;
                                i = (23438 / j)*10;
                            }
                            else i = 0;

                        //correct fan speed x Acer Travelmate 4000/4100...
                        if (LaptopModel == ECmodels.Acer_Travelmate_4000)
                            i = 10 * i;

                        //correct fan speed x Fujitsu Siemens Amilo D...
                        if (LaptopModel == ECmodels.Fujitsu_Siemens_AmiloD)
                            i = 600 * i;

                        //correct fan speed x  Toshiba Satellite SA60...
                        if (LaptopModel == ECmodels.Toshiba_Satellite_SA60)
                            i = 10 * (255 - i);

                        //correct fan speed x HP Compaq Evo N1020...
                        if (LaptopModel == ECmodels.HP_Compaq_Evo_N1020)
                            i = 12 * i;

                        //correct fan speed x HP Pavilion ZD 8000...
                        if (LaptopModel == ECmodels.HP_Pavilion_ZD8000)
                        {
                            //b1 = (byte)i;
                            i = (int)(i & 16);  // b1 AND 00010000
                            i = i * 80;
                        }

                        if ((i <= Fan1speedProgressBar.Maximum) && 
                            (i >= Fan1speedProgressBar.Minimum))
                            Fan1speedProgressBar.Value = i;

                        s = i.ToString();
                        s = FormatString(s);
                        s = "Fan1  " + s + " Rpm";
                        if (i > 0)
                            FanSpeedListBox.Items.Add(s);
                    }

                    b = (byte)this.Fan2;  // acquire register number to read
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, Fan2registerCheckBox.Checked);

                        //correct fan speed x  Toshiba Satellite SA60...
                        if (LaptopModel == ECmodels.Toshiba_Satellite_SA60)
                            i = 10 * (255 - i);

                        //correct fan speed x HP Compaq Evo N1020...
                        if (LaptopModel == ECmodels.HP_Compaq_Evo_N1020)
                            i = 12 * i;

                        if ((i < Fan2speedProgressBar.Maximum) && 
                            (i >= Fan2speedProgressBar.Minimum))
                            Fan2speedProgressBar.Value = i;

                        s = i.ToString();
                        s = FormatString(s);
                        s = "Fan2  " + s + " Rpm";
                        if (i > 0)
                            FanSpeedListBox.Items.Add(s);
                    }


                    // this add all temperarures
                    TemperatureListBox.Items.Clear();

                    b = (byte)this.Temp1;   // acquire register number to read CPU temp

                    if (b > 0)
                    {
                        i  = GetByteOrWordFromEC(b, Temp1registerCheckBox.Checked);

                        //correct temperature x Notebook Computer Clevo D400E which is in Kelvin
                        //if (LaptopModel == ECmodels.Notebook_Computer_Clevo_D400E)
                        if (Temp1registerCheckBox.Checked)
                            i = (i - 2732) / 10;

                        //code for keep cold Sony Vaio VGN FE31B
                        if (LaptopModel == ECmodels.Sony_Vaio_VGN_FE31B)
                        {
                            j = GetByteOrWordFromEC((byte)this.Fan1C, false);

                            if ((i > 50) && (j != 10))
                                SetByteOnEC((byte)this.Fan1C, 11);
                        }

                        if ((i <= Temp1ProgressBar.Maximum) && 
                            (i >= Temp1ProgressBar.Minimum))
                        {
                            Temp1ProgressBar.Value = i;
                            if (i > 46)
                                 Temp1ProgressBar.ForeColor = SetColA(255, 128, 0);
                            else Temp1ProgressBar.ForeColor = SetColA(0, 192, 192);
                        }

                        s = i.ToString();
                        s = "CPU     " + s + " °C";
                        if ((i > 0) && (i < 200))
                            TemperatureListBox.Items.Add(s);
                    }

                    b = (byte)this.Temp2;  // acquire register number to read Board temp
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, Temp2registerCheckBox.Checked);

                        //correct temperature x Notebook Computer Clevo D400E and
			//others which are in Kelvin
                        if (Temp2registerCheckBox.Checked)
                            i = (i - 2732) / 10;

                        if ((i <= Temp2ProgressBar.Maximum) && 
                            (i >= Temp2ProgressBar.Minimum))
                        {
                            Temp2ProgressBar.Value = i;
                            if (i > 44)
                                 Temp2ProgressBar.ForeColor = SetColA(255, 128, 0);
                            else Temp2ProgressBar.ForeColor = SetColA(0, 192, 192);
                        }

                        s = i.ToString();
                        s = "Board   " + s + " °C";
                        if ((i > 0) && (i < 200))
                            TemperatureListBox.Items.Add(s);
                    }

                    b = (byte)this.Temp3;  // acquire register number to read battery temp
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, Temp3registerCheckBox.Checked);

                        //correct temperature x Notebook Computer Clevo D400E, Sony Vaio CS21S 
                        //and Compaq Evo 1020 which are reported in Kelvin
                        if (Temp3registerCheckBox.Checked)
                            i = (i - 2732) / 10;

                        s = i.ToString();
                        s = "Bat     " + s + " °C";
                        if ((i > 0) && (i < 200))
                            TemperatureListBox.Items.Add(s);
                    }

                    b = (byte)this.Temp4;  // acquire register number to read
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, false);

                        if ((i > 200) || (i < 0))
                            i = 0;

                        s = i.ToString();
                        s = "Aux1    " + s + " °C";
                        if ((i > 0) && (i < 200))
                            TemperatureListBox.Items.Add(s);
                    }

                    b = (byte)this.Temp5;  // acquire register number to read
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, false);

                        if ((i > 200) || (i < 0))
                            i = 0;

                        s = i.ToString();
                        s = "Aux2    " + s + " °C";
                        if ((i > 0) && (i < 200))
                            TemperatureListBox.Items.Add(s);
                    }
              
                    b = (byte)this.Temp6;  // acquire register number to read
                    if (b > 0)
                    {
                       i = 0;

                       if ((i > 200) || (i < 0))
                            i = 0;

                       s = i.ToString();
                       s = "GPU     " + s + " °C";
                       if ((i > 0) && (i < 200))
                           TemperatureListBox.Items.Add(s);
                    }

                    // this add all batteries
                    BatteryListBox.Items.Clear();

                    b = (byte)this.BatV; // acquire register number to read
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, BatVregisterCheckBox.Checked);

                        //correct voltage x  Toshiba Satellite SA60...
                        if (LaptopModel == ECmodels.Toshiba_Satellite_SA60)
                            i = 14800;

                        if ((i > 0) && (i < 65535))
                             BatPresent = true;
                        else BatPresent = false;

                        watt = i / 10;

                        s = i.ToString();
                        s = FormatString(s);
                        s = "BatV    " + s + " mV";

                        if (BatPresent)
                           BatteryListBox.Items.Add(s);
                    }

                    b = (byte)this.BatA; // acquire register number to read
                    if (b > 0)
                    {
                        i = GetByteOrWordFromEC(b, BatAregisterCheckBox.Checked);
                        watt = watt * i / 100;

                        if ((i <= BatteryProgressBar.Maximum) && 
                            (i >= BatteryProgressBar.Minimum))
                            BatteryProgressBar.Value = i;

                            s = i.ToString();
                            s = FormatString(s);
                            s = "BatA    " + s + " mAh";

                        if (BatPresent)
                            BatteryListBox.Items.Add(s);
                    }

                    if (watt > 0)
                    {
                        s = watt.ToString();
                        s = FormatString(s);
                        s = "BatC    " + s + " mWh";

                        if (BatPresent)
                            BatteryListBox.Items.Add(s);
                    }


                    b = (byte)this.BatAM; // acquire register number to read
                    if (b > 0)
                    {
                             i = GetByteOrWordFromEC(b, true);

                             s = i.ToString();
                             s = FormatString(s);
                             s = "BatAMax " + s + " mAh";

                        if (BatPresent)
                            BatteryListBox.Items.Add(s);

                        if ((i < BatteryProgressBar.Maximum) && 
                            (i > BatteryProgressBar.Minimum))
                                BatteryProgressBar.Maximum = i;

                    }

                    b = (byte)this.BatAD; // acquire register number to read
                    if (b > 0)
                    {
                            j = GetByteOrWordFromEC(b, BatADregisterCheckBox.Checked);

                            s = j.ToString();
                            s = FormatString(s);
                            s = "BatAOri " + s + " mAh";
                            if (BatPresent)
                              BatteryListBox.Items.Add(s);

                            if (j > 100)
                                j = 100 - i/(j/100);
                            s = j.ToString();
                            s = FormatString(s);
                            s = "BatWL   " + s + " %";
                            if (BatPresent)
                                BatteryListBox.Items.Add(s);

                    }


        }



        // this trackBar control the main windows objects refresh speed
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
                    ReadingTimer.Stop();
                    if (ReadingRefreshTrackBar.Value > 0)
                    {
                        ReadingTimer.Interval = ReadingRefreshTrackBar.Value * 1000;
                        ReadingTimer.Start();
                    }
                    ReadingsDisplayRichTextBox.AppendText("Refresh rate changed.\n");
        }



        //this timer refresh the EC Table
        private void ECTableTimer_Tick(object sender, EventArgs e)
        {
                //Acer Travelmate 4000/4100 freezes...
                if (LaptopModel != ECmodels.Acer_Travelmate_4000)
                    GetECTableSlow();
        }



        // this trackBar control the EC Explorer refresh speed
        private void ECTableRefreshTrackBar_Scroll(object sender, EventArgs e)
        {
                    this.ECTableTimer.Stop();
                    if (ECTableRefreshTrackBar.Value > 0)
                    {
                        ECTableTimer.Interval = ECTableRefreshTrackBar.Value * 1000;
                        ECTableTimer.Start();
                    }
                    ReadingsDisplayRichTextBox.AppendText("Refresh rate changed.\n");
        }



         //this enables all the EC registers combobox selectors
         private void SettingsComboBox_SelectedIndexChanged(object sender, EventArgs e)
         {
                    SettingsApplyButton.Enabled = true;
                    SettingSaveButton.Enabled  = false;


                    groupBoxTemp.Enabled = false;
                    if (SettingsComboBox.SelectedIndex == 0)
                        groupBoxTemp.Enabled = true;

                    groupBoxFan.Enabled = false;
                    if (SettingsComboBox.SelectedIndex == 0)
                        groupBoxFan.Enabled = true;

                    groupBoxBat.Enabled = false;
                    if (SettingsComboBox.SelectedIndex == 0)
                        groupBoxBat.Enabled = true;

                    BatVregisterCheckBox.Enabled  = false;
                    BatAregisterCheckBox.Enabled  = false;
                    BatAMregisterCheckBox.Enabled = false;
                    BatADregisterCheckBox.Enabled = false;

         }





        //++++++++++++++++++++++++++++++++++++++++++++++++++++
        //          code for accessing EC registers
        //++++++++++++++++++++++++++++++++++++++++++++++++++++



                const int MaxReadFailures = 20;
                const int MaxTryAgain = 5;

                int waitReadFailures = 0;



                private void WritePort(int port, byte value)
                {
                        comp.WriteIoPort(port, value);
                }

                private byte ReadPort(int port)
                {
                        return comp.ReadIoPort(port);
                }

                private void ReleaseIsaBusMutex()
                {
                	comp.ReleaseIsaBusMutex();
                }

                private bool WaitIsaBusMutex(int time)
                {
			return comp.WaitIsaBusMutex(time);
                }



                private bool WaitForEcStatus(byte status, bool b)
                {
                    int timeout = 250;
                    byte value;

                    while (timeout > 0)
                    {
			value = ReadPort(0x66);    // Read from Command Port

                        if (b)
                        {
	                        if (((byte)status & (byte)~value) == 0)
					timeout = 0;
                        }
			else
                        {
	                        if (((byte)status & value) == 0)
					timeout = 0;
                        }

                        timeout--;
                    }

		    if (timeout < 0)
                    	 return  true;
                    else return false;
                }


                private bool WaitRead()
                {
                    if (waitReadFailures > MaxReadFailures)
                    {
                        return true;
                    }
                    else if (WaitForEcStatus(0x01, true))  //Output Buffer is full
                    {
                        waitReadFailures = 0;
                        return true;
                    }
                    else
                    {
                        waitReadFailures++;
                        return false;
                    }
                }


                private bool WaitWrite()
                {
                    return WaitForEcStatus(0x02, false);	//Input Buffer is full 
                }


		/// <summary>
		/// Write a Byte to Port
		/// </summary>
                protected bool WriteByteToPort(int dataport, byte register, byte value)
                {
                    if (WaitWrite())
                    {
			WritePort(0x66, 0x81); // Write to Command Port

                        if (WaitWrite())
                        {
			    WritePort(dataport, register);

                            if (WaitWrite())
                            {
				WritePort(dataport, value);
                                return true;
                            }
                        }
                    }

                    return false;
                }

		/// <summary>
		/// Read a Byte from Port
		/// </summary>
                protected bool ReadByteFromPort(int dataport, byte register, out byte value)
                {
                    if (WaitWrite())
                    {
			WritePort(0x66, 0x80);    // Write to Command Port

                        if (WaitWrite())
                        {
			    WritePort(dataport, register);

                            if (WaitWrite() && WaitRead())
                            {
				value = ReadPort(dataport);
                                return true;
                            }
                        }
                    }

                    value = 0;
                    return false;
                }



                private void WriteByte(byte reg, byte value)
                {
                    int c = 0;

                    while (c < MaxTryAgain)
                    {
                        if (WriteByteToPort(0x62, reg, value))
                        {
                            return;
                        }
                        c++;
                    }
                }



                private byte ReadByte(byte reg)
                {
                    byte result = 0;
                    int c = 0;

                    while (c < MaxTryAgain)
                    {
                        if (ReadByteFromPort(0x62, reg, out result))
                        {
                            return result;
                        }

                        c++;
                    }
                    return result;
                }



        const int EcTimeout = 100;


        private int GetByteOrWordFromEC(byte value, bool doublebyte)
        {
            byte b0, b1, b2, b3;
            int i = 0;

            if (WaitIsaBusMutex(EcTimeout))
            {
                b0 = ReadByte(value);
                b3 = ReadByte(value);
                if (b0 != b3)
                    b0 = ReadByte(value);

                i = b0;
                if (doublebyte)
                {
                    value++;
                    b1 = ReadByte(value);
                    b2 = ReadByte(value);
                    if (b1 != b2)
                        b1 = ReadByte(value);

                    i |= (ushort)(b1 << 8);
                }
		ReleaseIsaBusMutex();
            }
            return i;
        }


        private void SetByteOnEC(byte register, byte value)
        {

            if (WaitIsaBusMutex(EcTimeout))
            {
                WriteByte(register, value);
		ReleaseIsaBusMutex();
            }

        }



    }
    // end of public partial class ECExplorerForm : Form



}
// end of namespace ECExplorerFormsApp