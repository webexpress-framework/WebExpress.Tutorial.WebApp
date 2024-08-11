using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPlugin;

namespace WebApp
{
    [Name("webapp:plugin.name")]
    [Description("webapp:plugin.description")]
    [Icon("/assets/img/webapp.svg")]
    [Dependency("webexpress.webui")]
    [Dependency("webexpress.webapp")]
    public sealed class Plugin : IPlugin
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Plugin()
        {
        }

        /// <summary>
        /// Initialization of the plugin. Here, for example, managed resources can be loaded. 
        /// </summary>
        /// <param name="context">The context that applies to the execution of the plugin</param>
        public void Initialization(IPluginContext context)
        {
        }

        /// <summary>
        /// Called when the plugin starts working. Run is called concurrently.
        /// </summary>
        public void Run()
        {
        }

        /// <summary>
        /// Release unmanaged resources that have been reserved during use.
        /// </summary>
        public void Dispose()
        {
        }
    }
}