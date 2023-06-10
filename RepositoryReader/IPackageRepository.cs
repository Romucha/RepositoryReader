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
								string Name { get; set; }				

								/// <summary>
								/// Url of repository.
								/// </summary>
								Uri BaseUri { get; set; }

								/// <summary>
								/// Url of gpg of repository.
								/// </summary>
								Uri GpgKeyUri { get; set; }

								/// <summary>
								/// Packages stored in repository.
								/// </summary>
        IEnumerable<IPackageParameters> Packages { get; set; }
    }
}