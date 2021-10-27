using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Nager.Date.Website.Helper
{
    public static class AcceptLanguageFormatter
    {
        public static IFormatProvider GetDateFormatter(HttpRequest request)
        {
            var languages = GetOrderedLanguages(request);
            if (languages.Any())
            {
                var supported = new HashSet<string>(CultureInfo
                    .GetCultures(CultureTypes.AllCultures)
                    .Select(c => c.Name));
                var found = languages.FirstOrDefault(l => supported.Contains(l));
                if (found != null)
                {
                    return CultureInfo.GetCultureInfo(found).DateTimeFormat;
                }
            }
            return CultureInfo.InvariantCulture.DateTimeFormat;
        }
        public static IEnumerable<string> GetOrderedLanguages(HttpRequest request)
        {
            var langs = request.GetTypedHeaders().AcceptLanguage;
            if (langs == null)
            {
                return Enumerable.Empty<string>();
            }
            return (from al in langs
                    orderby al.Quality
                    select al.Value.Value).ToList();
        }
    }
}
