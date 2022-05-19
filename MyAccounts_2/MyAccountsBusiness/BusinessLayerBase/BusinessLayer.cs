using AutoMapper;
using EF.Data.Models.DB;
using MP.EF.Business.AbstractBase;
using MyAccountModels;
using MyAccountModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WPFDataField.DataField;

namespace MyAccountsBusiness.BusinessLayerBase
{
    public abstract class BusinessLayer<T> : IBusinessLayer<T>
    {
        protected IMapper _mapper;
        protected UnitOfWork<MpContext> _unitOfWork;
        public BusinessLayer()
        {
            _unitOfWork = new UnitOfWork<MpContext>(new MpContext());
            CreateMaps(); 
        }
        public abstract Task<List<T>> GetAsync(CancellationToken cancellationToken = default);
        public abstract Task<T> GetByIdAsync(int Id, CancellationToken cancellationToken = default);

        public abstract Task<T> SaveAsync(T item);
        public abstract void Delete(T item);

        protected abstract Task<T> InsertAsync(T item);
        protected abstract Task<T> UpdateAsync(T item);

        private void CreateMaps()
        {
            try
            {
                var config = new MapperConfiguration(cfg => {
                    //cfg.CreateMap<TblExpense, Expense>()
                    //   .ForMember(dest => dest.ExpenseType, opt => opt.MapFrom(src => src.BillPayExpenseType))
                    //   .ForMember(dest => dest.ExpenseDuration, opt => opt.MapFrom(src => (ExpenseDuration)Enum.Parse(typeof(ExpenseDuration), src.Duration)))
                    //   .ForMember(dest => dest.ExpenseTypeId, opt => opt.MapFrom(src => src.BillPayExpenseType != null ? src.BillPayExpenseType.Id : 0));

                    //cfg.CreateMap<Expense, TblExpense>()
                    //.ForMember(dest => dest.BillPayExpenseTypeId, opt => opt.MapFrom(src => src.ExpenseType != null ? src.ExpenseType.Id : 0))
                    //       .ForMember(dest => dest.BillPayExpenseType, opt => opt.Ignore())
                    //   .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.ExpenseDuration.ToString()));

                    //cfg.CreateMap<BilllExpenseType, TblBillPayExpenseType>();
                    //cfg.CreateMap<TblBillPayExpenseType, BilllExpenseType>();

                    cfg.CreateMap<TblStateProvince, StateProvince>();
                    cfg.CreateMap<StateProvince, TblStateProvince>();

                    cfg.CreateMap<TblBillExpense, BillExpense>();




                    cfg.CreateMap<BillExpense, TblBillExpense>();
       

                    cfg.CreateMap<Legder, TblLedger>()
                       .ForMember(dest => dest.BillExpenseId, opt => opt.MapFrom(src => src.BillExpense != null ? src.BillExpense.Id : 0))
                       .ForMember(dest => dest.AccountId, opt => opt.MapFrom(src => src.BillExpense != null ? src.Account.Id : 0))
                       .ForMember(dest => dest.BillExpense, opt => opt.Ignore())
                       .ForMember(dest => dest.Account,     opt => opt.Ignore());


                    cfg.CreateMap<TblLedger, Legder>()
                     .ForMember(dest => dest.BillExpense, opt => opt.MapFrom(src => src.BillExpense))
                    .ForMember(dest => dest.BillExpenseId, opt => opt.MapFrom(src => src.BillExpense != null ? src.BillExpense.Id : 0));


                    cfg.CreateMap<IDataField<decimal>, decimal>();
                    cfg.CreateMap<decimal, IDataField<decimal>>();
                    cfg.CreateMap<decimal, DataField<decimal>>() 
                        .ForMember(x => x.Value, opt => opt.MapFrom(x => x));
 
                    
                    cfg.CreateMap<TblAccount, Account>();
    
                    cfg.CreateMap<Account, TblAccount>();
                });
                _mapper = config.CreateMapper();
            }
            catch(Exception ex)
            {

            }
 
           
        }

 
        //private object GetField<T1>(T1 balance)
        //{
        //    var field = new DataField<T>();
        //}

       // public decimal GetValue()

        private DataField<T> GetField<T>(T value)
        {
            var field = new DataField<T>();
            field.Value = value;
            return field;
        }

    }

     
}
