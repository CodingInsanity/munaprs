using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace nothinbutdotnetstore.web.core
{
    public interface ICanBeAssignedARole
    {
        string role { get; set; }
    }
}
