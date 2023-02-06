global using System.Net;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Diagnostics;
global using static OrderCard.Resources;

namespace OrderCard
{
    internal static class Resources
    {
        public static string requestUri = "https://zakupki.gov.ru/epz/order/notice/ea20/view/common-info.html?regNumber=0338300012023000007";
        public static RegexOptions options = RegexOptions.Compiled | RegexOptions.Singleline;
    }
}
