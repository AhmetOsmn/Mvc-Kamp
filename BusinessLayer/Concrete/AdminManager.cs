using BusinessLayer.Abstract;
using DataAccessLayer.Abstract.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddAdmin(Admin admin)
        {
            _adminDal.Create(admin);
        }

        public void DeleteAdmin(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public Admin GetadminByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetAdminList()
        {
            return _adminDal.ReadAll();
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
