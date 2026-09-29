using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.Tutorial.WebApp
{
    /// <summary>
    /// Represents the application of the tutorial.
    /// </summary>
    [Name("webexpress.tutorial.webapp:app.name")]
    [Description("webexpress.tutorial.webapp:app.description")]
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

        /// <summary>
        /// Disposes of the resources used by the application. This method is called when 
        /// the application is no longer needed and should release any unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}