using AutoMapper;
using AutoMapper.QueryableExtensions;
using DRLab.Data.Base;
using DRLab.Data.Entities;
using DRLab.Data.Interfaces;
using DRLab.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DRLab.Data.Repositories
{
    public class FieldAutoTableRepository: Repository<FieldAutoTable>, IFieldAutoTableRepository
    {
        private readonly IUnitOfWork _uow;
        public FieldAutoTableRepository(DbContext db, IUnitOfWork uow) : base(db)
        {
            _uow = uow;
        }

        public async Task<bool> CreateTable(List<FieldAutoTableViewModel> request)
        {
            var maprequest = Mapper.Map<List<FieldAutoTableViewModel>, List<FieldAutoTable>>(request);
            await Delete(request[0].SampleCode);
            Entities.AddRange(maprequest);
            return await Task.FromResult(true);
        }

        public async Task<bool> Delete(string request)
        {
            var listDl = await Entities.AsNoTracking().Where(x => x.SampleCode == request).ToListAsync();
            Entities.RemoveRange(listDl);
            _uow.SaveChanges();
            return await Task.FromResult(true);
        }
        public async Task<List<RubberClassification>> GetFieldTableByCode(string code)
        {
            var data = await Entities.AsNoTracking().Where(x => x.SampleCode == code).ProjectTo<FieldAutoTableViewModel>().OrderBy(x => x.Denominator).ToListAsync();
            List<string> _names = new List<string>();

            List<decimal[]> _dataArray = new List<decimal[]>();
            for (int i = 0; i < data.Count(); i++)
            {
                if (i == 0)
                {
                    _names.Add(data[i].ColumName);
                    var bb = data.Where(y => y.ColumName == data[i].ColumName).ToList();
                    decimal[] d = new decimal[bb.Count()];
                    for (int ii = 0; ii < bb.Count(); ii++)
                    {
                        d[ii] = (decimal)bb[ii].Value;
                    }
                    _dataArray.Add(d);
                }
                else
                {
                    var check = _names.Where(z => z == data[i].ColumName);
                    if (check.Count() > 0)
                    {

                    }
                    else
                    {
                        _names.Add(data[i].ColumName);
                        var bb = data.Where(y => y.ColumName == data[i].ColumName).ToList();
                        decimal[] d = new decimal[bb.Count()];
                        for (int ii = 0; ii < bb.Count(); ii++)
                        {
                            d[ii] = (decimal)bb[ii].Value;
                        }
                        _dataArray.Add(d);
                    }
                }

            }
            var listTable = GetResultsTable(_dataArray, _names);
            List<RubberClassification> RubberClassification = new List<RubberClassification>();
            for (int i = 0; i < listTable.Rows.Count; i++)
            {
                RubberClassification rb = new RubberClassification();
                rb.Ash = listTable.Rows[i]["Ash"].ToString();
                rb.Color = listTable.Rows[i]["Color"].ToString();
                rb.Dirt = listTable.Rows[i]["Dirt"].ToString();
                rb.ML = listTable.Rows[i]["ML"].ToString();
                rb.Nitro = listTable.Rows[i]["Nitro"].ToString();
                rb.P0 = listTable.Rows[i]["P0"].ToString();
                rb.PRI = listTable.Rows[i]["PRI"].ToString();
                rb.Volatilematter = listTable.Rows[i]["Volatilematter"].ToString();
                RubberClassification.Add(rb);
            }
             
            return RubberClassification;
        }
        public static DataTable GetResultsTable(List<decimal[]> _dataArray, List<string> _names)
        {
            DataTable d = new DataTable();

            for (int i = 0; i < _dataArray.Count; i++)
            {
                string name = _names[i];

                d.Columns.Add(name);

                List<object> objectNumbers = new List<object>();

                foreach (double number in _dataArray[i])
                {
                    objectNumbers.Add((object)number);
                }

                while (d.Rows.Count < objectNumbers.Count)
                {
                    d.Rows.Add();
                }

                for (int a = 0; a < objectNumbers.Count; a++)
                {
                    d.Rows[a][i] = objectNumbers[a];
                }
            }
            return d;
        }

        public bool plus(List<RubberClassification> rubberClassification, string patternBackground)
        {
            var report = new List<ReportData>();
            switch(patternBackground)
            {
                case "5S":
                    foreach(var item in rubberClassification)
                    {
                        var obj = new ReportData()
                        {
                            specCode = "xx",
                        };
                    }
                    break;
            }
                
            return true;
        }
    }
}
