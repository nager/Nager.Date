using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using System;
using System.Collections.Generic;

namespace Nager.Date.WebsiteCore.Controllers
{
    /// <summary>
    /// Sitemap
    /// </summary>
    public class SitemapController : Controller
    {
        public IActionResult Index(string countryCode)
        {
            #region Country Overview

            if (string.IsNullOrEmpty(countryCode))
            {
                var indexNodes = new List<SitemapIndexNode>();
                var items = Enum.GetValues(typeof(CountryCode));
                foreach (var item in items)
                {
                    indexNodes.Add(new SitemapIndexNode(Url.Action("Index", new { countryCode = item.ToString() })));
                }

                return new SitemapProvider().CreateSitemapIndex(new SitemapIndexModel(indexNodes));
            }

            #endregion

            #region Country Detail

            var startYear = DateTime.Today.Year - 100;
            var endYear = DateTime.Today.Year + 100;

            var nodes = new List<SitemapNode>();
            for (var i = startYear; i < endYear; i++)
            {
                nodes.Add(new SitemapNode(Url.Action("Country", "PublicHoliday", new { countryCode = countryCode.ToString(), year = i })) { ChangeFrequency = ChangeFrequency.Monthly });
            }

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));

            #endregion
        }
    }
}
