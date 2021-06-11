using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Libreria
{
    public class Ventana
    {
        public string open_window(string url, string height,string width){
            return "<script type='text/javascript'>var vtop=parseInt((screen.availHeight/2) - (" + height + "/2)); var vleft= (screen.availWidth/2) - (" + width + "/2);window.open('" + url + "','window','HEIGHT=" + height + ",WIDTH=" + width + ",top=' + vtop + ',left=' + vleft + ',margin-right=auto,toolbar=no,scrollbars=yes,resizable=no');</script>";
        }

        public static void close_window()
        {
            string s;
            System.Web.UI.Page p;
            p = (System.Web.UI.Page)HttpContext.Current.Handler;
            s = "<script lenguage=JavaScript>window.close();</script>";
            if (!p.ClientScript.IsStartupScriptRegistered("CloseW"))
            {
                p.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "CloseW", s);
            }
        }

        public static void JavaRedir(string strurl)
        {
            string s;
            System.Web.UI.Page p;
            p = (System.Web.UI.Page)HttpContext.Current.Handler;
            s = "<script type='text/javascript'>window.location = '" + strurl;
            s += "'</script>";
            if (!p.ClientScript.IsStartupScriptRegistered("JavaRedir"))
            {
                p.ClientScript.RegisterStartupScript(typeof(System.Web.UI.Page), "JavaRedir", s);
            }
           
        } 




    }
}
