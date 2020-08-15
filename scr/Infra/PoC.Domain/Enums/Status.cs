namespace PoC.Domain.Enums
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public enum Status
    {
        [Display(Name = "ATIVO")]
        Ativo = 'A',
        [Display(Name = "INATIVO")]
        Inativo = 'I'
    }
}
