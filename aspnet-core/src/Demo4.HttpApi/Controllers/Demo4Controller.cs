using Demo4.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Demo4.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class Demo4Controller : AbpController
    {
        protected Demo4Controller()
        {
            LocalizationResource = typeof(Demo4Resource);
        }
    }
}