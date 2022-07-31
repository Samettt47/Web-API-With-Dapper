using BlogAppEntitites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDataAccess.Abstract
{
    public interface IKategoriRepository
    {
        public Task<IEnumerable<Kategorilerr>> GetAllKategori();
        public Task<Kategorilerr> GetKategoriByID(int id);
        

        public Task<Kategorilerr> GetMultipleResult(int id);
        public Task<List<Kategorilerr>> GetMultipleMapping();
    }
}
