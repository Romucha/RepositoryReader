using Castle.Core.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using Moq;

namespace RepositoryReader.Debian.Tests
{
				public class DebianPackageFactoryTests
				{
								private DebianPackageFactory _factory;

        public DebianPackageFactoryTests()
        {
												var loggerFactory = new NullLoggerFactory();
												_factory = new DebianPackageFactory(loggerFactory);
        }

        [Fact]
								public void CreatePackageParametersFromNormalString()
								{
												//arrange
												string input = Properties.Resources.NormalParameters;
												IPackage parameters;
												//act
												parameters = _factory.CreatePackage(input);
												//assert
												Assert.NotNull(parameters);
												Assert.IsType<DebianPackage>(parameters);
								}

								[Fact]
								public void CreatePackageParametersFromBrokenString()
								{
												//arrange
												string input = Properties.Resources.BrokenParameters;
												IPackage parameters;
												//act
												parameters = _factory.CreatePackage(input);
												//assert
												Assert.Null(parameters);
								}

								[Fact]
								public void CreatePackageParametersFromEmptyString()
								{
												//arrange
												string input = Properties.Resources.EmptyParameters;
												IPackage parameters;
												//act
												parameters = _factory.CreatePackage(input);
												//assert
												Assert.Null(parameters);
								}
				}
}