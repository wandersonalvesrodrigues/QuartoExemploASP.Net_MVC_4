using System.Collections.Generic;
namespace Dominio
{
    public class Cidade
    {
        public int IDCidade { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
