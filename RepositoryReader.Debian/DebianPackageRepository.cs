using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
				public class DebianPackageRepository : IPackageRepository
				{
								private readonly ILogger<DebianPackageRepository> _logger;

								private readonly IPackageFactory _factory;

								private readonly HttpClient _client;

								public string Name { get; set; }
								public Uri BaseUri { get; set; }
								public Uri GpgKeyUri { get; set; }
								public IEnumerable<IPackage> Packages { get; set; }
								public string Distribution { get; set; }
								public IEnumerable<string> Components { get; set; }

        public DebianPackageRepository(ILogger<DebianPackageRepository> logger, IPackageFactory factory, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
												_factory = factory;
												_client = httpClientFactory.CreateClient();
        }

								public async Task GetPackages(Uri packagesUri)
								{
												var response = await _client.GetAsync(packagesUri);
												if (response.IsSuccessStatusCode) 
												{
																string rawPackagesList = await response.Content.ReadAsStringAsync();
																var splitStrings = ParsePackages(rawPackagesList);
												}
								}
    }
}
