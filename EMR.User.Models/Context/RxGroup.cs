using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class RxGroup
{
    public long RxGroupId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public string RxGroupName { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual ICollection<OrganizationRxGroup> OrganizationRxGroups { get; set; } = new List<OrganizationRxGroup>();
}
