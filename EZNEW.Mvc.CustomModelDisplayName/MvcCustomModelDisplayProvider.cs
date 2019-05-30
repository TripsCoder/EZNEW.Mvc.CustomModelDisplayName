using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

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

        /// <summary>
        /// register CustomDisplayMetadataProvider
        /// </summary>
        /// <param name="serviceProvider"></param>
        public static void Register(IServiceProvider serviceProvider)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }
            IOptions<MvcOptions> mvcOptions = serviceProvider.GetService(typeof(IOptions<MvcOptions>)) as IOptions<MvcOptions>;
            mvcOptions.Value.ModelMetadataDetailsProviders.Add(new MvcCustomModelDisplayProvider());
        }
    }
}
