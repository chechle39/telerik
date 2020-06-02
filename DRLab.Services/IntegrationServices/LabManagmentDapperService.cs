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
    public class LabManagmentDapperService : ILabManagmentDapperService
    {
        private readonly IConfiguration _configuration;
        public LabManagmentDapperService(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<LabManagmentViewModel>> GetLabManagment(SerchGridManagement rq)
        {
            using (var sqlConnection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                await sqlConnection.OpenAsync();
                var dynamicParameters = new DynamicParameters();
                DateTime from = DateTime.Parse(rq.StartDate, new CultureInfo("vi-VN"));
                DateTime end = DateTime.Parse(rq.EndDate, new CultureInfo("vi-VN"));
                dynamicParameters.Add("@fromDate", from);
                dynamicParameters.Add("@toDate", end);
                return await sqlConnection.QueryAsync<LabManagmentViewModel>(
                         "GetLabManagment", dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
