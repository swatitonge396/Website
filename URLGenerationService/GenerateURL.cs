using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLGenerationService
{
    public class GenerateURL
    {

        public string BrowseNode { get; set; }
        public string ItemPage { get; set; }

        public string GetURL()
        {
            string url = string.Empty;
            try
            {
                Authentication param = new Authentication() { AccessKey = "", SecretKey = "" };
                Sign sign = new Sign(param);
                ParamURL operation = new ParamURL();
                operation.AssociateTag("project2k17-20");
                operation.BrowseNode(BrowseNode);
                operation.ItemPage(ItemPage);
                operation.Operation("ItemSearch");
                operation.ResponseGroup("ItemAttributes,Large");
                operation.SearchIndex("Appliances");
                url = sign.SignURL(operation);

            }
            catch (Exception e) { e.ToString(); if (string.IsNullOrEmpty(url) == true) Console.WriteLine("Returning Empty String"); }
            return url;
        }
    }
}
