namespace VueDotNet.ViewModels
{
    using VueDotNet.Vue;
    using System.Collections.Generic;
    using VueDotNet.Attributes;
    public class HomeVM : VueDataVM
    {
        //
        // the VueData attribute is the variable that the property is assigned in your vue app

        [VueData("message")]
        public string Message { get; set; }
        [VueData("menu")]
        public List<string> MenuItems { get; set; }
        [VueData("razormessage")]
        public string RazorMessage { get; set; }
    }
}