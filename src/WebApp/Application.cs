using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;

namespace WebApp
{
    /// <summary>
    /// Represents the application of the tutorial.
    /// </summary>
    [Name("webapp:app.name")]
    [Description("webapp:app.description")]
    [Icon("/assets/img/webapp.svg")]
    [ContextPath("/webapp")]
    public sealed class Application : IApplication
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Application()
        {
        }

        /// <summary>
        /// Called when the application starts working. The call is concurrent. 
        /// </summary>
        public void Run()
        {
        }
    }
}