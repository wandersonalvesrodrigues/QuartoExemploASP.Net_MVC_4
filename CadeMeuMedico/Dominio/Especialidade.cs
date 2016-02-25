using System.Collections.Generic;

namespace Dominio
{
    public class Especialidade
    {
        public int IDEspecialidade { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
