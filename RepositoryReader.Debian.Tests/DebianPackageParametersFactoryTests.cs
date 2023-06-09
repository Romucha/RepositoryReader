using Castle.Core.Logging;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;

namespace RepositoryReader.Debian.Tests
{
				public class DebianPackageParametersFactoryTests
				{
								private DebianPackageParametersFactory _factory;

        public DebianPackageParametersFactoryTests()
        {
												Microsoft.Extensions.Logging.ILogger<DebianPackageParametersFactory> logger = new Mock<Microsoft.Extensions.Logging.ILogger<DebianPackageParametersFactory>>().Object;
												_factory = new DebianPackageParametersFactory(logger);
        }

        [Fact]
								public void CreatePackageParametersFromNormalString()
								{
												//arrange
												string input = Properties.Resources.NormalParameters;
												IPackageParameters parameters;
												//act
												parameters = _factory.CreatePackageParameters(input);
												//assert
												Assert.NotNull(parameters);
												Assert.IsType<DebianPackageParameters>(parameters);
								}

								[Fact]
								public void CreatePackageParametersFromBrokenString()
								{
												//arrange
												string input = Properties.Resources.BrokenParameters;
												IPackageParameters parameters;
												//act
												parameters = _factory.CreatePackageParameters(input);
												//assert
												Assert.Null(parameters);
								}

								[Fact]
								public void CreatePackageParametersFromEmptyString()
								{
												//arrange
												string input = Properties.Resources.EmptyParameters;
												IPackageParameters parameters;
												//act
												parameters = _factory.CreatePackageParameters(input);
												//assert
												Assert.Null(parameters);
								}
				}
}