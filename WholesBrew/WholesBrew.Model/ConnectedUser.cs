using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helper;
using WholesBrew.Model.Abstractions;

namespace WholesBrew.Model;

[RegisterAsComponent]
public class ConnectedUser : IConnectedUser
{
    public long Id { get; set; }
}
