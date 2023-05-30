using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class PatientIdentity
{
    public int PatientIdentityId { get; set; }

    public Guid PatientDetailId { get; set; }

    public string? AadharNum { get; set; }

    public string? CentralHealthId { get; set; }

    public string? OtherIdentityType { get; set; }

    public string? OtherIdentityValue { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual PatientDetail PatientDetail { get; set; } = null!;
}
