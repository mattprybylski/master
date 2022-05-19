using AccountBusiness.Model;
using AutoMapper;
using EF.Data.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Expense, tbl_Expense>()
                    .ForMember(dest => dest.ExpenseType, opt =>   opt.Ignore());

            CreateMap<tbl_Expense, Expense>()
                                .ForMember(dest => dest.ExpenseType, opt => opt.MapFrom(src => src.ExpenseType));

            CreateMap<tbl_ExpenseType, ExpenseType>();
            CreateMap<ExpenseType, tbl_ExpenseType>()
                  .ForMember(dest => dest.tbl_Expense, opt => opt.Ignore());
              

        }
    }
}
