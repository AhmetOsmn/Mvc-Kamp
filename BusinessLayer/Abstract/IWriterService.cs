using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetWriterList();
        void AddWriter(Writer writer);
        Writer GetWriterByID(int id);
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
    }
}
