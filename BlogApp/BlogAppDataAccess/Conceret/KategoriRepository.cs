using BlogAppDataAccess.Abstract;
using BlogAppEntitites;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogAppDataAccess.Conceret
{
    public class KategoriRepository : IKategoriRepository 
    {

        private readonly KategoriDbContext _context;


        public KategoriRepository(KategoriDbContext context) => _context = context;

        
        public async Task<IEnumerable<Kategorilerr>> GetAllKategori()
        {
            var squery = @"Select KategoriID,Kategoriler   FROM Kategorilerr";
            using (var dbconncetion = _context.CreateConnection())
            {
                var Kategori = await dbconncetion.QueryAsync<Kategorilerr>(squery);
                return Kategori.ToList();
            }
        }
            
        public async Task<Kategorilerr> GetKategoriByID(int id)
        {
            var query = @"Select * FROM Kategorilerr WHERE KategoriID = @id";

            using (var dbconnect = _context.CreateConnection())
            {
                var kategori = await dbconnect.QuerySingleOrDefaultAsync<Kategorilerr>(query,new { id });
                return kategori;
            }   

        }

       

        public async Task<List<Kategorilerr>> GetMultipleMapping()
        {
            var query = "Select *  from Kategorilerr k join Yazilar y on k.KategoriID = y.KategoriId ";

            
            using (var dbconnect = _context.CreateConnection())
            {

                var kategoridict = new Dictionary<int, Kategorilerr>();

                var kategoriler = await dbconnect.QueryAsync<Kategorilerr, Yazilar, Kategorilerr>
                (query, (kategorilerr, yazilar) =>
               {
                   if (!kategoridict.TryGetValue(kategorilerr.KategoriID, out var currentKategorilerr))
                   {
                       currentKategorilerr = kategorilerr;
                       kategoridict.Add(currentKategorilerr.KategoriID, currentKategorilerr);
                   }

                   currentKategorilerr.Yazilar.Add(yazilar);

                   return currentKategorilerr;
               },
               splitOn:"KategoriID,YazilarID"
              );
                return kategoriler.Distinct().ToList();


            }

        }

        public async Task<Kategorilerr> GetMultipleResult(int id)
        {
            var query = "SELECT * FROM Kategorilerr WHERE KategoriID = @id " +
               "SELECT * FROM Yazilar WHERE KategoriId = @id";

            using (var dbconnect = _context.CreateConnection())
            using (var multi = await dbconnect.QueryMultipleAsync(query, new { id }))
            {
                var kategori = await multi.ReadSingleOrDefaultAsync<Kategorilerr>();
               
                if(kategori != null)
                {

                    kategori.Yazilar = (await multi.ReadAsync<Yazilar>()).ToList();

                }
                return kategori;



            }

        }

       
    }
}
