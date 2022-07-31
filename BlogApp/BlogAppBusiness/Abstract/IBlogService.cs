using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BlogAppEntitites;

namespace BlogAppBusiness.Abstract
{
    public interface IBlogService
    {
        public Task<IEnumerable<Kategorilerr>> GetAllKategori();
        public Task<Kategorilerr> GetKategoriByID(int id);
        

        public Task<Kategorilerr> GetMultipleResult(int id);
        public Task<List<Kategorilerr>> GetMultipleMapping();
    }
}
