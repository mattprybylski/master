//using AutoMapper;
//using EF.Data.Models.DB;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging;
//using MP.EF.Business.AbstractBase;
//using MP.EF.Business.Interfaces;
//using MyAccountModels;
//using MyAccountsBusiness.BusinessLayerBase;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading;
//using System.Threading.Tasks;

//namespace MyAccountsBusiness.BA
//{
//    public class BillExpenseTypeBA : BusinessLayer<BilllExpenseType>
//    {
    
//        private IRepository<TblBillPayExpenseType> _repository;
//        private IRepositoryAsync<TblBillPayExpenseType> _repositoryAsync;
//        private readonly ILogger<BillExpenseTypeBA> _logger;
//        public BillExpenseTypeBA( )
//        {
    
//            _repositoryAsync = _unitOfWork.GetRepositoryAsync<TblBillPayExpenseType>();
            
//        }

//        public override void Delete(BilllExpenseType item)
//        {
//            try
//            {
//                var entity = _mapper.Map<TblBillPayExpenseType>(item);
//                _repositoryAsync.Delete(entity);
//                _unitOfWork.Commit();
//            }
//            catch (Exception ex)
//            {
              
//                throw new Exception();
//            }
//        }

//        public async override Task<List<BilllExpenseType>> GetAsync(CancellationToken cancellationToken = default)
//        {
//            try
//            {
//                var items = await _repositoryAsync.GetList().ToListAsync(cancellationToken);
//                return _mapper.Map<List<BilllExpenseType>>(items);
//            }
//            catch (Exception ex)
//            {
            
//                throw new Exception();
//            }
//        }

//        public async override Task<BilllExpenseType> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
//        {
//            try
//            {
//                var entity = await
//                    _repositoryAsync.GetFirstOrDefaultAsync(x => x.Id == Id);

//                return _mapper.Map<BilllExpenseType>(entity);
//            }
//            catch (Exception ex)
//            {
            
//                throw new Exception();
//            }
//        }

//        public async override Task<BilllExpenseType> SaveAsync(BilllExpenseType item)
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

//        protected async override Task<BilllExpenseType> InsertAsync(BilllExpenseType item)
//        {
//            try
//            {
//                var entity = _mapper.Map<TblBillPayExpenseType>(item);
//                entity.CreatedDate = DateTime.UtcNow;
//                await _repositoryAsync.InsertAsync(entity);
//                _unitOfWork.Commit();
//                return _mapper.Map<BilllExpenseType>(entity);
//            }
//            catch (Exception ex)
//            {
        
//                throw new Exception();
//            }
//        }

//        protected async override Task<BilllExpenseType> UpdateAsync(BilllExpenseType item)
//        {
//            var entity = await GetByIdAsync(item.Id);
//            if (entity.Id <= 0)
//            {
//                return null;
//            }
//            try
//            {
               
//                    var updating = _mapper.Map<TblBillPayExpenseType>(item);
//                    _repositoryAsync.Update(updating);
//                    _unitOfWork.Commit();
//                    return _mapper.Map<BilllExpenseType>(updating);
                 
//            }
//            catch (Exception ex)
//            {
//                _logger.LogError(ex.Message);
//                throw new Exception();
//            }
//        }

        
//    }
//}
