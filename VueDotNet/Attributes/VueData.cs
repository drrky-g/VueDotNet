namespace VueDotNet.Attributes
{
    using System;
    public class VueData : Attribute
    {
        public VueData(string name)
        {
            Name = name;
        }
        public string Name { get; }
    }
}