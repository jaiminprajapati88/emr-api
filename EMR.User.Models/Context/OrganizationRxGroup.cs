using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class OrganizationRxGroup
{
    public long OrganizationRxGroupId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public long RxGroupId { get; set; }

    public int MedicineId { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual OrganizationRx OrganizationRx { get; set; } = null!;

    public virtual RxGroup RxGroup { get; set; } = null!;
}
