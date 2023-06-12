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
												var normalrepourl = new Uri("https://packages.microsoft.com/debian/10/prod/dists/buster/main/binary-all/Packages");
												//act
												await _packageRepository.GetPackages();
												//assert
												Assert.NotNull(_packageRepository.Packages);
												Assert.NotEmpty(_packageRepository.Packages);
								}

								[Fact]
								public async Task ReadBrokenRepository()
								{
												//assign
												var brokenrepourl = new Uri("https://packages.microsoft.com/debian/10/prod/dists/buster/main/binary-all/NoPackages");
												//act
												Func<Task> func = () => _packageRepository.GetPackages();
												//assert
												await Assert.ThrowsAnyAsync<Exception>(func);
								}
				}
}
