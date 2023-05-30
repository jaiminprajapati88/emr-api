using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public string CountryCode { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual State StateCodeNavigation { get; set; } = null!;
}
