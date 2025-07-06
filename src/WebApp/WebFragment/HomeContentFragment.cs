﻿using System.IO;
using WebExpress.Tutorial.WebApp.WWW;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebExpress.Tutorial.WebApp.WebFragment
{
    /// <summary>
    /// Represents the fragment control panel for the home content.
    /// </summary>
    /// <remarks>
    /// This fragment is used within the <see cref="Index"/> scope and is part of the <see cref="SectionContentPrimary"/> section.
    /// </remarks>
    [Section<SectionContentPrimary>]
    [Scope<Index>]
    [Cache]
    public sealed class HomeContentFragment : FragmentControlPanel
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public HomeContentFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            using var stream = GetType().Assembly.GetManifestResourceStream("WebExpress.Tutorial.WebApp.README.md");
            using var reader = new StreamReader(stream);

            Add(new ControlText()
            {
                Format = TypeFormatText.Markdown,
                Text = reader.ReadToEnd()
            });
        }

        /// <summary>
        /// Convert the control to HTML.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return base.Render(renderContext, visualTree);
        }
    }
}
