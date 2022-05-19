using AutoMapper;
using EF.Data.Models.DB;
using MyAccountModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAccountModels.AutoMapper
{
    public class MappingProfile2<T> : Profile
    {
 
    }


    public class MappingProfile : Profile
    {
        public void test()
        {
            
        }
        public MappingProfile()
        {
             CreateMap<TblStateProvince, StateProvince>();
            CreateMap<StateProvince, TblStateProvince>();
       

            //CreateMap<TblExpense, Expense>()
            //       .ForMember(dest => dest.ExpenseType, opt => opt.MapFrom(src => src.BillPayExpenseType))
            //       .ForMember(dest => dest.ExpenseDuration, opt => opt.MapFrom(src => (ExpenseDuration)Enum.Parse(typeof(ExpenseDuration), src.Duration)));

            //CreateMap<Expense, TblExpense>()
            //    .ForMember(dest => dest.BillPayExpenseTypeId, opt => opt.MapFrom(src => src.ExpenseType != null ? src.ExpenseType.Id : 0))
            //           .ForMember(dest => dest.BillPayExpenseType, opt => opt.Ignore())
            //       .ForMember(dest => dest.Duration, opt => opt.MapFrom(src =>  src.ExpenseDuration.ToString()));
            
        }
 
    }
}
