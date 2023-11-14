using TrabalhoCRUD_MVC.Models;

namespace TrabalhoCRUD_MVC.DAl
{
    public interface ICRUD_DAL
    {
        public bool Create(Cliente cliente);
        public List<Cliente> Read();
        public Cliente ReadByID(int id);
        public bool Update(Cliente cliente);
        public bool Delete(int id);
    }
}
