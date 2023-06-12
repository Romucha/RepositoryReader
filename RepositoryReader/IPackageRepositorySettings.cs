using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader
{
				public interface IPackageRepositorySettings
				{
								/// <summary>
								/// Name of repository.
								/// </summary>
								string Name { get; set; }

								/// <summary>
								/// Url of repository.
								/// </summary>
								Uri BaseUri { get; set; }

								/// <summary>
								/// Url of gpg of repository.
								/// </summary>
								Uri GpgKeyUri { get; set; }

								/// <summary>
								/// Determines if the repository can be managed by user.
								/// </summary>
								bool IsManageable { get; set; }

								/// <summary>
								/// Port to manage repository.
								/// </summary>
								int Port { get; set; }
				}
}
