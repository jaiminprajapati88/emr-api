using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class Appointment
{
    public long AppointmentId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public Guid UserDetailId { get; set; }

    public Guid PatientDetailId { get; set; }

    public DateOnly AppointmentDateTime { get; set; }

    public int ServiceId { get; set; }

    public decimal? Payment { get; set; }

    public int StatusId { get; set; }

    public int PurposeId { get; set; }

    public string? Remarks { get; set; }

    public string? Notes { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual PatientDetail PatientDetail { get; set; } = null!;

    public virtual TypeRef Purpose { get; set; } = null!;

    public virtual TypeRef Status { get; set; } = null!;

    public virtual UserDetail UserDetail { get; set; } = null!;
}
