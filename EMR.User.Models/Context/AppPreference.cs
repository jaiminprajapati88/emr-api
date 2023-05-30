using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class AppPreference
{
    public string PreferenceId { get; set; } = null!;

    public string PreferenceValue { get; set; } = null!;

    public string PreferenceDesc { get; set; } = null!;

    public bool? IsActive { get; set; }

    public bool? IsConfig { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;
}
