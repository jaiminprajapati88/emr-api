using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMR.Data.Context;

public partial class EmrContext : DbContext
{
    public EmrContext()
    {
    }

    public EmrContext(DbContextOptions<EmrContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppPreference> AppPreferences { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<AppointmentService> AppointmentServices { get; set; }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<HealthProfessionalDetail> HealthProfessionalDetails { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<OrganizationDetail> OrganizationDetails { get; set; }

    public virtual DbSet<OrganizationReferral> OrganizationReferrals { get; set; }

    public virtual DbSet<OrganizationRx> OrganizationRxes { get; set; }

    public virtual DbSet<OrganizationRxGroup> OrganizationRxGroups { get; set; }

    public virtual DbSet<PatientAddress> PatientAddresses { get; set; }

    public virtual DbSet<PatientDetail> PatientDetails { get; set; }

    public virtual DbSet<PatientIdentity> PatientIdentities { get; set; }

    public virtual DbSet<PatientOrganization> PatientOrganizations { get; set; }

    public virtual DbSet<RxGroup> RxGroups { get; set; }

    public virtual DbSet<State> States { get; set; }

    public virtual DbSet<TypeGroup> TypeGroups { get; set; }

    public virtual DbSet<TypeRef> TypeRefs { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    public virtual DbSet<UserOrganization> UserOrganizations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppPreference>(entity =>
        {
            entity.HasKey(e => e.PreferenceId).HasName("apppreference_pk");

            entity.ToTable("AppPreference", "Config");

            entity.Property(e => e.PreferenceId).HasMaxLength(255);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("true");
            entity.Property(e => e.IsConfig).HasDefaultValueSql("false");
            entity.Property(e => e.PreferenceDesc).HasMaxLength(255);
            entity.Property(e => e.PreferenceValue).HasMaxLength(255);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("appointment_pk");

            entity.ToTable("Appointment", "Organization");

            entity.Property(e => e.AppointmentId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Notes).HasMaxLength(500);
            entity.Property(e => e.Payment).HasPrecision(5, 2);
            entity.Property(e => e.Remarks).HasMaxLength(1000);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_organization_fk");

            entity.HasOne(d => d.PatientDetail).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_patientdetail_fk");

            entity.HasOne(d => d.Purpose).WithMany(p => p.AppointmentPurposes)
                .HasForeignKey(d => d.PurposeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_purpose_fk");

            entity.HasOne(d => d.Status).WithMany(p => p.AppointmentStatuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_status_fk");

            entity.HasOne(d => d.UserDetail).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointment_user_fk");
        });

        modelBuilder.Entity<AppointmentService>(entity =>
        {
            entity.HasKey(e => e.AppointmentServiceId).HasName("appointmentservice_pk");

            entity.ToTable("AppointmentService", "Organization");

            entity.Property(e => e.AppointmentServiceId).UseIdentityAlwaysColumn();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.ServiceCode).HasMaxLength(20);
            entity.Property(e => e.ServiceGst)
                .HasPrecision(3, 2)
                .HasColumnName("ServiceGST");
            entity.Property(e => e.ServiceName).HasMaxLength(100);
            entity.Property(e => e.ServicePrice).HasPrecision(5, 2);

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.AppointmentServices)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentservice_organization_fk");

            entity.HasOne(d => d.UserDetail).WithMany(p => p.AppointmentServices)
                .HasForeignKey(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("appointmentservice_userdetails_fk");
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("city_pk");

            entity.ToTable("City", "Config");

            entity.Property(e => e.CityId).UseIdentityAlwaysColumn();
            entity.Property(e => e.CityName).HasMaxLength(50);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .IsFixedLength();

            entity.HasOne(d => d.StateCodeNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.StateCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("city_state_fk");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("country_pk");

            entity.ToTable("Country", "Config");

            entity.Property(e => e.CountryId).UseIdentityAlwaysColumn();
            entity.Property(e => e.CountryName).HasMaxLength(80);
            entity.Property(e => e.CountryNickName).HasMaxLength(80);
            entity.Property(e => e.Iso)
                .HasMaxLength(2)
                .IsFixedLength()
                .HasColumnName("ISO");
            entity.Property(e => e.Iso3)
                .HasMaxLength(3)
                .HasDefaultValueSql("NULL::bpchar")
                .IsFixedLength()
                .HasColumnName("ISO3");
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
        });

        modelBuilder.Entity<HealthProfessionalDetail>(entity =>
        {
            entity.HasKey(e => e.UserDetailId).HasName("healthprofessionaldetails_pk");

            entity.ToTable("HealthProfessionalDetails", "Organization");

            entity.Property(e => e.UserDetailId).ValueGeneratedNever();
            entity.Property(e => e.AadharNumber).HasMaxLength(12);
            entity.Property(e => e.OtherIdentityType).HasMaxLength(30);
            entity.Property(e => e.OtherIdentityValue).HasMaxLength(30);
            entity.Property(e => e.PanCardNumber).HasMaxLength(10);
            entity.Property(e => e.RegistrationNumber).HasMaxLength(50);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.HealthProfessionalDetails)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("healthprofessionaldetails_organization_fk");

            entity.HasOne(d => d.UserDetail).WithOne(p => p.HealthProfessionalDetail)
                .HasForeignKey<HealthProfessionalDetail>(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("healthprofessionaldetails_userdetails_fk");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("message_pk");

            entity.ToTable("Message", "Config");

            entity.Property(e => e.MessageId).HasMaxLength(15);
            entity.Property(e => e.MessageDesc).HasMaxLength(255);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.MessageTypeCodeNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.MessageTypeCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("message_fk");
        });

        modelBuilder.Entity<OrganizationDetail>(entity =>
        {
            entity.HasKey(e => e.OrganizationDetailId).HasName("organization_pk");

            entity.ToTable("OrganizationDetails", "Organization");

            entity.Property(e => e.OrganizationDetailId).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.AddressLine1).HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.FormCnumber)
                .HasMaxLength(50)
                .HasColumnName("FormCNumber");
            entity.Property(e => e.Gstin)
                .HasMaxLength(15)
                .HasColumnName("GSTIN");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("true");
            entity.Property(e => e.OrganizationName).HasMaxLength(255);
            entity.Property(e => e.PinCode).HasMaxLength(6);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .IsFixedLength();

            entity.HasOne(d => d.Country).WithMany(p => p.OrganizationDetails)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organization_country_fk");

            entity.HasOne(d => d.OrganizationType).WithMany(p => p.OrganizationDetails)
                .HasForeignKey(d => d.OrganizationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organization_organizationtype_fk");
        });

        modelBuilder.Entity<OrganizationReferral>(entity =>
        {
            entity.HasKey(e => e.OrganizationReferralId).HasName("organizationreferral_pk");

            entity.ToTable("OrganizationReferral", "Organization");

            entity.Property(e => e.OrganizationReferralId).UseIdentityAlwaysColumn();
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Qualification).HasMaxLength(100);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.OrganizationReferrals)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationreferral_organization_fk");
        });

        modelBuilder.Entity<OrganizationRx>(entity =>
        {
            entity.HasKey(e => new { e.MedicineId, e.OrganizationDetailId }).HasName("organizationmedicine_pk");

            entity.ToTable("OrganizationRx", "Organization");

            entity.Property(e => e.MedicineId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.GenericName).HasMaxLength(1000);
            entity.Property(e => e.MedicineDosage).HasMaxLength(100);
            entity.Property(e => e.MedicineName).HasMaxLength(100);
            entity.Property(e => e.MedicineNotes).HasMaxLength(4000);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.MedicineDurationNavigation).WithMany(p => p.OrganizationRxMedicineDurationNavigations)
                .HasForeignKey(d => d.MedicineDurationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrx_medicineduration_fk");

            entity.HasOne(d => d.MedicineFrequency).WithMany(p => p.OrganizationRxMedicineFrequencies)
                .HasForeignKey(d => d.MedicineFrequencyId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrx_medicinefrequency_fk");

            entity.HasOne(d => d.MedicineTiming).WithMany(p => p.OrganizationRxMedicineTimings)
                .HasForeignKey(d => d.MedicineTimingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrx_medicinetiming_fk");

            entity.HasOne(d => d.MedicineType).WithMany(p => p.OrganizationRxMedicineTypes)
                .HasForeignKey(d => d.MedicineTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrx_medicinetype_fk");

            entity.HasOne(d => d.MedicineUnit).WithMany(p => p.OrganizationRxMedicineUnits)
                .HasForeignKey(d => d.MedicineUnitId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrx_medicineunit_fk");

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.OrganizationRxes)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrx_organization_fk");
        });

        modelBuilder.Entity<OrganizationRxGroup>(entity =>
        {
            entity.HasKey(e => e.OrganizationRxGroupId).HasName("organizationrxgroup_pk");

            entity.ToTable("OrganizationRxGroup", "Organization");

            entity.Property(e => e.OrganizationRxGroupId).UseIdentityAlwaysColumn();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.OrganizationRxGroups)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrxgroup_organization_fk");

            entity.HasOne(d => d.RxGroup).WithMany(p => p.OrganizationRxGroups)
                .HasForeignKey(d => d.RxGroupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrxgroup_rxgroup_fk");

            entity.HasOne(d => d.OrganizationRx).WithMany(p => p.OrganizationRxGroups)
                .HasForeignKey(d => new { d.MedicineId, d.OrganizationDetailId })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("organizationrxgroup_medicine_fk");
        });

        modelBuilder.Entity<PatientAddress>(entity =>
        {
            entity.HasKey(e => e.PatientAddressId).HasName("patientaddress_pk");

            entity.ToTable("PatientAddress", "Patient");

            entity.Property(e => e.PatientAddressId).UseIdentityAlwaysColumn();
            entity.Property(e => e.AddressLine1).HasMaxLength(100);
            entity.Property(e => e.AddressLine1Perm).HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.AddressLine2Perm).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.CityPerm).HasMaxLength(20);
            entity.Property(e => e.Country).HasMaxLength(25);
            entity.Property(e => e.CountryPerm).HasMaxLength(25);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.State).HasMaxLength(20);
            entity.Property(e => e.StatePerm).HasMaxLength(20);
            entity.Property(e => e.Zipcode).HasMaxLength(10);
            entity.Property(e => e.ZipcodePerm).HasMaxLength(10);

            entity.HasOne(d => d.PatientDetail).WithMany(p => p.PatientAddresses)
                .HasForeignKey(d => d.PatientDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patientaddress_fk");
        });

        modelBuilder.Entity<PatientDetail>(entity =>
        {
            entity.HasKey(e => e.PatientDetailId).HasName("patientdetails_pk");

            entity.ToTable("PatientDetails", "Patient");

            entity.Property(e => e.PatientDetailId).ValueGeneratedNever();
            entity.Property(e => e.DateOfBirth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.FirstNamePerm).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.LastNamePerm).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.MiddleNamePerm).HasMaxLength(50);
            entity.Property(e => e.PatientId).HasMaxLength(20);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.Title).HasMaxLength(10);
            entity.Property(e => e.TitlePerm).HasMaxLength(10);
        });

        modelBuilder.Entity<PatientIdentity>(entity =>
        {
            entity.HasKey(e => e.PatientIdentityId).HasName("patientidentity_pk");

            entity.ToTable("PatientIdentity", "Patient");

            entity.Property(e => e.PatientIdentityId).UseIdentityAlwaysColumn();
            entity.Property(e => e.AadharNum).HasMaxLength(12);
            entity.Property(e => e.CentralHealthId).HasMaxLength(14);
            entity.Property(e => e.OtherIdentityType).HasMaxLength(30);
            entity.Property(e => e.OtherIdentityValue).HasMaxLength(30);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.PatientDetail).WithMany(p => p.PatientIdentities)
                .HasForeignKey(d => d.PatientDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patientidentity_fk");
        });

        modelBuilder.Entity<PatientOrganization>(entity =>
        {
            entity.HasKey(e => new { e.OrganizationDetailId, e.PatientDetailId }).HasName("patientorganizations_pk");

            entity.ToTable("PatientOrganizations", "Patient");

            entity.Property(e => e.PatientOrganizationId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.PatientOrganizations)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patientorganizations_organization_fk");

            entity.HasOne(d => d.PatientDetail).WithMany(p => p.PatientOrganizations)
                .HasForeignKey(d => d.PatientDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("patientorganizations_patientdetails_fk");
        });

        modelBuilder.Entity<RxGroup>(entity =>
        {
            entity.HasKey(e => e.RxGroupId).HasName("rxgroup_pk");

            entity.ToTable("RxGroup", "Organization");

            entity.Property(e => e.RxGroupId).UseIdentityAlwaysColumn();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RxGroupName).HasMaxLength(50);

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.RxGroups)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("rxgroup_organization_fk");
        });

        modelBuilder.Entity<State>(entity =>
        {
            entity.HasKey(e => e.StateCode).HasName("state_pk");

            entity.ToTable("State", "Config");

            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.StateName).HasMaxLength(255);
        });

        modelBuilder.Entity<TypeGroup>(entity =>
        {
            entity.HasKey(e => e.TypeGroupCode).HasName("typegroup_pk");

            entity.ToTable("TypeGroup", "Config");

            entity.Property(e => e.TypeGroupCode).ValueGeneratedNever();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.TypeGroupDesc).HasMaxLength(255);
        });

        modelBuilder.Entity<TypeRef>(entity =>
        {
            entity.HasKey(e => e.TypeCode).HasName("typeref_pk");

            entity.ToTable("TypeRef", "Config");

            entity.Property(e => e.TypeCode).ValueGeneratedNever();
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.TypeDesc).HasMaxLength(255);
            entity.Property(e => e.TypeFullDesc).HasMaxLength(255);

            entity.HasOne(d => d.TypeGroupCodeNavigation).WithMany(p => p.TypeRefs)
                .HasForeignKey(d => d.TypeGroupCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("typeref_fk");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserDetailId).HasName("userdetails_pk");

            entity.ToTable("UserDetails", "User");

            entity.Property(e => e.UserDetailId).HasDefaultValueSql("gen_random_uuid()");
            entity.Property(e => e.AddressLine1).HasMaxLength(100);
            entity.Property(e => e.AddressLine2).HasMaxLength(100);
            entity.Property(e => e.CellNo).HasMaxLength(10);
            entity.Property(e => e.City).HasMaxLength(20);
            entity.Property(e => e.DateOfBirth).HasColumnType("timestamp without time zone");
            entity.Property(e => e.EmailAddress).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("true");
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MiddleName).HasMaxLength(50);
            entity.Property(e => e.PinCode).HasMaxLength(6);
            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.StateCode)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.Title).HasMaxLength(10);

            entity.HasOne(d => d.UserRole).WithMany(p => p.UserDetails)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userdetails_fk");
        });

        modelBuilder.Entity<UserOrganization>(entity =>
        {
            entity.HasKey(e => new { e.OrganizationDetailId, e.UserDetailId }).HasName("userorganizations_pk");

            entity.ToTable("UserOrganizations", "User");

            entity.Property(e => e.RowAddStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowAddUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.RowUpdateStamp)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone");
            entity.Property(e => e.RowUpdateUserId)
                .HasMaxLength(255)
                .HasDefaultValueSql("'SYSTEM'::character varying");
            entity.Property(e => e.UserOrganizationId)
                .ValueGeneratedOnAdd()
                .UseIdentityAlwaysColumn();

            entity.HasOne(d => d.OrganizationDetail).WithMany(p => p.UserOrganizations)
                .HasForeignKey(d => d.OrganizationDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userorganizations_organization_fk");

            entity.HasOne(d => d.UserDetail).WithMany(p => p.UserOrganizations)
                .HasForeignKey(d => d.UserDetailId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userorganizations_userdetails_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
