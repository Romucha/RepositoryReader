using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader
{
    public interface IPackageParameters
    {
        string Name { get; set; }
        string Version { get; set; }
        string Architecture { get; set; }
    }
}
