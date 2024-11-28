using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList(string p);
        List<Content> GetListWriter(int id);
        void ContentAdd(Content content);
        Content GetByID(int id);
        List<Content> GetListByHeadingID(int id);

        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}
