namespace RepositoryReader
{
    public interface IRepositoryReader
    {
        Task<IEnumerable<IPackageParameters>> Packages { get; set; }
    }
}