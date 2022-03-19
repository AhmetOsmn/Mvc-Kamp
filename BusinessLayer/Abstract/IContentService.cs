using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetContentList(string filter);
        List<Content> GetContentList();
        List<Content> GetContentListByWriter(int id);
        List<Content> GetContentListByHeadingID(int id);
        void AddContent(Content content);
        Content GetContentByID(int id);
        void DeleteContent(Content content);
        void UpdateContent(Content content);
    }
}
