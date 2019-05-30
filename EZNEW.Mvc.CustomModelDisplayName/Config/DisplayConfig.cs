using EZNEW.Framework.Serialize;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZNEW.Mvc.CustomModelDisplayName.Config
{
    /// <summary>
    /// Display Config
    /// </summary>
    public static class DisplayConfig
    {
        /// <summary>
        /// Init From Json Data
        /// </summary>
        /// <param name="jsonData">JSON</param>
        public static void InitFromJsonData(string jsonData)
        {
            if (string.IsNullOrWhiteSpace(jsonData))
            {
                return;
            }
            DisplayCollection displayCollection = JsonSerialize.JsonToObject<DisplayCollection>(jsonData);
            if (displayCollection == null || displayCollection.Types == null)
            {
                return;
            }
            foreach (var type in displayCollection.Types)
            {
                if (type == null || string.IsNullOrWhiteSpace(type.TypeFullName) || type.Propertys == null)
                {
                    continue;
                }
                Type modelType = Type.GetType(type.TypeFullName);
                if (modelType == null)
                {
                    continue;
                }
                foreach (var propertyDisplay in type.Propertys)
                {
                    if (propertyDisplay == null || string.IsNullOrWhiteSpace(propertyDisplay.Name) || propertyDisplay.Display == null)
                    {
                        continue;
                    }
                    DisplayManager.Add(modelType, propertyDisplay.Name, propertyDisplay.Display.DisplayName);
                }
            }
        }

        /// <summary>
        // Init From Files
        /// </summary>
        /// <param name="filePaths">files</param>
        public static void InitFromFiles(params string[] filePaths)
        {
            if (filePaths == null)
            {
                return;
            }
            foreach (var file in filePaths)
            {
                try
                {
                    string jsonData = File.ReadAllText(file);
                    InitFromJsonData(jsonData);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}
