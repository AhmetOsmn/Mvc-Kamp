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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }


        public void AddContent(Content content)
        {
           _contentDal.Create(content);
        }

        public void DeleteContent(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetContentByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> GetContentList(string filter)
        {
            return _contentDal.Read(x => x.ContentValue.Contains(filter));
        }

        public List<Content> GetContentList()
        {
            return _contentDal.ReadAll();
        }

        public List<Content> GetContentListByHeadingID(int id)
        {
            return _contentDal.Read(x => x.HeadingID == id);
        }

        public List<Content> GetContentListByWriter(int id)
        {
            return _contentDal.Read(x => x.WriterID == id);
        }

        public void UpdateContent(Content content)
        {
            throw new NotImplementedException();
        }
    }
}
