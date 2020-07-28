using Dapper;
using DRLab.Data.ViewModels;
using DRLab.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Services.IntegrationServices
{
    public class SampleManagementDapperService : ISampleManagementDapperService
    {
        private readonly IConfiguration _configuration;
        public SampleManagementDapperService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }  

        public async Task<IEnumerable<SampleManagementViewModel>> GetSampleManagement(SerchSampleManagement rq)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                DateTime from = DateTime.Parse(rq.StartDate, new CultureInfo("vi-VN"));
                DateTime end = DateTime.Parse(rq.EndDate, new CultureInfo("vi-VN")).AddHours(23).AddMinutes(59).AddSeconds(59);
                dynamicParameters.Add("@fromDate", from);
                dynamicParameters.Add("@toDate", end);
                var result = await sqlConnection.QueryAsync<SampleManagementViewModel>(
                         "GetSampleManagement", dynamicParameters, commandType: CommandType.StoredProcedure);
                var listResult = new List<SampleManagementViewModel>();
                var listReturn = new List<SampleManagementViewModel>();
                listResult = listReturn = (List<SampleManagementViewModel>)result;
                string[] resultArray = Newtonsoft.Json.JsonConvert.DeserializeObject<string[]>(rq.Customer[0]);
                listResult = (List<SampleManagementViewModel>)result;
                if (resultArray.Count() > 0) {
                    listReturn = new List<SampleManagementViewModel>(); 
                    for (int i = 0; i < listResult.Count(); i++)
                    {
                        for (int j = 0; j < resultArray.Count(); j++)
                        {
                            if (listResult[i].companyName == resultArray[j])
                            {
                                listReturn.Add(listResult[i]);
                            }
                        }
                    }
                }
                return listReturn;
            }
        }
        public async Task<IEnumerable<SampleManagementExportViewModel>> GetSampleManagementExport(SerchSampleManagement rq)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                DateTime from = DateTime.Parse(rq.StartDate, new CultureInfo("vi-VN"));
                DateTime end = DateTime.Parse(rq.EndDate, new CultureInfo("vi-VN")).AddHours(23).AddMinutes(59).AddSeconds(59);
                dynamicParameters.Add("@fromDate", from);
                dynamicParameters.Add("@toDate", end);
                return  await sqlConnection.QueryAsync<SampleManagementExportViewModel>(
                         "GenaralData", dynamicParameters, commandType: CommandType.StoredProcedure);                
            }
        }
    }
}
