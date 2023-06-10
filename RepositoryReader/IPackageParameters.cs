using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader
{
				/// <summary>
				/// Containss parameters of a single package.
				/// </summary>
    public interface IPackageParameters
    {
								/// <summary>
								/// Name of package.
								/// </summary>
        string Name { get; set; }
								/// <summary>
								/// Version of package.
								/// </summary>
        string Version { get; set; }
								/// <summary>
								/// Architecture of package.
								/// </summary>
        string Architecture { get; set; }
    }
}
