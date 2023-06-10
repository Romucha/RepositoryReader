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
								private readonly IPackageRepository _packageRepository;
        public DebianPackageRepositoryTests()
        {
												Microsoft.Extensions.Logging.ILogger<DebianPackageRepository> logger = new Mock<Microsoft.Extensions.Logging.ILogger<DebianPackageRepository>>().Object;
												Microsoft.Extensions.Logging.ILogger<DebianPackageFactory> factoryLogger = new Mock<Microsoft.Extensions.Logging.ILogger<DebianPackageFactory>>().Object;

												IPackageFactory factory = new DebianPackageFactory(factoryLogger);

												var httpClientFactoryMock = new Mock<IHttpClientFactory>();
												var client = new HttpClient();
												httpClientFactoryMock.Setup(c => c.CreateClient(It.IsAny<string>())).Returns(client);
												IHttpClientFactory httpClientFactory = httpClientFactoryMock.Object;
												_packageRepository = new DebianPackageRepository(logger, factory, httpClientFactory);
        }

								[Fact]
								public async Task ReadNormalRepository()
								{
												//assign
												var normalrepourl = new Uri("https://packages.microsoft.com/debian/10/prod/dists/buster/main/binary-all/Packages");
												//act
												await _packageRepository.GetPackages(normalrepourl);
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
												Func<Task> func = () => _packageRepository.GetPackages(brokenrepourl);
												//assert
												await Assert.ThrowsAnyAsync<Exception>(func);
								}
				}
}
