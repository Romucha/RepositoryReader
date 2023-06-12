﻿using Microsoft.Extensions.DependencyInjection;
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
								public string Name { get; private set; }
								/// <inheritdoc/>
								public Uri BaseUri { get; private set; }
								/// <inheritdoc/>
								public Uri GpgKeyUri { get; private set; }
								/// <inheritdoc/>
								public IEnumerable<IPackage> Packages { get; private set; }
								/// <inheritdoc/>
								public bool IsManageable { get; private set; }
								/// <inheritdoc/>
								public int Port { get; private set; }
								public string Type { get; private set; }
								public string Distribution { get; private set; }
								public IEnumerable<string> Components { get; private set; }
								public string SourcesListAddress{ get; private set; }
								public string GpgKeyAddress { get; private set; }

								public DebianPackageRepository(ILoggerFactory loggerFactory, IPackageFactory factory, IHttpClientFactory httpClientFactory)
        {
            _logger = loggerFactory.CreateLogger<DebianPackageRepository>();
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
																				Packages = splitPackages.ToList().Select(c => _factory.CreatePackage(c));
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

								public IPackageRepository WithSettings(IPackageRepositorySettings Settings)
								{
												DebianPackageRepositorySettings settings = Settings as DebianPackageRepositorySettings;
												if (settings == null)
												{
																throw new InvalidCastException($"{nameof(Settings)} was not {typeof(DebianPackageRepositorySettings)}");
												}

												this.Name = settings.Name;
												this.GpgKeyUri = settings.GpgKeyUri;
												this.BaseUri = settings.BaseUri;
												this.Distribution = settings.Distribution;
												this.Components = settings.Components;
												this.IsManageable = settings.IsManageable;
												this.Port = settings.Port;
												//TODO:
												//Set sources list and gpg key address
												return this;
								}
				}
}
