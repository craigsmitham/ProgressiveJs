using System.Collections.Generic;

namespace ProgressiveJs.Server
{
    public class JsonAjaxResponseItem
    {
        public string Selector { get; set; }

        public string Manipulation { get; set; }

        public List<object> Args { get; set; }

        public bool ReinitializeJs { get; set; }

        public JsonAjaxResponseItem(List<object> args, string selector = ".response", string manipulation = "html", bool reinitializeJs = true)
            : this(selector, manipulation, reinitializeJs)
        {
            Args = args;
        }

        public JsonAjaxResponseItem(string selector = ".response", string manipulation = "html", bool reinitializeJs = true)
        {
            Selector = selector;
            Manipulation = manipulation;
            ReinitializeJs = reinitializeJs;
        }
    }
}