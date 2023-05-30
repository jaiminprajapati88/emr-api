using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class PatientDetail
{
    public Guid PatientDetailId { get; set; }

    public string PatientId { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string TitlePerm { get; set; } = null!;

    public string FirstNamePerm { get; set; } = null!;

    public string? MiddleNamePerm { get; set; }

    public string LastNamePerm { get; set; } = null!;

    public int GenderId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public int DateOfBirthType { get; set; }

    public string CellNo { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual ICollection<PatientAddress> PatientAddresses { get; set; } = new List<PatientAddress>();

    public virtual ICollection<PatientIdentity> PatientIdentities { get; set; } = new List<PatientIdentity>();

    public virtual ICollection<PatientOrganization> PatientOrganizations { get; set; } = new List<PatientOrganization>();
}
