using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoCRUD_MVC.Models;

public class Produto
{

    public int Idproduto { get; set; }
    public String Nomeprod { get; set; }
    public string Descricao { get; set; }
    public double Valor { get; set; }
    public String UrlImagem { get; set; }
    public Categoria Categoria { get; set; }





}