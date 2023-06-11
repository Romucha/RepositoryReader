using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader
{
				/// <summary>
				/// Contains parameters of a single package.
				/// </summary>
    public interface IPackage
    {
								/// <summary>
								/// Name of package.
								/// </summary>
        string Name { get; }
								/// <summary>
								/// Version of package.
								/// </summary>
        string Version { get; }
								/// <summary>
								/// Architecture of package.
								/// </summary>
        string Architecture { get; }

								IPackage WithParameters(string Parameters);
    }
}
