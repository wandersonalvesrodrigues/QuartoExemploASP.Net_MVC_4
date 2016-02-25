using System.Data;

namespace DataAcessADO
{
    public class AdoNetContext
    {
        private readonly IDbConnection _connection;
        private readonly IConnectionFactory _connectionFactory;

        public AdoNetContext(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
            _connection = _connectionFactory.Create();
        }

        public IDbCommand CreateCommand()
        {
            var cmd = _connection.CreateCommand();
            return cmd;
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}
