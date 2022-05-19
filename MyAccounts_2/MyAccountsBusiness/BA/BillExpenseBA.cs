using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using MP.EF.Business.Interfaces;
using MyAccountModels;
using MyAccountsBusiness.BusinessLayerBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAccountsBusiness.BA
{
    public class BillExpenseBA : BusinessLayer<BillExpense>
    {
        private readonly IRepositoryAsync<TblBillExpense> _repositoryAsync;

        public BillExpenseBA()
        {
            _repositoryAsync = _unitOfWork.GetRepositoryAsync<TblBillExpense>();
        }

        public override void Delete(BillExpense item)
        {
            var entity = _mapper.Map<TblBillExpense>(item);
            _repositoryAsync.Delete(entity);
            _unitOfWork.Commit();
        }

        public async override Task<List<BillExpense>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _repositoryAsync.GetList().OrderBy(x=> x.HasBalance) .ToListAsync(cancellationToken);
                return _mapper.Map<List<BillExpense>>(items);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public async override Task<BillExpense> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await
                    _repositoryAsync.GetFirstOrDefaultAsync(x => x.Id == Id);

                return _mapper.Map<BillExpense>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public async override Task<BillExpense> SaveAsync(BillExpense item)
        {
            if (item.Id == 0)
            {
                return await InsertAsync(item);
            }
            else
            {
                return await UpdateAsync(item);
            }
        }

        protected async override Task<BillExpense> InsertAsync(BillExpense item)
        {
            try
            {
                var entity          = _mapper.Map<TblBillExpense>(item);
                entity.CreatedDate  = DateTime.UtcNow;
                await _repositoryAsync.InsertAsync(entity);
                _unitOfWork.Commit();
                return _mapper.Map<BillExpense>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        protected async override Task<BillExpense> UpdateAsync(BillExpense item)
        {
            var entity = await GetByIdAsync(item.Id);
            if (entity.Id <= 0)
            {
                return null;
            }
            try
            {

                var updating = _mapper.Map<TblBillExpense>(item);
                _repositoryAsync.Update(updating);
                _unitOfWork.Commit();
                return _mapper.Map<BillExpense>(updating);

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}
