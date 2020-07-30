using Dapper;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class SampleManagementReportDapperService : ISampleManagementReportDapper
    {
        private readonly IConfiguration _configuration;
        public SampleManagementReportDapperService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<SampleManagementReportViewModel>> GetRequestManagementReport(string requestNo)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();             
                dynamicParameters.Add("@requestNumber", requestNo);                
                return await sqlConnection.QueryAsync<SampleManagementReportViewModel>(
                         "GetReportRequestManagement", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
        public async Task<IEnumerable<SampleManagementExportViewModel>> GetSampleManagementReport(string requestNo)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@requestNumber", requestNo);
               return await sqlConnection.QueryAsync<SampleManagementExportViewModel>(
                         "GetReportSampleManagement", dynamicParameters, commandType: CommandType.StoredProcedure);
              
            }
        }

    }
}
