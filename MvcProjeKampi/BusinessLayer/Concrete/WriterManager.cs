using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerlDal;

        public WriterManager(IWriterDal writerlDal)
        {
            _writerlDal = writerlDal;
        }
        //ID ye göre getirmek için kullanılır
        public Writer GetByID(int id)
        {
            return _writerlDal.Get(x=>x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return _writerlDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            _writerlDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            _writerlDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            _writerlDal.Update(writer);
        }
    }
}
