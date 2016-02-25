using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CadeMeuMedicoMVC.Models
{
    public class MedicoViewModel
    {
        public long IDMedico { get; set; }
        [Required(ErrorMessage = "O CRM é obrigatório")]
        [StringLength(30, ErrorMessage = "O CRM aceita até 30 caracteres")]
        public string CRM { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(80, ErrorMessage = "O Nome aceita até 80 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Endereço Obrigatório")]
        [StringLength(100, ErrorMessage = "O Endereço aceita até 100 caracteres")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório")]
        [StringLength(60, ErrorMessage = "O Bairro aceita até 60 caracteres")]
        public string Bairro { get; set; }
        [StringLength(100, ErrorMessage = "O E-mail aceita até 100 caracteres")]
        public string Email { get; set; }
        public bool AtendePorConvenio { get; set; }
        public bool TemClinica { get; set; }
        [StringLength(80, ErrorMessage = "O Blog aceita até 80 caracteres")]
        public string WebsiteBlog { get; set; }
        [Required(ErrorMessage = "A Cidade é obrigatória")]
        public int IDCidade { get; set; }
        [Required(ErrorMessage = "A Especialidade é obrigatória")]
        public int IDEspecialidade { get; set; }
    }
}