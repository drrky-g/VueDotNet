namespace VueDotNet.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using VueDotNet.ViewModels;
    using VueDotNet.Vue;
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //populate list for the viewmodel list property
            var vmList = new List<string>();
            vmList.Add("Item One");
            vmList.Add("Item Two");
            vmList.Add("Item Three");
            vmList.Add("Item Four");
            vmList.Add("Item Five");

            //fill VM with data
            var homeVM = new HomeVM
            {
                Message = "Hello Vue!",
                MenuItems = vmList,
                RazorMessage = "Hello Razor!",
            };

            //instance of vue
            var vue = new Vue();
            homeVM.VueData = vue.ParseData(homeVM);
            return View(homeVM);
        }

        //combine multiple VMs into a VM of Dictionaries that gets serialized in the view
        public ActionResult SecondIndex()
        {
            var firstVM = new FirstVM
            {
                Greeting = "Hello World"
            };
            var secondVM = new FirstVM
            {
                Greeting = "Foo"
            };
            var thirdVM = new FirstVM
            {
                Greeting = "Bar"
            };
            var fourthVM = new SecondVM
            {
                Bye = "Goodbye World"
            };

            var vue = new Vue();
            var vueData = new CombinedDataVM
            {
                ModelOneData = vue.ParseData(firstVM),
                ModelTwoData = vue.ParseData(secondVM),
                ModelThreeData = vue.ParseData(thirdVM),
                ModelFourData = vue.ParseData(fourthVM)
            };

            return View(vueData);
        }

        //transfer an entire viewmodel into a JSON object (No model data-binding with Razor)
        public ActionResult ThirdIndex()
        {
            var userVM = new UserProfileVM
            {
                FirstName = "Tony",
                LastName = "Stark",
                EmailAddress = "tony@stark.com"
            };

            var vue = new Vue();
            var vueData = new VueDataVM { VueData = vue.ParseData(userVM) };

            return View(vueData);
        }
    }
}