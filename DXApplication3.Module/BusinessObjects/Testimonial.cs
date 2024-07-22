using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication3.Module.BusinessObjects
{
    [NavigationItem("Marketing")]
    public class Testimonial : BaseObject
    {
        public virtual string Quote { get; set; }

        [FieldSize(FieldSizeAttribute.Unlimited)]
        public virtual string Highlight { get; set; }

        [VisibleInListView(false)]
        public virtual DateTime CreatedOn { get; set; }

        public virtual string Tags { get; set; }

        public virtual IList<Customer> Customers { get; set; } = new ObservableCollection<Customer>();

    }
}
