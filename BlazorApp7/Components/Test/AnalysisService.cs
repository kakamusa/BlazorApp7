using Dapper;
using MySql.Data.MySqlClient;
using System.Reflection.Emit;

namespace BlazorApp7.Components.Test
{
    public class AnalysisService
    {
        public async Task<IEnumerable<AnalysisMdl>> GetAll()
        {
            string[] arr = ["0001", "0002", "0003"];
            var param = new DynamicParameters();
            param.Add("@ancodes", arr.ToList());
            string sql = "SELECT * FROM sp_analysis WHERE ancode in @ancodes;";
            using (var conn = new MySqlConnection("Server=localhost;Port=3310;Userid=root;Password=SUNPRO100#;Database=SUNPRODB;Sslmode=none;"))
                return await conn.QueryAsync<AnalysisMdl>(sql, param);
        }
    }
}
