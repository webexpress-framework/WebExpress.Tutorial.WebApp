using System.IO;
using WebApp.WebPage;
using WebExpress.WebApp.WebFragment;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebApp.WebFragment
{
    [Section(Section.ContentPrimary)]
    [Module<Module>]
    [Scope<HomePage>]
    public sealed class HomeContentFragment : FragmentControlPanel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public HomeContentFragment()
            : base()
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="page">The page where the component is active.</param>
        public override void Initialization(IFragmentContext context, IPage page)
        {
            base.Initialization(context, page);

            using var stream = GetType().Assembly.GetManifestResourceStream("WebApp.README.md");
            using var reader = new StreamReader(stream);

            Content.Add(new ControlText()
            {
                Format = TypeFormatText.Markdown,
                Text = reader.ReadToEnd()
            });
        }

        /// <summary>
        /// Convert to html.
        /// </summary>
        /// <param name="context">The context in which the control is represented.</param>
        /// <returns>The control as html.</returns>
        public override IHtmlNode Render(RenderContext context)
        {
            return base.Render(context);
        }
    }
}
