using AutoMapper;
using DRLab.Data.Entities;
using DRLab.Data.ViewModels;

namespace DRLab.Services.Mappers
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<E08T_AnalysisRequest_Info, E08T_AnalysisRequest_InfoViewModel>();
            CreateMap<E08T_Testing_Data, E08T_Testing_DataViewModel>();
            CreateMap<E08T_Testing_Info, E08T_Testing_InfoViewModel>();
            CreateMap<E00T_Specification,E00T_SpecificationViewModel>();
            CreateMap<E00T_Customer, E00T_CustomerViewModel>();
            CreateMap<E00T_Customer_Item, E00T_Customer_ItemViewModel>();
            CreateMap<E00T_SampleMatrix, E00T_SampleMatrixViewModel>();
            CreateMap<E08T_AnalysisRequest_Item, E08T_AnalysisRequest_ItemViewModel>();
            CreateMap<E08T_AnalysisRequest_Data, E00T_CustomerGridViewModel>();
        }
    }
}
