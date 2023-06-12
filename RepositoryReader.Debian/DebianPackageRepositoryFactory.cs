using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
				public class DebianPackageRepositoryFactory : IPackageRepositoryFactory
				{
								private readonly ILogger _logger;
								private readonly ILoggerFactory _loggerFactory;
								private readonly IPackageFactory _packageFactory;
								private IHttpClientFactory _httpClientFactory;

        public DebianPackageRepositoryFactory(ILoggerFactory loggerFactory, IHttpClientFactory httpClientFactory)
        {
            _loggerFactory = loggerFactory;
												_logger = _loggerFactory.CreateLogger<DebianPackageRepositoryFactory>();
												_httpClientFactory = httpClientFactory;
												_packageFactory = new DebianPackageFactory(loggerFactory);
        }

        public async Task<IPackageRepository> CreatePackageRepository(IPackageRepositorySettings Settings)
								{
												IPackageRepository packageRepository = new DebianPackageRepository(_loggerFactory, _packageFactory, _httpClientFactory)
												.WithSettings(Settings);

												return await Task.FromResult(packageRepository);
								}
				}
}
