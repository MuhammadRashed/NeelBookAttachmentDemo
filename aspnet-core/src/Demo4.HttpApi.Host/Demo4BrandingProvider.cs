using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Demo4
{
    [Dependency(ReplaceServices = true)]
    public class Demo4BrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "Demo4";
    }
}
