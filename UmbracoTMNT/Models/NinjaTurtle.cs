using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.PropertyEditors;

namespace UmbracoTMNT.Models
{
    public class NinjaTurtle
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public string Weapon { get; set; }
        public string Info { get; set; }
        public string SmallImage { get; set; }
        public string BackgroundImage { get; set; }
    }

    [PropertyValueType(typeof(NinjaTurtle))]
    [PropertyValueCache(PropertyCacheValue.All, PropertyCacheLevel.Content)]
    public class NinjaTurtleConverter : PropertyValueConverterBase
    {
        public override bool IsConverter(PublishedPropertyType propertyType)
        {
            return propertyType.PropertyEditorAlias.Equals("Nojaf.NinjaTurtleEditor");
        }

        public override object ConvertDataToSource(PublishedPropertyType propertyType, object source, bool preview)
        {
            if (source == null) return null;
            var sourceString = source.ToString();

            try
            {
                return JsonConvert.DeserializeObject<NinjaTurtle>(sourceString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}