using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public interface IByOptimisticLockProtected : IEntity
    {
        int RowVersion { get; set; }
    }
}
