using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class OrganizationRx
{
    public int MedicineId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public int MedicineTypeId { get; set; }

    public string MedicineName { get; set; } = null!;

    public string GenericName { get; set; } = null!;

    public short MedicineDose { get; set; }

    public int MedicineUnitId { get; set; }

    public string MedicineDosage { get; set; } = null!;

    public int MedicineTimingId { get; set; }

    public int MedicineFrequencyId { get; set; }

    public int MedicineDuration { get; set; }

    public int MedicineDurationId { get; set; }

    public string MedicineNotes { get; set; } = null!;

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual TypeRef MedicineDurationNavigation { get; set; } = null!;

    public virtual TypeRef MedicineFrequency { get; set; } = null!;

    public virtual TypeRef MedicineTiming { get; set; } = null!;

    public virtual TypeRef MedicineType { get; set; } = null!;

    public virtual TypeRef MedicineUnit { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual ICollection<OrganizationRxGroup> OrganizationRxGroups { get; set; } = new List<OrganizationRxGroup>();
}
