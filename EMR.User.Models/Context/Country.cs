using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class Country
{
    public short CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public string CountryNickName { get; set; } = null!;

    public string Iso { get; set; } = null!;

    public string? Iso3 { get; set; }

    public int PhoneCode { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual ICollection<OrganizationDetail> OrganizationDetails { get; set; } = new List<OrganizationDetail>();
}
