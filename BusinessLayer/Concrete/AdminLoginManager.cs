using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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
        IAdminLoginDal _adminLoginDal;

        public AdminLoginManager(IAdminLoginDal adminLoginDal)
        {
            _adminLoginDal = adminLoginDal;
        }

        public void AdminAdd(Admin admin)
        {
            _adminLoginDal.Insert(admin);
        }

        public void AdminDelete(Admin admin)
        {
            _adminLoginDal.Delete(admin);
        }

        public void AdminUpdate(Admin admin)
        {
            _adminLoginDal.Update(admin);
        }

        public Admin GetById(int id)
        {
            return _adminLoginDal.Get(x => x.AdminId == id);
        }

        public Admin GetByUserName(string username)
        {
           return _adminLoginDal.Get(x => x.AdminUserName == username);
        }

        public List<Admin> GetList()
        {
            return _adminLoginDal.List();
        }

        public Admin GetUserNameAndPassword(string username, string password)
        {
            return _adminLoginDal.Get(x => x.AdminUserName == username && x.AdminPassword == password);
        }
    }
}
