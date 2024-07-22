using DevExpress.ExpressApp;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.EF;
using DevExpress.Persistent.BaseImpl.EF;
using Microsoft.Extensions.DependencyInjection;
using DXApplication3.Module.BusinessObjects;

namespace DXApplication3.Module.DatabaseUpdate;

// For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Updating.ModuleUpdater
public class Updater : ModuleUpdater {
    public Updater(IObjectSpace objectSpace, Version currentDBVersion) :
        base(objectSpace, currentDBVersion) {
    }
    public override void UpdateDatabaseAfterUpdateSchema() {
        base.UpdateDatabaseAfterUpdateSchema();

        Employee employee = ObjectSpace.FirstOrDefault<Employee>(x =>
        x.FirstName == "John" && x.LastName == "Doe");
        if (employee == null)
        {
            employee = ObjectSpace.CreateObject<Employee>();
            employee.FirstName = "John";
            employee.LastName = "Doe";
        }
        Customer customer = ObjectSpace.FirstOrDefault<Customer>(c =>
        c.FirstName == "Boar" && c.LastName == "Aper");
        if (customer == null)
        {
            customer = ObjectSpace.CreateObject<Customer>();
            customer.FirstName = "Boar";
            customer.LastName = "Aper";
            customer.Email = "Email@Email.com";
            customer.Company = "Rowers and Galleys inc.";
        }
        ObjectSpace.CommitChanges();
    }
    public override void UpdateDatabaseBeforeUpdateSchema() {
        base.UpdateDatabaseBeforeUpdateSchema();
    }
}
