using System.Linq;
using WebExpress.WebApp.WebPage;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;

namespace WebApp.WebPage
{
    /// <summary>
    /// Represents the info page for the tutorial.
    /// </summary>
    [Title("webapp:infopage.label")]
    [Segment("info", "webapp:infopage.label")]
    [Scope<IScopeGeneral>]
    public sealed class InfoPage : IPage<VisualTreeWebApp>, IScopeGeneral
    {
        /// <summary>
        /// Initializes a new instance of the class with the specified page context.
        /// </summary>
        /// <param name="pageContext">The context of the page.</param>
        public InfoPage(IPageContext pageContext)
        {
        }

        /// <summary>
        /// Processing of the resource.
        /// </summary>
        /// <param name="renderContext">The context for rendering the page.</param>
        /// <param name="visualTree">The visual tree of the web application.</param>
        public void Process(IRenderContext renderContext, VisualTreeWebApp visualTree)
        {
            var webexpress = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.PluginId.ToString() == "webexpress.webapp").FirstOrDefault();
            var webapp = WebEx.ComponentHub.PluginManager.Plugins.Where(x => x.Assembly == GetType().Assembly).FirstOrDefault();

            visualTree.Content.Primary.Add(new ControlImage()
            {
                Uri = renderContext.PageContext.ContextPath.Append("assets/img/webapp.svg"),
                Width = 200,
                Height = 200,
                HorizontalAlignment = TypeHorizontalAlignment.Right
            });

            var card = new ControlPanelCard()
            {
                Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two)
            };

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webapp:app.name"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webapp:app.description"),
                Format = TypeFormatText.Paragraph
            });

            card.Add(new ControlText()
            {
                Text = I18N.Translate(renderContext.Request?.Culture, "webapp:app.about"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = string.Format
                (
                    I18N.Translate(renderContext.Request?.Culture, "webapp:app.version.label"),
                    I18N.Translate(renderContext.Request?.Culture, webapp?.PluginName),
                    webapp?.Version,
                    webexpress?.PluginName,
                    webexpress?.Version
                ),
                TextColor = new PropertyColorText(TypeColorText.Primary)
            });

            visualTree.Content.Primary.Add(card);
        }
    }
}
