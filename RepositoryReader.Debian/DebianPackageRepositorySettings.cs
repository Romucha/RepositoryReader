using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
				public class DebianPackageRepositorySettings : IPackageRepositorySettings
				{
								public string Name { get; set; }

								public Uri BaseUri { get; set; }

								public Uri GpgKeyUri { get; set; }

								public bool IsManageable { get; set; }

								public int Port { get; set; }

								public string Type { get; set; }

								public string Distribution { get; set; }

								public IEnumerable<string> Components { get; set; }
				}
}
