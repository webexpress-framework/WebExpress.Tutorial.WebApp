using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebResource;

namespace WebApp.WebResource
{
    /// <summary>
    /// Delivery of a resource embedded in the assembly.
    /// </summary>
    [Title("Assets")]
    [Segment("assets", "")]
    [ContextPath("/")]
    [IncludeSubPaths(true)]
    [Module<Module>]
    public sealed class ResourceAsset : WebExpress.WebCore.WebResource.ResourceAsset
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceAsset"/> class.
        /// </summary>
        public ResourceAsset()
        {
        }

        /// <summary>
        /// Initialization
        /// </summary>
        /// <param name="context">The context of the resource.</param>
        public override void Initialization(IResourceContext context)
        {
            base.Initialization(context);
        }
    }
}
