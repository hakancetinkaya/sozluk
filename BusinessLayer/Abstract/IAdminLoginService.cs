using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IAdminLoginService
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin );
        Admin GetUserNameAndPassword(string username, string password);
        Admin GetByUserName(string username);
        Admin GetById(int id);
        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
