namespace RepositoryReader
{
    public interface IPackageRepository
    {
								string Name { get; set; }				

								string BaseUri { get; set; }

								string GpgKeyUri { get; set; }

        Task<IEnumerable<IPackageParameters>> Packages { get; set; }
    }
}