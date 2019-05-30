using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZNEW.Mvc.CustomModelDisplayName.Config
{
    /// <summary>
    /// Display Info
    /// </summary>
    public class DisplayInfo
    {
        /// <summary>
        /// Display Name
        /// </summary>
        [JsonProperty(PropertyName = "displayTxt")]
        public string DisplayName
        {
            get;set;
        }
    }
}
