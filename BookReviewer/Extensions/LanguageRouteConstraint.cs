using Microsoft.AspNetCore.Mvc.Abstractions;

namespace BookReviewer.Extensions
{
    public class LanguageRouteConstraint : IRouteConstraint, IParameterPolicy
    {
        private readonly string[] _supportedLanguages;

        public LanguageRouteConstraint(string[] supportedLanguages)
        {
            _supportedLanguages = supportedLanguages;
        }

        public Task<bool> IsValidAsync(HttpContext httpContext, ParameterDescriptor parameter, object value, RouteValueDictionary values)
        {
            string language = value.ToString().ToLowerInvariant();
            return Task.FromResult(_supportedLanguages.Contains(language));
        }

        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            if (values.TryGetValue(routeKey, out object languageValue))
            {
                string language = languageValue.ToString().ToLowerInvariant();

                return _supportedLanguages.Contains(language);
            }
            return false;
        }
    }
}
