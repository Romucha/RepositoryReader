namespace RepositoryReader
{
				/// <summary>
				/// Represents repository of packages.
				/// </summary>
    public interface IPackageRepository
    {
								/// <summary>
								/// Name of repository.
								/// </summary>
								string Name { get; }				

								/// <summary>
								/// Url of repository.
								/// </summary>
								Uri BaseUri { get; }

								/// <summary>
								/// Url of gpg of repository.
								/// </summary>
								Uri GpgKeyUri { get; }

								/// <summary>
								/// Determines if the repository can be managed by user.
								/// </summary>
								bool IsManageable { get; }

								/// <summary>
								/// Port to manage repository.
								/// </summary>
								int Port { get; }

								/// <summary>
								/// Packages stored in repository.
								/// </summary>
        IEnumerable<IPackage> Packages { get; }

								IPackageRepository WithSettings(IPackageRepositorySettings Settings);

								/// <summary>
								/// Get packages from repository and puts them into collection.
								/// </summary>
								/// <returns></returns>
								Task GetPackages();
    }
}