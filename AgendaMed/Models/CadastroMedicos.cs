using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgendaMed.Models
{
    [Table("Cadastrar Médico")]
    public class CadastroMedicos
    {
        [Column("Id")]
        [Display(Name="Código")]
        public int Id { get; set; }

        [Column("Name")]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Column("CRM")]
        [Display(Name = "CRM")]
        public int CRM { get; set; }
    }
}
