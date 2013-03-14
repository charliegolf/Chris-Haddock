
namespace Haddock.Core
{
    public interface IDatabaseSessionRepository : ISessionRepository
    {
        string ConnectionString { get; set; }
    }
}
