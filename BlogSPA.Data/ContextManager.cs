using System.Data.Entity;
using System.Threading;
using System.Web;

namespace BlogSPA.Data
{
    public static class ContextManager<T> where T : DbContext, new()
    {
        private const string DbContextKey = "DbContext";
        private static T _InternalContext;

        public static T GetCurrentContext()
        {
            if (HttpContext.Current == null)
                return _InternalContext ?? (_InternalContext = new T());

            var key = DbContextKey + HttpContext.Current.GetHashCode().ToString("x") + Thread.CurrentContext.ContextID.ToString();

            var context = HttpContext.Current.Items[key] as T;
            if (context == null)
                context = new T();
            HttpContext.Current.Items[key] = context;
            return context;
        }
    }
}
