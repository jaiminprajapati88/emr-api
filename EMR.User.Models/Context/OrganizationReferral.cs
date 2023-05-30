using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class OrganizationReferral
{
    public int OrganizationReferralId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public string Name { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public string MobileNo { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;
}
