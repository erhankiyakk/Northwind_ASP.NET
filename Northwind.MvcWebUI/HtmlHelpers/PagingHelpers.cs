using Northwind.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Northwind.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html,PagingInfo pagingInfo)
        {
            int totalPage = (int)Math.Ceiling((decimal)pagingInfo.TotalItems / pagingInfo.ItemsPerPage);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 1; i <= totalPage; i++)
            {
                var tagBuilder_ul = new TagBuilder("ul");
                tagBuilder_ul.MergeAttribute("class", "pagination");
                var tagBuilder_li = new TagBuilder("li");
                if (pagingInfo.CurrentPage != i)
                {
                    tagBuilder_li.MergeAttribute("class", "page-item");
                }
                else
                {
                    tagBuilder_li.MergeAttribute("class", "page-item active");
                }
                var tagBuilder_a = new TagBuilder("a");
                tagBuilder_a.MergeAttribute("class", "page-link");
                tagBuilder_a.MergeAttribute("href", String.Format("/Product/Index/?page={0}&category={1}", i,pagingInfo.CurrentCategory));
                tagBuilder_a.InnerHtml = i.ToString();
                tagBuilder_li.InnerHtml = tagBuilder_a.ToString();
                tagBuilder_ul.InnerHtml = tagBuilder_li.ToString();
                stringBuilder.Append(tagBuilder_ul);
            }
            return MvcHtmlString.Create(stringBuilder.ToString());
            
        }
    }
}