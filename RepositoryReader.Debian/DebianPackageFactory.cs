using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
    public class DebianPackageFactory : IPackageFactory
				{
								private readonly ILogger<DebianPackageFactory> _logger;

        internal DebianPackageFactory(ILogger<DebianPackageFactory> logger)
        {
            _logger = logger;
        }
        public IPackage CreatePackageParameters(string RawParameters)
								{
												try
												{
																if (string.IsNullOrEmpty(RawParameters))
																{
																				throw new ArgumentNullException("RawParameters");
																}
																IPackage debianPackageParameters = new DebianPackage().WithParameters(RawParameters); 
																
																return debianPackageParameters;
												}
												catch (Exception ex)
												{
																_logger.LogError(ex, "Debian package factory error");
																return null;
												}
								}
				}
}
