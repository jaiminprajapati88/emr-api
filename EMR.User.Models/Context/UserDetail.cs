using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class UserDetail
{
    public Guid UserDetailId { get; set; }

    public string Title { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public string LastName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public string CellNo { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public string PasswordSalt { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? AddressLine1 { get; set; }

    public string? AddressLine2 { get; set; }

    public string? City { get; set; }

    public string? StateCode { get; set; }

    public short? CountryId { get; set; }

    public string? PinCode { get; set; }

    public int UserRoleId { get; set; }

    public bool? IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual ICollection<AppointmentService> AppointmentServices { get; set; } = new List<AppointmentService>();

    public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

    public virtual HealthProfessionalDetail? HealthProfessionalDetail { get; set; }

    public virtual ICollection<UserOrganization> UserOrganizations { get; set; } = new List<UserOrganization>();

    public virtual TypeRef UserRole { get; set; } = null!;
}
