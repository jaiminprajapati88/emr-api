using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class TypeRef
{
    public int TypeCode { get; set; }

    public int TypeGroupCode { get; set; }

    public string TypeDesc { get; set; } = null!;

    public string? TypeFullDesc { get; set; }

    public int? Sequence { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual ICollection<Message> Messages { get; set; } = new List<Message>();

    public virtual ICollection<OrganizationDetail> OrganizationDetails { get; set; } = new List<OrganizationDetail>();

    public virtual ICollection<OrganizationRx> OrganizationRxMedicineDurationNavigations { get; set; } = new List<OrganizationRx>();

    public virtual ICollection<OrganizationRx> OrganizationRxMedicineFrequencies { get; set; } = new List<OrganizationRx>();

    public virtual ICollection<OrganizationRx> OrganizationRxMedicineTimings { get; set; } = new List<OrganizationRx>();

    public virtual ICollection<OrganizationRx> OrganizationRxMedicineTypes { get; set; } = new List<OrganizationRx>();

    public virtual ICollection<OrganizationRx> OrganizationRxMedicineUnits { get; set; } = new List<OrganizationRx>();

    public virtual TypeGroup TypeGroupCodeNavigation { get; set; } = null!;

    public virtual ICollection<UserDetail> UserDetails { get; set; } = new List<UserDetail>();
}
