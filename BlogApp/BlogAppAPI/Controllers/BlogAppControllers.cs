using BlogAppBusiness.Abstract;
using BlogAppDataAccess.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAppAPI.Controllers
{
    [Route("api/kategoriler")]
    [ApiController]
    public class BlogAppControllers : ControllerBase
    {
        private readonly IBlogService __kategori;

        public BlogAppControllers(IBlogService kategori) => __kategori = kategori;
         
        [HttpGet]
        public async Task<IActionResult> GetKategories()
        {
            var kategoriler = await __kategori.GetAllKategori();
            return Ok(kategoriler);
        }

        [HttpGet("{id}" , Name ="KategoriByID")]
        public async Task<IActionResult> GetKategori(int id)
        {
            var kategori = await __kategori.GetKategoriByID(id);

            if(kategori is null)
            {
                return NotFound();

            }
            else
            {
                return Ok(kategori);
            }
        }

       

        [HttpGet("{id}/MultipleResult")]
        public async Task<IActionResult> GetMultipleResults(int id)
        {
            var kategori = await __kategori.GetMultipleResult(id);
            if(kategori is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(kategori); 

            }
        }


        [HttpGet("MultipleResult")]
        public async Task<IActionResult> GetMultipleMapping()
        {
            var kategoriler = await __kategori.GetMultipleMapping();
            
                return Ok(kategoriler);

            
        }
    }
}
    