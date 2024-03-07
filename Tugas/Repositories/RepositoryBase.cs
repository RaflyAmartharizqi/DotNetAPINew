using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Tugas.Interfaces;
using Tugas.Models.Entity;

namespace Tugas.Repositories
{
    public class RepositoryBase : IRepositoryBase
    {
        protected readonly DBConnection _dbConnection;

        public RepositoryBase(DBConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public virtual async Task<IEnumerable<dynamic>> GetAllData()
        {
            return await _dbConnection.Students.FromSqlRaw($"SELECT * FROM students").ToListAsync();
        }

        public async Task<dynamic> Get(int Id)
        {
            return await _dbConnection.Students.FromSqlRaw($"SELECT * FROM students WHERE Id={Id}").FirstAsync();
        }


        public async Task<dynamic> Create(IEnumerable<StudentModel> studentModels)
        {
            try
            {
                await _dbConnection.Set<StudentModel>().AddRangeAsync(studentModels);
                await _dbConnection.SaveChangesAsync();

                return null;
            }
            catch (Exception ex)
            {
                return ex.Message; 
            }
        }



        //public async Task<IEnumerable<dynamic>> Create(IEnumerable<StudentModel> studentModels)
        //{
        //    List<dynamic> results = new List<dynamic>();

        //        // Membangun pernyataan SQL untuk menyisipkan semua data sekaligus
        //        string sql = "INSERT INTO Students (Name, Age) VALUES ";

        //        // Menambahkan setiap nilai data ke pernyataan SQL
        //        sql += string.Join(", ", studentModels.Select(s => $"('{s.Name}', {s.Age})"));

        //        // Menjalankan pernyataan SQL
        //        await _dbConnection.Database.ExecuteSqlRawAsync(sql);

        //    return null;
        //}
    }
}
