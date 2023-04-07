using Microsoft.Extensions.Localization;
using System.Reflection;

namespace BookReviewer.Services
{
    public class SharedResource
    {

    }

    public class LocalizationService
    {
        private readonly IStringLocalizer localizer;

        public LocalizationService(IStringLocalizerFactory localizerFactory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            this.localizer = localizerFactory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString GetKey(string key) 
        {
            return localizer[key];
        }
    }
}
