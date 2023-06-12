using Castle.Core.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryReader.Debian.Tests
{
				public class DebianPackageRepositoryTests
				{
								private readonly IPackageRepositoryFactory _packageRepositoryFactory;
        public DebianPackageRepositoryTests()
        {
												//httpclient factory
												var httpClientFactoryMock = new Mock<IHttpClientFactory>();
												var client = new HttpClient();
												httpClientFactoryMock.Setup(c => c.CreateClient(It.IsAny<string>())).Returns(client);
												IHttpClientFactory httpClientFactory = httpClientFactoryMock.Object;
												//loggerfactory
												var loggerFactory = new NullLoggerFactory();
												//repository factory
												_packageRepositoryFactory = new DebianPackageRepositoryFactory(loggerFactory, httpClientFactory);
        }

								[Fact]
								public async Task ReadNormalRepository()
								{
												//assign
												IPackageRepositorySettings packageRepositorySettings = new DebianPackageRepositorySettings()
												{
																BaseUri = new Uri("https://packages.microsoft.com/debian/11/prod/"),
																GpgKeyUri = new Uri("https://packages.microsoft.com/debian/11/prod/dists/bullseye/Release.gpg"),
																Distribution = "bullseye",
																Name = "microsoft",
																IsManageable = false,
																Port = 0,
																Type = "deb",
																Components = new string[] { "main" },
																Architectures = new string[] { "all", "amd64", "arm64", "armhf" },
												};
												IPackageRepository testRepository = await _packageRepositoryFactory.CreatePackageRepository(packageRepositorySettings);
												//act
												await testRepository.GetPackages();
												//assert
												Assert.NotNull(testRepository.Packages);
												Assert.NotEmpty(testRepository.Packages);
								}

								[Fact]
								public async Task ReadBrokenRepository()
								{
												//assign
												IPackageRepositorySettings packageRepositorySettings = new DebianPackageRepositorySettings()
												{
																BaseUri = new Uri("https://packages.microsoft.com/nondebian/11/prod/"),
																GpgKeyUri = new Uri("https://packages.microsoft.com/debian/11/prod/dists/bullseye/Release.gpg"),
																Distribution = "bullseye",
																Name = "microsoft",
																IsManageable = false,
																Port = 0,
																Type = "deb",
																Components = new string[] { "main" },
																Architectures = new string[] { "all", "amd64", "arm64", "armf" },
												};
												IPackageRepository testRepository = await _packageRepositoryFactory.CreatePackageRepository(packageRepositorySettings);
												//act
												Func<Task> func = () => testRepository.GetPackages();
												//assert
												await Assert.ThrowsAnyAsync<Exception>(func);
								}

								[Fact]
								public async Task SetDefaultRepository()
								{
												//assign
												IPackageRepositorySettings packageRepositorySettings = new DebianPackageRepositorySettings()
												{
																BaseUri = new Uri("https://packages.microsoft.com/debian/11/prod/"),
																GpgKeyUri = new Uri("https://packages.microsoft.com/debian/11/prod/dists/bullseye/Release.gpg"),
																Distribution = "bullseye",
																Name = "microsoft",
																IsManageable = false,
																Port = 0,
																Type = "deb",
																Components = new string[] { "main" },
																Architectures = new string[] { "all", "amd64", "arm64", "armhf" },
												};
												string sourcesListString = "deb https://packages.microsoft.com/debian/11/prod/ bullseye main";
												//act
												DebianPackageRepository? testRepository = await _packageRepositoryFactory.CreatePackageRepository(packageRepositorySettings) as DebianPackageRepository;
												//assert
												Assert.NotNull(testRepository);
												Assert.Equal(sourcesListString, testRepository.SourcesListAddress);
								}

								[Fact]
								public async Task SetSpecificRepository()
								{
												//assign
												IPackageRepositorySettings packageRepositorySettings = new DebianPackageRepositorySettings()
												{
																BaseUri = new Uri("https://packages.microsoft.com/debian/11/prod/"),
																GpgKeyUri = new Uri("https://packages.microsoft.com/debian/11/prod/dists/bullseye/Release.gpg"),
																Distribution = "bullseye",
																Name = "microsoft",
																IsManageable = false,
																Port = 0,
																Type = "deb",
																Components = new string[] { "main" },
																Architectures = new string[] { "all", "amd64", "arm64", "armhf" },
												};
												string sourcesListString = "deb https://packages.microsoft.com/debian/12/prod/ bullseye main";
												//act
												DebianPackageRepository? testRepository = await _packageRepositoryFactory.CreatePackageRepository(packageRepositorySettings) as DebianPackageRepository;
												testRepository?.SetSourcesListAddress(sourcesListString);
												//assert
												Assert.NotNull(testRepository);
												Assert.Equal(sourcesListString, testRepository.SourcesListAddress);
								}
				}
}
