using Volo.Abp.Settings;

namespace Demo4.Settings
{
    public class Demo4SettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(Demo4Settings.MySetting1));
        }
    }
}
