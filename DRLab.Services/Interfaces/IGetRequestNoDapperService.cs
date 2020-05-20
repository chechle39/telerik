using DRLab.Data.ViewModels;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface IGetRequestNoDapperService
    {
        Task<Couter> GetRequestNo(string[] request);
    }
}
