using Dapper;
using DRLab.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class GetRequestNoDapperService : IGetRequestNoDapperService
    {
        private readonly IConfiguration _configuration;

        public GetRequestNoDapperService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> GetRequestNo(string request)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();


                dynamicParameters.Add("@CounterCode", request);

                var rqNo = await sqlConnection.QueryAsync<string>(
                         "GetCounter", dynamicParameters, commandType: CommandType.StoredProcedure);
                return rqNo.ToList()[0].ToString();
            }
        }
    }
}
