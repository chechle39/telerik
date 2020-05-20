using Dapper;
using DRLab.Data.ViewModels;
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
        public async Task<Couter> GetRequestNo(string[] request)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                var counter = new Couter();
                foreach (var item in request)
                {
                    if (item == "RequestNo")
                    {
                        dynamicParameters.Add("@CounterCode", item);
                        var rq = await sqlConnection.QueryAsync<string>(
                                 "GetCounter", dynamicParameters, commandType: CommandType.StoredProcedure);
                        counter.requestNo = rq.ToList()[0].ToString();
                    }
                    if (item == "SampleCode")
                    {
                        dynamicParameters.Add("@CounterCode", item);
                        var rq = await sqlConnection.QueryAsync<string>(
                                 "GetCounter", dynamicParameters, commandType: CommandType.StoredProcedure);
                        counter.sampleCode = rq.ToList()[0].ToString();
                    }
                    if (item == "InLabCode")
                    {
                        dynamicParameters.Add("@CounterCode", item);
                        var rq = await sqlConnection.QueryAsync<string>(
                                 "GetCounter", dynamicParameters, commandType: CommandType.StoredProcedure);
                        counter.inLabCode = rq.ToList()[0].ToString();
                    }
                }
               
                return counter;
            }
        }
    }
}
