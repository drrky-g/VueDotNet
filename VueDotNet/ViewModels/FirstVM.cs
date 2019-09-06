namespace VueDotNet.ViewModels
{
    using VueDotNet.Attributes;
    public class FirstVM
    {
        [VueData("message")]
        public string Greeting { get; set; }
    }
}