//using AutoMapper;
//using EF.Data.Models.DB;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using MP.EF.Business.AbstractBase;
//using MP.EF.Business.Interfaces;
//using MyAccountModels;
//using MyAccountModels.AutoMapper;
//using MyAccountModels.Common;
//using MyAccountsBusiness.BusinessLayerBase;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace MyAccountsBusiness.BA
//{
//    public class ExpenseBA : BusinessLayer<Expense>
//    {
    
       
//        private readonly IRepositoryAsync<TblExpense> _repositoryAsync;

//        public ExpenseBA()
//        {
//            _repositoryAsync = _unitOfWork.GetRepositoryAsync<TblExpense>();
//        }

//        public override void Delete(Expense item)
//        {
//            try
//            {
//                var entity = _mapper.Map<TblExpense>(item);
//                _repositoryAsync.Delete(entity);
//                _unitOfWork.Commit();
//            }
//            catch (Exception ex)
//            {
           
//                throw new Exception();
//            }
//        }

//        public async override Task<List<Expense>> GetAsync(CancellationToken cancellationToken = default)
//        {
//            try
//            {
//                var items = await _repositoryAsync.GetList().Include(ex=> ex.BillPayExpenseType).ToListAsync(cancellationToken);
//                return _mapper.Map<List<Expense>>(items);
//            }
//            catch (Exception ex)
//            {
             
//                throw new Exception();
//            }
//        }

//        public async override Task<Expense> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
//        {
//            try
//            {
//                var entity = await
//                    _repositoryAsync.GetFirstOrDefaultAsync(x => x.Id == Id);

//                return _mapper.Map<Expense>(entity);
//            }
//            catch (Exception ex)
//            {
           
//                throw new Exception();
//            }
//        }

//        public async override Task<Expense> SaveAsync(Expense item)
//        {
//            if (item.Id == 0)
//            {
//                return await InsertAsync(item);
//            }
//            else
//            {
//                return await UpdateAsync(item);
//            }
//        }

//        protected async override Task<Expense> InsertAsync(Expense item)
//        {
//            try
//            {
//                var entity = _mapper.Map<TblExpense>(item);
//                entity.CreatedDate = DateTime.UtcNow;
//                await _repositoryAsync.InsertAsync(entity);
//                _unitOfWork.Commit();
//                return _mapper.Map<Expense>(entity);
//            }
//            catch (Exception ex)
//            {
        
//                throw new Exception();
//            }
//        }

//        protected async override Task<Expense> UpdateAsync(Expense item)
//        {
//            var entity = await GetByIdAsync(item.Id);
//            if (entity.Id <= 0)
//            {
//                return null;
//            }
//            try
//            {

//                var updating = _mapper.Map<TblExpense>(item);
//                _repositoryAsync.Update(updating);
//                _unitOfWork.Commit();
//                return _mapper.Map<Expense>(updating);

//            }
//            catch (Exception ex)
//            {
             
//                throw new Exception();
//            }
//        }
 
//    }
//}
