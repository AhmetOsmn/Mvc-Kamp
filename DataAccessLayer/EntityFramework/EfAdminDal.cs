using DataAccessLayer.Abstract.Repository;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;


namespace DataAccessLayer.EntityFramework
{
    public class EfAdminDal : GenericRepository<Admin>, IAdminDal
    {
    }
}
