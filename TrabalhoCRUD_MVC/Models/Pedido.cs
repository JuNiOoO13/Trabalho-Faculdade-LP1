using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrabalhoCRUD_MVC.Models;

public class Pedido
{
    public int IdPedido { get; set; }

    public int IdCliente { get; set; }

    public DateTime Data { get; set; }

    public int Status { get; set; }

    //toda lista tem pelo menos um item (Produto)
    public List<Itens_Pedido> Itens { get; set; } = new List<Itens_Pedido>();

    public decimal TotalPedido
    {
        get
        {
            return Itens.Sum(i => i.ValorTotal);
        }
    }


}