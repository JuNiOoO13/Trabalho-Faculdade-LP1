using TrabalhoCRUD_MVC.Models;

namespace TrabalhoCRUD_MVC.Services
{
    public interface IServices
    {
        public bool Create(Cliente cliente);
        public bool Update(Cliente cliente);
        public bool Delete(int id);
        public List<Cliente> Read();
        public Cliente GetById(int id);
    }
}
