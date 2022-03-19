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
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void AddWriter(Writer writer)
        {
            _writerDal.Create(writer);
        }

        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer GetWriterByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetWriterList()
        {
            return _writerDal.ReadAll();
        }

        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
