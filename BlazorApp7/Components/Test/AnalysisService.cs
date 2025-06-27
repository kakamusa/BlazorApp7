using Dapper;
using MySql.Data.MySqlClient;
using System.Reflection.Emit;

namespace BlazorApp7.Components.Test
{
    public class AnalysisService
    {
        string Table(string dbcode) => "sp_analysi" + dbcode; 
        public async Task<IEnumerable<AnalysisMdl>> GetAll(string dbcode, string field1, string field2)
        {
            var param = new DynamicParameters();
            string sql = "SELECT * FROM " + Table(dbcode) + " WHERE(ancode='" + field1 + "' || ancode='" + field2 +"');";
            using (var conn = new MySqlConnection("Server=localhost;Port=3310;Userid=root;Password=SUNPRO100#;Database=SUNPRODB;Sslmode=none;"))
                return await conn.QueryAsync<AnalysisMdl>(sql, param);
        }
    }
}
