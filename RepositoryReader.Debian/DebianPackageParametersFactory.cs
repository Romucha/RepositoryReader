using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
    public class DebianPackageParametersFactory : IPackageParametersFactory
				{
								private readonly ILogger<DebianPackageParametersFactory> _logger;

        public DebianPackageParametersFactory(ILogger<DebianPackageParametersFactory> logger)
        {
            _logger = logger;
        }
        public IPackageParameters CreatePackageParameters(string RawParameters)
								{
												try
												{
																if (string.IsNullOrEmpty(RawParameters))
																{
																				throw new ArgumentNullException("RawParameters");
																}
																DebianPackageParameters debianPackageParameters = new(); 
																RawParameters.Split(new string[] { "\r\n", "\n" },	StringSplitOptions.RemoveEmptyEntries)
																												 .ToList()
																													.ForEach(c => _parseString(debianPackageParameters, c));
																return debianPackageParameters;
												}
												catch (Exception ex)
												{
																_logger.LogError(ex, "Debian package factory error");
																return null;
												}
								}

								private void _parseString(DebianPackageParameters parameters, string rawParameter) 
								{
												if (parameters == null) 
												{ 
																throw new ArgumentNullException("parameters");
												}
												if (string.IsNullOrEmpty(rawParameter)) 
												{
																throw new ArgumentNullException("rawParameter");
												}
												if (rawParameter.Contains(':'))
												{
																string[] keyValuePair = rawParameter.Split(':');
																switch (keyValuePair[0]) 
																{
																				case "":
																				default:
																								break;
																				case "Package":
																								parameters.Name = keyValuePair[1];
																								break;
																				case "Version":
																								parameters.Version = keyValuePair[1];
																								break;
																				case "Architecture":
																								parameters.Architecture = keyValuePair[1];
																								break;
																				case "Section":
																								parameters.Section = keyValuePair[1];
																								break;
																				case "Priority":
																								parameters.Priority = keyValuePair[1];
																								break;
																				case "Installed-Size":
																								parameters.Installed_Size = uint.Parse(keyValuePair[1]);
																								break;
																				case "Maintainer":
																								parameters.Maintainer = keyValuePair[1];
																								break;
																				case "Description":
																								parameters.Description = keyValuePair[1];
																								break;
																				case "Depends":
																								parameters.Depends = _splitByComma(keyValuePair[1]);
																								break;
																				case "Recommends":
																								parameters.Recommends = _splitByComma(keyValuePair[1]);
																								break;
																				case "Suggests":
																								parameters.Suggests = _splitByComma(keyValuePair[1]);
																								break;
																				case "Enhances":
																								parameters.Enhances = _splitByComma(keyValuePair[1]);
																								break;
																				case "Pre-Depends":
																								parameters.Pre_Depends = _splitByComma(keyValuePair[1]);
																								break;
																				case "SHA256":
																								parameters.SHA256 = keyValuePair[1];
																								break;
																				case "Size":
																								parameters.Size = uint.Parse(keyValuePair[1]);
																								break;
																				case "Filename":
																								parameters.Filename = keyValuePair[1];
																								break;
																}
												}
								}

								private IEnumerable<string> _splitByComma(string value) => value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
				}
}
