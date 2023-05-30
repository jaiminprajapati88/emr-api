using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class PatientAddress
{
    public int PatientAddressId { get; set; }

    public Guid PatientDetailId { get; set; }

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string State { get; set; } = null!;

    public string Country { get; set; } = null!;

    public short CountryCode { get; set; }

    public string Zipcode { get; set; } = null!;

    public string AddressLine1Perm { get; set; } = null!;

    public string? AddressLine2Perm { get; set; }

    public string CityPerm { get; set; } = null!;

    public string StatePerm { get; set; } = null!;

    public string CountryPerm { get; set; } = null!;

    public short CountryCodePerm { get; set; }

    public string ZipcodePerm { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual PatientDetail PatientDetail { get; set; } = null!;
}
