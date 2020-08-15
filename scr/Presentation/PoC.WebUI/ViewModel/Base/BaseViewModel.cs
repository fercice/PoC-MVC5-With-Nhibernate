namespace PoC.WebUI.ViewModel
{
    using System.ComponentModel.DataAnnotations;

    public class BaseViewModel
    {
        [Key]
        public int Id { get; set; }
    }
}