using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class TypeGroup
{
    public int TypeGroupCode { get; set; }

    public string TypeGroupDesc { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime RowAddStamp { get; set; }

    public string RowAddUserId { get; set; } = null!;

    public DateTime RowUpdateStamp { get; set; }

    public string RowUpdateUserId { get; set; } = null!;

    public virtual ICollection<TypeRef> TypeRefs { get; set; } = new List<TypeRef>();
}
