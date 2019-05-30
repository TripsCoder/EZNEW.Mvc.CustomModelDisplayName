using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZNEW.Mvc.CustomModelDisplayName.Config
{
    /// <summary>
    /// Display Collection
    /// </summary>
    public class DisplayCollection
    {
        /// <summary>
        /// Type Displays
        /// </summary>
        [JsonProperty(PropertyName = "types")]
        public List<TypeDisplay> Types
        {
            get; set;
        }
    }
}
