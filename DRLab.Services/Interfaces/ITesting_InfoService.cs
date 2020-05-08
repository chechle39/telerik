using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ITesting_InfoService
    {
         Task<List<E08T_Testing_InfoViewModel>> GetAllTesting_Info();
    }
}
