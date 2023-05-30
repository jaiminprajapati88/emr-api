namespace EMR.Data.Context;

public partial class OrganizationDetail
{
    public Guid OrganizationDetailId { get; set; }

    public string OrganizationName { get; set; } = null!;

    public string AddressLine1 { get; set; } = null!;

    public string? AddressLine2 { get; set; }

    public string City { get; set; } = null!;

    public string StateCode { get; set; } = null!;

    public short CountryId { get; set; }

    public string PinCode { get; set; } = null!;

    public string CellNo { get; set; } = null!;

    public string? FormCnumber { get; set; }

    public string? PanCardNumber { get; set; }

    public string? Gstin { get; set; }

    public int OrganizationTypeId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<HealthProfessionalDetail> HealthProfessionalDetails { get; set; } = new List<HealthProfessionalDetail>();

    public virtual ICollection<OrganizationReferral> OrganizationReferrals { get; set; } = new List<OrganizationReferral>();

    public virtual ICollection<OrganizationRxGroup> OrganizationRxGroups { get; set; } = new List<OrganizationRxGroup>();

    public virtual ICollection<OrganizationRx> OrganizationRxes { get; set; } = new List<OrganizationRx>();

    public virtual TypeRef OrganizationType { get; set; } = null!;

    public virtual ICollection<PatientOrganization> PatientOrganizations { get; set; } = new List<PatientOrganization>();

    public virtual ICollection<RxGroup> RxGroups { get; set; } = new List<RxGroup>();

    public virtual ICollection<UserOrganization> UserOrganizations { get; set; } = new List<UserOrganization>();
}
