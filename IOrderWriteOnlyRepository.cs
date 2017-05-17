using MOK.Models;

namespace MOK.Interfaces.Repositories
{
    public interface IOrderWriteOnlyRepository 
    {
        void AddOrder(OrderInputModel model);
    }
}