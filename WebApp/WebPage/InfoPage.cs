using System.Linq;
using WebExpress.WebApp.WebPage;
using WebExpress.WebCore.Internationalization;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebComponent;
using WebExpress.WebCore.WebResource;
using WebExpress.WebCore.WebScope;
using WebExpress.WebUI.WebControl;

namespace WebApp.WebPage
{
    [Title("webapp:infopage.label")]
    [Segment("info", "webapp:infopage.label")]
    [ContextPath(null)]
    [Module<Module>]
    public sealed class InfoPage : PageWebApp, IScope
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InfoPage"/> class.
        /// </summary>
        public InfoPage()
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

            var visualTree = context.VisualTree;
            var webexpress = ComponentManager.PluginManager.Plugins.Where(x => x.PluginId == "webexpress.webapp").FirstOrDefault();
            var webapp = ComponentManager.PluginManager.Plugins.Where(x => x.Assembly == GetType().Assembly).FirstOrDefault();

            visualTree.Content.Primary.Add(new ControlImage()
            {
                Uri = ResourceContext.ContextPath.Append("assets/img/webapp.svg"),
                Width = 200,
                Height = 200,
                HorizontalAlignment = TypeHorizontalAlignment.Right
            });

            var card = new ControlPanelCard() { Margin = new PropertySpacingMargin(PropertySpacing.Space.Null, PropertySpacing.Space.Two) };

            card.Add(new ControlText()
            {
                Text = this.I18N("webapp:app.name"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = this.I18N("webapp:app.description"),
                Format = TypeFormatText.Paragraph
            });

            card.Add(new ControlText()
            {
                Text = this.I18N("webapp:app.about"),
                Format = TypeFormatText.H3
            });

            card.Add(new ControlText()
            {
                Text = string.Format
                (
                    this.I18N("webapp:app.version.label"),
                    this.I18N(webapp?.PluginName),
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
