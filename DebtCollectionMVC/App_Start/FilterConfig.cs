using System.Web;
using System.Web.Mvc;

namespace DebtCollectionMVC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //Harus login untuk membuka semua menu
            filters.Add(new AuthorizeAttribute());
        }
    }
}
