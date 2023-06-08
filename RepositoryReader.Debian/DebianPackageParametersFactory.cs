using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
    public class DebianPackageParametersFactory : IPackageParametersFactory
				{
								public IPackageParameters CreatePackageParameters(string RawParameters)
								{
												foreach (var parameter in RawParameters.Split(
																new string[] { Environment.NewLine }, 
																StringSplitOptions.RemoveEmptyEntries))
												{
																
												}
												return null;
								}

								private void ParseString(DebianPackageParameters parameters, string rawParameter) 
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
																
												}
								}
				}
}
