using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZNEW.Mvc.CustomModelDisplayName.Config
{
    /// <summary>
    /// Type Display
    /// </summary>
    public class TypeDisplay
    {
        /// <summary>
        /// Type Full Name
        /// </summary>
        [JsonProperty(PropertyName = "typeName")]
        public string TypeFullName
        {
            get;set;
        }

        /// <summary>
        /// Propertys
        /// </summary>
        [JsonProperty(PropertyName = "displays")]
        public List<PropertyFieldDisplay> Propertys
        {
            get;set;
        }
    }
}
