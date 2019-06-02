using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace EZNEW.Mvc.CustomModelDisplayName
{
    public class MvcCustomModelDisplayProvider : IDisplayMetadataProvider
    {
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            DisplayText customDisplay = DisplayManager.GetDisplay(context.Key.ContainerType, context.Key.Name);
            if (customDisplay != null && !string.IsNullOrWhiteSpace(customDisplay.DisplayName))
            {
                context.DisplayMetadata.DisplayName = () => customDisplay.DisplayName;
            }
        }
    }
}
