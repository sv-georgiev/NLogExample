using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLogExample.Model
{
    public interface IPerson
    {
        Logger Log { get; }
        void ExecuteRequest();
    }
}
