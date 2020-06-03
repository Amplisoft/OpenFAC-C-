using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;


namespace OpenFAC.Library
{

    [DataContract]
    class OpenFACConfig
    {
        [DataMember]
        public string KeyboardLayout;

        [DataMember]
        public string ScanType;

        [DataMember]
        public string ActiveSensor;
    }


    [DataContract]
    class OpenFACLayout
    {
        [DataMember]
        public string Engine;

        [DataMember]
        public List<LayoutLine> Lines;
    }


    [DataContract]
    class LayoutLine
    {
        [DataMember]
        public List<LayoutButton> Buttons;
    }

    [DataContract]
    class LayoutButton
    {
        [DataMember]
        public string Caption;

        [DataMember]
        public string Text;

        [DataMember]
        public string Action;
    }

}
