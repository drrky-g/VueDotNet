using System.Collections.Generic;

namespace VueDotNet.ViewModels
{
    public class CombinedDataVM
    {
        public Dictionary<string, object> ModelOneData { get; set; }
        public Dictionary<string, object> ModelTwoData { get; set; }
        public Dictionary<string, object> ModelThreeData { get; set; }
        public Dictionary<string, object> ModelFourData { get; set; }
    }
}