using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
     public class EntidadeBase
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Cadastro")]
        public DateTime DateCriation { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de alteração")]
        public DateTime? DateUpdate { get; set; }

        [Display(Name = "Excluido ?")]
        public bool Excluded { get; set; }

        public EntidadeBase()
        {
            DateCriation = DateTime.UtcNow;
        }

        public void Delete()
        {
            Excluded = true;
        }
    }
}