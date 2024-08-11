using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebResource;
using WebExpress.WebCore.WebScope;

namespace WebApp.WebPage
{
    [Title("webapp:homepage.label")]
    [Segment(null, "webapp:homepage.label")]
    [ContextPath(null)]
    [Module<Module>]
    public sealed class HomePage : PageWebApp, IScope
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public HomePage()
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="context">The context for rendering the page.</param>
        public override void Process(RenderContextWebApp context)
        {
            base.Process(context);
        }
    }
}
