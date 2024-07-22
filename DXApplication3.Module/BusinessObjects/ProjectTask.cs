using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DXApplication3.Module.BusinessObjects;
using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.ConditionalAppearance;

namespace DXApplication3.Module.BusinessObjects
{
    [NavigationItem("Planning")]
    [Appearance("InProgress", TargetItems = "Subject;AssignedTo",
    Criteria = "Status = 1", BackColor = "LemonChiffon")]
    public class ProjectTask : BaseObject
    {
        [FieldSize(255)]
        public virtual string Subject { get; set; }

        public virtual ProjectTaskStatus Status { get; set; }

        public virtual Employee AssignedTo { get; set; }

        public virtual DateTime? DueDate { get; set; }

        public virtual DateTime? StartDate { get; set; }

        public virtual DateTime? EndDate { get; set; }

        [StringLength(4096)]
        public virtual string Notes { get; set; }

        public virtual Project Project { get; set; }

    }

    public enum ProjectTaskStatus
    {
        NotStarted = 0,
        InProgress = 1,
        Completed = 2,
        Deferred = 3
    }
}
