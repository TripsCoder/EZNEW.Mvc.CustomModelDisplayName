using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZNEW.Mvc.CustomModelDisplayName.Config
{
    /// <summary>
    /// Property Field Display
    /// </summary>
    public class PropertyFieldDisplay
    {
        /// <summary>
        /// Name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name
        {
            get;set;
        }

        /// <summary>
        /// Display info
        /// </summary>
        [JsonProperty(PropertyName = "display")]
        public DisplayInfo Display
        {
            get;set;
        }
    }
}
