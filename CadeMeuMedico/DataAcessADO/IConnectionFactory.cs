using System.Data;

namespace DataAcessADO
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
