using Demo4.Localization;
using Volo.Abp.Application.Services;

namespace Demo4
{
    /* Inherit your application services from this class.
     */
    public abstract class Demo4AppService : ApplicationService
    {
        protected Demo4AppService()
        {
            LocalizationResource = typeof(Demo4Resource);
        }
    }
}
