using System;
using System.Collections.Generic;

namespace EMR.Data.Context;

public partial class State
{
    public string StateCode { get; set; } = null!;

    public string StateName { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
