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
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeading(Heading heading)
        {
            _headingDal.Create(heading);
        }

        public void DeleteHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public Heading GetHeadingByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.ReadAll();
        }

        public void UpdateHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void ActiveHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public List<Heading> GetHeadingListByWriter(int id)
        {
            return _headingDal.Read(x => x.WriterID == id);
        }
    }
}
