using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BlogAppDataAccess
{
    
    public class KategoriDbContext   
    {
        private readonly IConfiguration _configuration;
        private readonly string _conntectionString;
        public KategoriDbContext(IConfiguration configuration)
        {

            _configuration = configuration;

            _conntectionString = _configuration.GetConnectionString("SqlConnection");
            
        }

        public IDbConnection CreateConnection() => new SqlConnection(_conntectionString);
        
        
        }
        
       
    }

  