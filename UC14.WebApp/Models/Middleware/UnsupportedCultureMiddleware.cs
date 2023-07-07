using System.Globalization;

namespace UC14.WebApp.Models.Middleware
{
    public class UnsupportedCultureMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<CultureInfo> supportedCultures;

        public UnsupportedCultureMiddleware(RequestDelegate next, List<CultureInfo> supportedCultures)
        {
            this._next = next;
            this.supportedCultures = supportedCultures;
        }

        public async Task Invoke(HttpContext context)
        {
            var culture = context.Request.Query["culture"].ToString();
            if (!string.IsNullOrEmpty(culture) && !supportedCultures.Exists(c => c.Name.ToLower() == culture.ToLower()))
            {
                context.Response.Redirect("Home/CultureNotSupportedError");
            }
            await _next.Invoke(context);
        }
    }
}
