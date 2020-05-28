using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Interfaces
{
    public interface IE08T_WorkingOrder_InfoRepository
    {
        Task<List<E08T_WorkingOrder_InfoCbbViewModel>> E08T_WorkingOrder_InfoCbb(string start, string end);
    }
}
