using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        List<Heading> GetHeadingListByWriter(int id);
        void AddHeading(Heading heading);
        Heading GetHeadingByID(int id);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
    }
}
