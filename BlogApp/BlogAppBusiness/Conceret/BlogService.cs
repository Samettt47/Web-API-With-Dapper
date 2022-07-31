using BlogAppBusiness.Abstract;
using BlogAppDataAccess.Abstract;
using BlogAppEntitites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppBusiness.Conceret
{
    public class BlogService : IBlogService
    {
        private readonly IKategoriRepository _kategorirepository;

        public BlogService(IKategoriRepository kategoriRepository) => _kategorirepository = kategoriRepository;
        


        public async Task<IEnumerable<Kategorilerr>> GetAllKategori()
        {
            return await _kategorirepository.GetAllKategori();
        }

        public async Task<Kategorilerr> GetKategoriByID(int id)
        {
            return await _kategorirepository.GetKategoriByID(id);
        }

       

        public async Task<List<Kategorilerr>> GetMultipleMapping()
        {
            return await _kategorirepository.GetMultipleMapping();
        }

        public async Task<Kategorilerr> GetMultipleResult(int id)
        {
            return await _kategorirepository.GetMultipleResult(id);
        }
    }
}
