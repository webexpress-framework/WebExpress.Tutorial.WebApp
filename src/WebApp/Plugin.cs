using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPlugin;

namespace WebExpress.Tutorial.WebApp
{
    /// <summary>  
    /// Represents the plugin for the tutorial.  
    /// </summary>  
    [Name("webexpress.tutorial.webapp:plugin.name")]
    [Description("webexpress.tutorial.webapp:plugin.description")]
    [Icon("/assets/img/webapp.svg")]
    [Application<Application>()]
    public sealed class Plugin : IPlugin
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>  
        public Plugin()
        {
        }

        /// <summary>  
        /// Called when the plugin starts working. Run is called concurrently.  
        /// </summary>  
        public void Run()
        {
        }
    }
}