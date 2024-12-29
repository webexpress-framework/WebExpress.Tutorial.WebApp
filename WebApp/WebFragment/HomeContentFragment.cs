using System.IO;
using WebApp.WebPage;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;

namespace WebApp.WebFragment
{
    /// <summary>
    /// Represents the fragment control panel for the home content.
    /// </summary>
    /// <remarks>
    /// This fragment is used within the <see cref="HomePage"/> scope and is part of the <see cref="SectionContentPrimary"/> section.
    /// </remarks>
    [Section<SectionContentPrimary>]
    [Scope<HomePage>]
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
            using var stream = GetType().Assembly.GetManifestResourceStream("WebApp.README.md");
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
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext)
        {
            return base.Render(renderContext);
        }
    }
}
