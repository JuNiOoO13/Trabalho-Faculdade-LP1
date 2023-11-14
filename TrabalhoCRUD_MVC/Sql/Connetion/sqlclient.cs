using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabalhoCRUD_MVC.SQLClient
{
    public class Data
    {
        /* private static string stringConexao = @"Data source = (nome da máquina);
                                               Initial Catalog = VendaLanchesBD;
                                               Integrated Security = true;";
                                               User ID = (usuario windows ou SQL) ; Password = (senha windows ou SQL);*/


        private static string stringConexao = @"Data source = DESKTOP-NKP3RKN\SQLEXPRESS01;
                                              Initial Catalog = TrabalhoLP1;
                                              Integrated Security = true;";

        private static SqlConnection conexaoDB = null;

        public static SqlConnection conectarBancodados()
        {
             /*Instanciando o objeto conexaoDB e passando para o Construtor da Classe SqlConnection*/
            conexaoDB = new SqlConnection(stringConexao);

            try
            {
                //Abrir o Banco de Dados
                conexaoDB.Open();
                Console.WriteLine("Conecxão feita com sucesso");

            }
            catch(Exception erro)
            {
                //erro da conexão com banco
                conexaoDB = null;
                Console.WriteLine("Concexão Error: " + erro);

            }

            /*retorna a conexão com Banco de Dados se deu certo ou retorna null se não conectou com o BD*/
            return conexaoDB;

                    
        }

        //fechando conexão com banco de dados
        public static void FecharConexaoBD()
        {
            if (conexaoDB != null)
            {
                conexaoDB.Close();
            }

        }


    }
}