using Sitecore.Mvc.Presentation;

namespace Sitecore.Modules.WeBlog.Components.Parameters
{
    public class RenderingParameterHelper<T> : ParameterHelperBase<T>
    {
        public RenderingParameterHelper(T controller, bool applyProperties)
        {
            var renderingContext = RenderingContext.CurrentOrNull;
            if (renderingContext != null)
            {
                var rawParameters = renderingContext.Rendering.Properties["Parameters"];

                if (!string.IsNullOrEmpty(rawParameters))
                {
                    Parameters = Web.WebUtil.ParseUrlParameters(renderingContext.Rendering.Properties["Parameters"]);
                    if (applyProperties)
                    {
                        ApplyParameters(controller);
                    }
                }
            }
        }
    }
}