using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian
{
				public class DebianPackageRepository : IPackageRepository
				{
								private readonly ILogger<DebianPackageRepository> _logger;

								private readonly IPackageFactory _factory;

								private readonly HttpClient _client;

								/// <inheritdoc/>
								public string Name { get; }
								/// <inheritdoc/>
								public Uri BaseUri { get; set; }
								/// <inheritdoc/>
								public Uri GpgKeyUri { get; set; }
								/// <inheritdoc/>
								public IEnumerable<IPackage> Packages { get; set; }
								/// <inheritdoc/>
								public bool IsManageable { get; set; }
								/// <inheritdoc/>
								public int Port { get; set; }
								public string Distribution { get; set; }
								public IEnumerable<string> Components { get; set; }

								public DebianPackageRepository(ILogger<DebianPackageRepository> logger, IPackageFactory factory, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
												_factory = factory;
												_client = httpClientFactory.CreateClient();
        }

								public async Task GetPackages()
								{
												try
												{
																var response = await _client.GetAsync(BaseUri);
																if (response.IsSuccessStatusCode)
																{
																				string rawPackagesList = await response.Content.ReadAsStringAsync();
																				var splitPackages = rawPackagesList.Split(new string[] { "\n\n", "\r\n\r\n" }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
																				Packages = splitPackages.ToList().Select(c => _factory.CreatePackageParameters(c));
																}
																else
																{
																				throw new HttpRequestException($"{response.StatusCode}");
																}
												}
												catch (Exception ex)
												{
																_logger.LogError(ex, "Error when getting packagess from repository");
																throw;
												}
								}
				}
}
