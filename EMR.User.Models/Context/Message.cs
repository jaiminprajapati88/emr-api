using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class Message
{
    public string MessageId { get; set; } = null!;

    public string MessageDesc { get; set; } = null!;

    public int MessageTypeCode { get; set; }

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual TypeRef MessageTypeCodeNavigation { get; set; } = null!;
}
