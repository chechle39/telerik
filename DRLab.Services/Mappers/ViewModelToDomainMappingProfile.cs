using AutoMapper;
using DRLab.Data.Entities;
using DRLab.Data.Identity;
using DRLab.Data.ViewModels;

namespace DRLab.Services.Mappers
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {

            CreateMap<E08T_AnalysisRequest_InfoViewModel, E08T_AnalysisRequest_Info>().ConstructUsing(x => new E08T_AnalysisRequest_Info(x.requestNo, x.status, x.testReportContactID,x.contactID,x.customerID,x.dateOfSendingResult,x.note,x.numberSample,x.orderConfim,x.priceID,x.printVAT,x.receivceDate));
            CreateMap<E08T_Testing_DataViewModel, E08T_Testing_Data>().ConstructUsing(x => new E08T_Testing_Data(x.iD, x.LOD, x.matrixID, x.max, x.min, x.precision, x.specID));
            CreateMap<E08T_Testing_InfoViewModel, E08T_Testing_Info>().ConstructUsing(x => new E08T_Testing_Info(x.analysisCode, x.specID, x.specification, x.specCode,x.method, x.unit, x.turnAroundTime, x.reformTestResult,x.note));
            CreateMap<E00T_CustomerViewModel, E00T_Customer>().ConstructUsing(x => new E00T_Customer(x.city, x.companyAddress, x.companyName, x.contactEmail, x.contactName, x.customerCode, x.note));
            CreateMap<E00T_Customer_ItemViewModel, E00T_Customer_Item>().ConstructUsing(x => new E00T_Customer_Item(x.contactID, x.address, x.contactName, x.customerCode, x.email, x.note));
            CreateMap<E00T_SampleMatrixViewModel, E00T_SampleMatrix>().ConstructUsing(x => new E00T_SampleMatrix(x.matrixID, x.sampleMatrix));
            CreateMap<E00T_SpecificationViewModel, E00T_Specification>().ConstructUsing(x => new E00T_Specification(x.specID,x.specification,x.specCode));
            CreateMap<AssignmentViewModel, Assignment>().ConstructUsing(x => new Assignment(x.UserId,x.specID));
            CreateMap<E08T_AnalysisRequest_ItemViewModel, E08T_AnalysisRequest_Item>().ConstructUsing(x => new E08T_AnalysisRequest_Item(x.detected, x.LVNCode,x.remarkToLab,x.requestNo,x.sampleCode,x.sampleDescription,x.sampleName,x.weight));
            CreateMap<E00T_CustomerGridViewModel, E08T_AnalysisRequest_Data>().ConstructUsing(x => new E08T_AnalysisRequest_Data(x.analysisCode, x.LOD,x.Mark,x.method,x.Price,x.specification,x.unit,x.Urgent,x.min,x.max,x.sampleMatrix));
            CreateMap<AssignmentViewModel, Assignment>().ConstructUsing(x => new Assignment(x.Id,x.specID,x.UserId));
            CreateMap<ApplicationUserViewModel, AppUser>()
                        .ConstructUsing(c => new AppUser(c.Id, c.FullName, c.UserName,
                        c.Email, c.PhoneNumber, c.Avatar, c.Status, c.Gender, c.BirthDay, c.Address));
            CreateMap<FieldAutoTableViewModel, FieldAutoTable>().ConstructUsing(x => new FieldAutoTable(x.ColumName, x.Denominator, x.ID,x.Value));

        }
    }
}
