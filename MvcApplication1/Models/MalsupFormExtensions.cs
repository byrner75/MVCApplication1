using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Html;
using System.Web.Mvc;

namespace robbie.AspMvc.jQuery
{    
    public static class MalsupFormExtensions
    {
        public static MvcForm jQueryBeginForm(this AjaxHelper ajaxHelper)
        {
            string url = HttpContext.Current.Request.RawUrl;
            TagBuilder formBuilder = new TagBuilder("form");
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();            
            htmlAttributes.Add("onsubmit", "$(this).ajaxSubmit(" +
                                            "{"+
                                            "   replaceTarget: true, " +
                                            "   target: $(this), " + 
                                            "});" +
                                            "return false;");
            formBuilder.MergeAttributes<string, object>(htmlAttributes);
            formBuilder.MergeAttribute("action", url);
            formBuilder.MergeAttribute("method", FormMethod.Post.ToString(), true);
            ajaxHelper.ViewContext.Writer.Write(formBuilder.ToString(TagRenderMode.StartTag));
            MvcForm form = new MvcForm(ajaxHelper.ViewContext);
            return form;            
        }
    }
}
