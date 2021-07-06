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
    public class HeadingManager : IHeadingService
    {   
        IHeadingDal _heaidngDal;

        public HeadingManager(IHeadingDal heaidngDal)
        {
            _heaidngDal = heaidngDal;
        }

        public Heading GetById(int id)
        {
            return _heaidngDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _heaidngDal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _heaidngDal.List(x =>x.WriterID==id);
                }

        public void HeadingAdd(Heading heading)
        {
            _heaidngDal.Insert(heading);
                }

        public void HeadingUpdate(Heading heading)
        {
            _heaidngDal.Update(heading);
        }

        public void HeaidingDelete(Heading heading)
        {
            _heaidngDal.Update(heading);
        }

    }
}
