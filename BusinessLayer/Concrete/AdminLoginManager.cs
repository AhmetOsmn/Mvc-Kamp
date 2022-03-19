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
    public class AdminLoginManager : IAdminLoginService
    {
        IAdminDal _adminDal;

        public AdminLoginManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public Admin GetAdmin(string userName, string password)
        {
            return _adminDal.Get(x => x.AdminUserName == userName && x.AdminPassword == password);
        }
    }
}
