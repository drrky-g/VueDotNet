namespace VueDotNet.ViewModels
{
    using VueDotNet.Attributes;
    public class SecondVM
    {
        [VueData("bye")]
        public string Bye { get; set; }
    }
}