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
            string[] arr = ["0001", "0002", "0003"]; 
            var param = new DynamicParameters();
            param.Add("@ancodes", arr.ToList());
            string sql = "SELECT " + field1 + "," + field2 + " FROM " + Table(dbcode) + " WHERE ancode in @ancodes;";
            using (var conn = new MySqlConnection("Server=localhost;Port=3310;Userid=root;Password=SUNPRO100#;Database=SUNPRODB;Sslmode=none;"))
                return await conn.QueryAsync<AnalysisMdl>(sql, param);
        }
    }
}
