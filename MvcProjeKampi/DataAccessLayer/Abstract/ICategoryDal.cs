using EntitiyLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDal:IRepository<Category>
    {
        //CRUD İŞLEMLERİ BURADA YAPILACAK
        //Type Name();
        //List yerine Listelemede veya başka birşeyde yazılabilir ingilizce bir ifade olsun diye böyle yaptık.Kafan Karışmasın
        //List<Category> List();
        //void Insert(Category p);
        //void Update(Category p);
        //void Delete(Category p); 

        //IRepositoryden kalıtım alarak yukarıdaki hiç bir şeye gerek kalmadı .


    }
}
