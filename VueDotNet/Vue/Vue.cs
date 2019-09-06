namespace VueDotNet.Vue
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.Collections.Generic;
    using VueDotNet.Attributes;
    using System.Linq;

    public class VueDataVM
    {
        //Best approach is to inherit this model with another VM or serialize all VM data into this VM
        public Dictionary<string, object> VueData { get; set; }
    }

    //Dictionary interface for ParseData
    public interface IVueParser
    {
        Dictionary<string, object> ParseData<TModel>(TModel model);
    }

    public class Vue : IVueParser
    {
        public Dictionary<string, object> ParseData<TModel>(TModel model)
        {
            //use reflection to loop through the properties of the model
            var properties = model.GetType().GetProperties();
            //instance of our (soon-to-be-parsed) dictionary
            var dictionary = new Dictionary<string, object>();

            foreach (var property in properties)
            {
                //gets the vuedata object (used to get the 'Nzme' attribute)
                var attribute = property.GetCustomAttributes(typeof(VueData), true)?.FirstOrDefault()
                    as VueData;

                if (attribute == null)
                {
                    continue;
                }
                //we fill the dictionary... string = the name of the vuedata attribute on the model, property = value of the property
                dictionary.Add(attribute.Name, property.GetValue(model));
            }
            //return the dictionary of model properties
            return dictionary;
        }
    }

    public class VueHelper
    {
        public static JsonSerializerSettings GetSettings()
        {
            var settings = new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };
            return settings;
        }

        public static string Serialize(Dictionary<string, object> vueData)
        {

            var json = JsonConvert.SerializeObject(vueData, Formatting.None, GetSettings());

            return json;

        }
    }
}