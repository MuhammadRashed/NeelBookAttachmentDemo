using Demo4.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Demo4.Permissions
{
    public class Demo4PermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(Demo4Permissions.GroupName);

            myGroup.AddPermission(Demo4Permissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
            myGroup.AddPermission(Demo4Permissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(Demo4Permissions.MyPermission1, L("Permission:MyPermission1"));

            var employeePermission = myGroup.AddPermission(Demo4Permissions.Employees.Default, L("Permission:Employees"));
            employeePermission.AddChild(Demo4Permissions.Employees.Create, L("Permission:Create"));
            employeePermission.AddChild(Demo4Permissions.Employees.Edit, L("Permission:Edit"));
            employeePermission.AddChild(Demo4Permissions.Employees.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<Demo4Resource>(name);
        }
    }
}