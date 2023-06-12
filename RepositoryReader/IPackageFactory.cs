using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader
{
				/// <summary>
				/// Provides methods of reading package parameters.
				/// </summary>
    public interface IPackageFactory
    {
								/// <summary>
								/// Reads package parameters from string.
								/// </summary>
								/// <param name="RawParameters"></param>
								/// <returns></returns>
        IPackage CreatePackage(string RawParameters);
    }
}
