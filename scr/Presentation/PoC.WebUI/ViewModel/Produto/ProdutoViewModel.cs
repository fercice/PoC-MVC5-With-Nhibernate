namespace PoC.WebUI.ViewModel
{
    using System.ComponentModel.DataAnnotations;    

    public class ProdutoViewModel : BaseViewModel
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O Nome é obrigatório")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public string Nome { get; set; }
    }
}