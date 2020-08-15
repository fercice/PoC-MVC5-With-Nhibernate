namespace PoC.WebUI.ViewModel
{    
    using System.Collections.Generic;    

    public class CompraViewModel : BaseViewModel
    {
        public virtual ClienteViewModel Cliente { get; set; }

        public virtual ProdutoViewModel Produto { get; set; }        
    }
}