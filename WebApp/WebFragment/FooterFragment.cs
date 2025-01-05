﻿using WebExpress.WebApp.WebScope;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebApp.WebFragment
{
    /// <summary>
    /// Represents the footer fragment of the web application.
    /// </summary>
    /// <remarks>
    /// This fragment is used to display the footer section, including a license link.
    /// </remarks>
    [Section<SectionFooterPrimary>]
    [Scope<IScopeGeneral>]
    public sealed class FooterFragment : FragmentControlPanel
    {
        /// <summary>
        /// The license link.
        /// </summary>
        private ControlLink LicenceLink { get; } = new ControlLink()
        {
            TextColor = new PropertyColorText(TypeColorText.Muted),
            Size = new PropertySizeText(TypeSizeText.Small)
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public FooterFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Classes.Add("text-center");

            Add(LicenceLink);
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            LicenceLink.Text = "webapp:app.license.label";
            LicenceLink.Uri = I18N.Translate(renderContext.Request?.Culture, "webapp:app.license.uri");

            return base.Render(renderContext, visualTree);
        }
    }
}
