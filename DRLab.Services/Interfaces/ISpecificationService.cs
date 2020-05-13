﻿using DRLab.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DRLab.Services.Interfaces
{
    public interface ISpecificationService
    {
        Task<List<E00T_SpecificationViewModel>> GetAll();
        Task<List<E00T_SpecificationViewModel>> GetbyId(long? id);
    }
}