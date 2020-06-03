using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace OpenFAC.Library
{

    public class OpenCapConfig : IOpenCapConfig
    {
        OpenFACConfig config;
        OpenFACLayout layout;
        OpenCapKeyboardManager keyboardManager;
        OpenCapActionManager actionManager;
   
        private OpenFACConfig LoadConfig(string FileName)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OpenFACConfig));
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            OpenFACConfig config = new OpenFACConfig();
            config = (OpenFACConfig)js.ReadObject(fs);
            fs.Close();
            return config;
        }

        private OpenFACLayout LoadLayout(string FileName)
        {
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OpenFACLayout));
            FileStream fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
            OpenFACLayout layout = new OpenFACLayout();
            layout = (OpenFACLayout)js.ReadObject(fs);
            fs.Close();
            return layout;
        }

        public string GetActiveSensor()
        {
            return config.ActiveSensor;
        }

        private void GenerateConfigSample()
        {
            OpenFACLayout layout = new OpenFACLayout();
            layout.Engine = "QWERT";
            
            layout.Lines = new List<LayoutLine>();

            LayoutLine li = new LayoutLine();
            li.Buttons = new List<LayoutButton>();
            
            LayoutButton bt = new LayoutButton();
            bt.Action = "Keyboard";
            bt.Caption = "A";
            bt.Text    = "A";

            LayoutButton b2 = new LayoutButton();
            b2.Action = "Keyboard";
            b2.Caption = "B";
            b2.Text = "B";
            
            li.Buttons.Add(bt);
            li.Buttons.Add(b2);

      
            layout.Lines.Add(li);

            LayoutLine l2 = new LayoutLine();
            l2.Buttons = new List<LayoutButton>();
            l2.Buttons.Add(bt);
            l2.Buttons.Add(b2);

            LayoutLine l3 = new LayoutLine();
            l3.Buttons = new List<LayoutButton>();
            l3.Buttons.Add(bt);
            l3.Buttons.Add(b2);

            layout.Lines.Add(l2);
            layout.Lines.Add(l3);

            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(OpenFACLayout));
            FileStream fs = new FileStream("LayoutDefault.json", FileMode.OpenOrCreate, FileAccess.Write);
            js.WriteObject(fs, layout);
            fs.Close();

        
        }

        public OpenCapKeyboardManager GetKeyboardManager()
        {
            return keyboardManager;
        }

        public OpenCapKeyboard GetCurrentKeyboard()
        {
            return keyboardManager.Find(layout.Engine) as OpenCapKeyboard;
        }

        public EngineScanType GetScanType()
        {
            if( config.ScanType=="Auto")
                return EngineScanType.ScanAuto;
            return EngineScanType.ScanManual;
        }


        private void LoadLayoutConfig()
        {
            OpenCapKeyboard kb = keyboardManager.Find(layout.Engine) as OpenCapKeyboard;
           
            foreach (LayoutLine li in layout.Lines)
            {
                OpenCapKeyboardLine line = kb.Lines.Add();
                foreach( LayoutButton bt in li.Buttons)
                {
                    OpenCapKeyboardButton button = line.Buttons.Add();
                    button.Caption = bt.Caption;
                    button.Text = bt.Text;

                    IOpenCapAction action = actionManager.Find(bt.Action);
                    button.Action = action;
                }
            }
            
        }

        public OpenCapConfig(string configFile)
        {

            keyboardManager = new OpenCapKeyboardManager();
            actionManager = new OpenCapActionManager();

            config = LoadConfig(configFile);
            layout = LoadLayout(config.KeyboardLayout);
            LoadLayoutConfig();
        }

    }

}
