namespace VueDotNet.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using VueDotNet.Attributes;

    public class UserProfileVM
    {
        [VueData("firstname")]
        public string FirstName { get; set; }
        [VueData("lastname")]
        public string LastName { get; set; }
        [VueData("email")]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}