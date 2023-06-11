using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace RepositoryReader.Debian
{
    public class DebianPackage : IPackage
    {
								public string Name { get; private set; } = string.Empty;
        public string Version { get; private set; } = string.Empty;
        public string Architecture { get; private set; } = string.Empty;
        public string Section { get; private set; } = string.Empty;
        public string Priority { get; private set; } = string.Empty;
								public uint Installed_Size { get; private set; }
								public string Maintainer { get; private set; } = string.Empty;
								public string Description { get; private set; } = string.Empty;
								public IEnumerable<string> Depends { get; private set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Recommends { get; private set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Suggests  { get; private set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Enhances { get; private set; } = Enumerable.Empty<string>();
								public IEnumerable<string> Pre_Depends { get; private set; } = Enumerable.Empty<string>();
								public string SHA256 { get; private set; } = string.Empty;
								public uint Size { get; private set; }
								public string Filename { get; private set; } = string.Empty;

								public IPackage WithParameters(string Parameters)
								{
												Parameters.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries)
																													.ToList()
																													.ForEach(c => _parseString(c));
												return this;
								}


								private void _parseString(string parameter)
								{
												if (string.IsNullOrEmpty(parameter))
												{
																throw new ArgumentNullException(nameof(parameter));
												}
												if (parameter.Contains(':'))
												{
																string[] keyValuePair = parameter.Split(':');
																switch (keyValuePair[0])
																{
																				case "":
																				default:
																								break;
																				case "Package":
																								Name = keyValuePair[1];
																								break;
																				case "Version":
																								Version = keyValuePair[1];
																								break;
																				case "Architecture":
																								Architecture = keyValuePair[1];
																								break;
																				case "Section":
																								Section = keyValuePair[1];
																								break;
																				case "Priority":
																								Priority = keyValuePair[1];
																								break;
																				case "Installed-Size":
																								Installed_Size = uint.Parse(keyValuePair[1]);
																								break;
																				case "Maintainer":
																								Maintainer = keyValuePair[1];
																								break;
																				case "Description":
																								Description = keyValuePair[1];
																								break;
																				case "Depends":
																								Depends = _splitByComma(keyValuePair[1]);
																								break;
																				case "Recommends":
																								Recommends = _splitByComma(keyValuePair[1]);
																								break;
																				case "Suggests":
																								Suggests = _splitByComma(keyValuePair[1]);
																								break;
																				case "Enhances":
																								Enhances = _splitByComma(keyValuePair[1]);
																								break;
																				case "Pre-Depends":
																								Pre_Depends = _splitByComma(keyValuePair[1]);
																								break;
																				case "SHA256":
																								SHA256 = keyValuePair[1];
																								break;
																				case "Size":
																								Size = uint.Parse(keyValuePair[1]);
																								break;
																				case "Filename":
																								Filename = keyValuePair[1];
																								break;
																}
												}
								}

								private IEnumerable<string> _splitByComma(string value) => value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				}
}
