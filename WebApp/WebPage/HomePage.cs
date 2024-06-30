using System.IO;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebResource;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebControl;

namespace WebApp.WebPage
{
    [Title("WebApp:homepage.label")]
    [Segment(null, "WebApp:homepage.label")]
    [ContextPath(null)]
    [Module<Module>]
    public sealed class HomePage : PageWebApp, IScope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
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

            using var stream = GetType().Assembly.GetManifestResourceStream("WebApp.README.md");
            using var reader = new StreamReader(stream);

            context.VisualTree.Content.Primary.Add(new ControlText() { Text = reader.ReadToEnd(), Format = TypeFormatText.Markdown });
        }
    }
}
