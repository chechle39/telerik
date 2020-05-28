using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class E08T_WorkingOrder_InfoRepository : Repository<E08T_WorkingOrder_Info>, IE08T_WorkingOrder_InfoRepository
    {
        public E08T_WorkingOrder_InfoRepository(DbContext db) : base(db)
        {

        }

        public async Task<List<E08T_WorkingOrder_InfoCbbViewModel>> E08T_WorkingOrder_InfoCbb(string start, string end)
        {
            var e08T_WorkingOrder_InfoList = new List<E08T_WorkingOrder_InfoCbbViewModel>();
            if (start == null && end == null)
            {
                var endDate = DateTime.Now;
                var startDate = DateTime.Now.AddDays(-10);
                await SearchDataByDate(e08T_WorkingOrder_InfoList, endDate, startDate);

            }
            else
            {
                DateTime startDate = DateTime.Parse(start, new CultureInfo("vi-VN"));
                DateTime endDate = DateTime.Parse(end, new CultureInfo("vi-VN"));
                await SearchDataByDate(e08T_WorkingOrder_InfoList, endDate, startDate);
            }
            return e08T_WorkingOrder_InfoList;
        }

        private async Task SearchDataByDate(List<E08T_WorkingOrder_InfoCbbViewModel> e08T_WorkingOrder_InfoList, DateTime endDate, DateTime startDate)
        {
            var data = await Entities.Where(x => x.DateCreate <= endDate && x.DateCreate >= startDate).ToListAsync();
            foreach (var item in data)
            {
                var itemDate = item.DateCreate;
                e08T_WorkingOrder_InfoList.Add(new E08T_WorkingOrder_InfoCbbViewModel()
                {
                    WOID = item.WOID,
                    EmpID = item.EmpID,
                    LabID = item.LabID,
                    Specification = item.Specification,
                    DateCreate = item.DateCreate,
                    WOIDPlusDate = item.WOID + "-" + itemDate.ToString("dd/MM/yyyy hh:mm")
                });
            }
        }
    }
}
