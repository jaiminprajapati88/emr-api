using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class HealthProfessionalDetail
{
    public Guid UserDetailId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public string RegistrationNumber { get; set; } = null!;

    public string AadharNumber { get; set; } = null!;

    public string PanCardNumber { get; set; } = null!;

    public string? OtherIdentityType { get; set; }

    public string? OtherIdentityValue { get; set; }

    public string IdentitySalt { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual UserDetail UserDetail { get; set; } = null!;
}
