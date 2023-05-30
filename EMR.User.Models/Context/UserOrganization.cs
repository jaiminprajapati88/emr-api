﻿using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class UserOrganization
{
    public int UserOrganizationId { get; set; }

    public Guid OrganizationDetailId { get; set; }

    public Guid UserDetailId { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual OrganizationDetail OrganizationDetail { get; set; } = null!;

    public virtual UserDetail UserDetail { get; set; } = null!;
}
