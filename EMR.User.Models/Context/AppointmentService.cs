using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class AppointmentService
{
    public int AppointmentServiceId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public Guid UserDetailId { get; set; }

    public string ServiceName { get; set; } = null!;

    public decimal ServicePrice { get; set; }

    public decimal? ServiceTax { get; set; }

    public string? ServiceCode { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual UserDetail UserDetail { get; set; } = null!;
}
