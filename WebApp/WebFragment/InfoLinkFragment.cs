using WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebApp.WebFragment
{
    /// <summary>
    /// Represents a navigation item link for the info page.
    /// </summary>
    /// <remarks>
    /// This fragment is used to create a navigation link to the Info page with an icon and label.
    /// </remarks>
    [Section<SectionAppNavigationSecondary>]
    [Scope<IScopeGeneral>]
    [Cache]
    public sealed class InfoLinkFragment : FragmentControlNavigationItemLink
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="componentHub">The component hub used to manage components.</param>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public InfoLinkFragment(IComponentHub componentHub, IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "webapp:infopage.label";
            Uri = componentHub.SitemapManager.GetUri<InfoPage>(fragmentContext.ApplicationContext);
            Icon = new PropertyIcon(TypeIcon.InfoCircle);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            Active = renderContext.Endpoint is InfoPage ? TypeActive.Active : TypeActive.None;

            return base.Render(renderContext);
        }
    }
}