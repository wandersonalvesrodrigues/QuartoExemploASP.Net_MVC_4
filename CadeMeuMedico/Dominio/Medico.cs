namespace Dominio
{
    public class Medico
    {
        public long IDMedico { get; set; }
        public string CRM { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Email { get; set; }
        public bool AtendePorConvenio { get; set; }
        public bool TemClinica { get; set; }
        public string WebsiteBlog { get; set; }
        public Cidade Cidade { get; set; }
        public Especialidade Especialidade { get; set; }
    }
}
