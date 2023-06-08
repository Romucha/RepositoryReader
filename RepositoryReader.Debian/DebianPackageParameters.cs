using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RepositoryReader.Debian
{
    public class DebianPackageParameters : IPackageParameters
    {
								public string Name { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public string Architecture { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;
        public string Priority { get; set; } = string.Empty;
								public int Installed_Size { get; set; }
								public string Maintainer { get; set; } = string.Empty;
								public string Description { get; set; } = string.Empty;
								public IEnumerable<string> Depends { get; set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Recommends { get; set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Suggests  { get; set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Enhances { get; set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Pre_Depends { get; set; } = Enumerable.Empty<string>();
								public string SHA256 { get; set; } = string.Empty;
								public int Size { get; set; }
								public string Filename { get; set; } = string.Empty;
				}
}
