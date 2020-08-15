namespace PoC.WebUI.ViewModel
{    
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;    

    public class ClienteViewModel : BaseViewModel
    {        
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório")]        
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public string Nome { get; set; }        
    }
}