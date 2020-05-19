using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IGetRequestNoDapperService
    {
        Task<string> GetRequestNo(string request);
    }
}
