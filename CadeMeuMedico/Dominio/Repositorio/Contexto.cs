using DataAcessADO;
namespace Dominio.Repositorio
{
    public class Contexto
    {
        public static AdoNetContext GetContexto()
        {
            var factory = new AppConfigConnectionFactory("ModeloDeDados");
            return new AdoNetContext(factory);
        }
    }
}
