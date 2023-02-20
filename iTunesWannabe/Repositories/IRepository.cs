using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTunesWannabe.Repositories
{
    public interface IRepository<T>
    {
       public  List<T> GetAll();
       public T GetById(int id);

    }
}
