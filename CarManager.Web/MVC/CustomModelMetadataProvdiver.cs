using CarManager.Web.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarManager.Web.MVC
{
    //
    public class CustomModelMetadataProvdiver:DataAnnotationsModelMetadataProvider
    {
        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType, Func<object> modelAccessor, Type modelType, string propertyName)
        {
            //return base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
            var modelMetadata = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);

            if (containerType!=null)
            {
                string key = containerType.Name.Replace(".",string.Empty) + propertyName + nameof(modelMetadata.DisplayName);
                string displayName=Resources.ResourceManager.GetString(key);
                if (!string.IsNullOrWhiteSpace(displayName))
                {
                    modelMetadata.DisplayName = displayName;
                }
            }

            return modelMetadata;
        }
    }
}