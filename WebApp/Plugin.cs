using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPlugin;

namespace WebApp
{
    /// <summary>  
    /// Represents the plugin for the tutorial.  
    /// </summary>  
    [Name("webapp:plugin.name")]
    [Description("webapp:plugin.description")]
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