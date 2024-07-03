using WebApp.WebPage;
using WebExpress.WebApp.WebFragment;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebApp.WebFragment
{
    [Section(Section.AppNavigationSecondary)]
    [Module<Module>]
    [Cache]
    public sealed class InfoFragment : FragmentControlNavigationItemLink
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoFragment"/> class.
        /// </summary>
        public InfoFragment()
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

            Text = "webapp:infopage.label";
            Uri = ComponentManager.SitemapManager.GetUri<InfoPage>();
            Icon = new PropertyIcon(TypeIcon.InfoCircle);
            Active = page is InfoPage ? TypeActive.Active : TypeActive.None;
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