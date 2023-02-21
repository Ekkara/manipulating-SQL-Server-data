using iTunesWannabe.Models;
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
        public List<T> GetPage(int range, int offset);
        public T GetById(int id);
        public List<T> GetAllByName(string name);
        public T GetOneByName(string name);
    }
}
