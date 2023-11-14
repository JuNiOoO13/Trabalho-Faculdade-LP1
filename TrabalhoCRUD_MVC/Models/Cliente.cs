using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TrabalhoCRUD_MVC.Models;

public class Cliente
{
    public int IdCliente { get; set; }

    [Required(ErrorMessage = "Informe um Nome")]
    [DisplayName("Nome de Usuario")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Informe um Nome")]
    [EmailAddress(ErrorMessage = "Informe Um Email Valido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Informe Uma Senha")]
    public string Senha { get; set; }



}