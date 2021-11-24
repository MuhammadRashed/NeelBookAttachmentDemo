using System;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;
using Volo.Abp;

namespace Demo4.Employees
{
    public class Employee : FullAuditedAggregateRoot<Guid>
    {
        [CanBeNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string AttachmentId { get; set; }

        public Employee()
        {

        }

        public Employee(Guid id, string name, string attachmentId)
        {
            Id = id;
            Name = name;
            AttachmentId = attachmentId;
        }
    }
}