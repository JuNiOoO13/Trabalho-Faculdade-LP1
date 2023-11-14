using System.Runtime.InteropServices;
using TrabalhoCRUD_MVC.DAl;
using TrabalhoCRUD_MVC.Models;

namespace TrabalhoCRUD_MVC.Services
{
    public class Services:IServices
    {
        private readonly ICRUD_DAL _clientDAL;

        public Services(ICRUD_DAL clientDAL)
        {
            _clientDAL = clientDAL;
        }

        public bool Create(Cliente cliente)
        {

            var result = _clientDAL.Create(cliente);
            return result;
        }


        public bool Update(Cliente cliente)
        {
            if (_clientDAL.ReadByID(cliente.IdCliente) != null)
            {
                return _clientDAL.Update(cliente);
            }
            return false;
         
        }

        public bool Delete(int id)
        {
            if (_clientDAL.ReadByID(id) != null)
            {
                return _clientDAL.Delete(id);
            }
            return false;
        }

        public List<Cliente>? Read()
        {
            return _clientDAL.Read();
        }

        public Cliente? GetById(int id)
        {
            return _clientDAL.ReadByID(id);
        }
    }
}
