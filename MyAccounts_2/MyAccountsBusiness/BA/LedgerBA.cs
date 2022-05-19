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
    public class LedgerBA : BusinessLayer<Legder>
    {
        private readonly IRepositoryAsync<TblLedger> _repositoryAsync;
        private readonly AccountBA _accountBA;
        private readonly BillExpenseBA _billExpenseBA;
        public LedgerBA()
        {
            _repositoryAsync = _unitOfWork.GetRepositoryAsync<TblLedger>();
            _accountBA = new AccountBA();
            _billExpenseBA = new BillExpenseBA(); 
        }

        public override void Delete(Legder item)
        {
            var entity = _mapper.Map<TblLedger>(item);
            _repositoryAsync.Delete(entity);
            _unitOfWork.Commit();
        }

        public async override Task<List<Legder>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {

                var items = await _repositoryAsync.GetList().Include(x=> x.BillExpense).ToListAsync(cancellationToken);

                return _mapper.Map<List<Legder>>(items);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public async Task<List<Legder>> GetByAccountId(int accountId, CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _repositoryAsync.GetList(x => x.AccountId == accountId).ToListAsync(cancellationToken);
                return _mapper.Map<List<Legder>>(items);
            }
            catch(Exception ex)
            {
                throw new Exception();
            }
        }

        public async override Task<Legder> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await
                    _repositoryAsync.GetFirstOrDefaultAsync(x => x.Id == Id);

                return _mapper.Map<Legder>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public async Task<Legder>SaveAsync(Legder ledger, BillExpense billExpense)
        {
            if (billExpense.HasBalance)
            {
                billExpense.Balance -= ledger.Payment;
                await _billExpenseBA.SaveAsync(billExpense); 
            }
            return await SaveAsync(ledger); 
        }
        public async override Task<Legder> SaveAsync(Legder item)
        {
            var account = await _accountBA.GetByIdAsync(item.AccountId); 
            
            if(account.Id != 0)
            {
                if(item.TransactionType.ToLower().Trim() == "credit")
                {
                    item.Account.Balance = account.Balance + item.Payment;
                    account.Balance = account.Balance + item.Payment;
                }
                if (item.TransactionType.ToLower().Trim() == "debit")
                {
                    item.Account.Balance = account.Balance - item.Payment;
                    account.Balance = account.Balance - item.Payment;
                }

                item.Balance = account.Balance; 
               await  _accountBA.SaveAsync(item.Account); 
            }
            //var items = await   GetAsync();

            //var balance = items.TakeLast(items.Count).FirstOrDefault(); 
            //if(balance != null)
            //{
            //    if (item.TransactionType.ToLower().Trim().Equals("credit"))
            //    {
            //        item.Balance = item.Payment + balance.Balance;
            //    }
            //    if (item.TransactionType.ToLower().Trim().Equals("debit"))
            //    {
            //        item.Balance =  balance.Balance - item.Payment;
            //    }
            //}
 
            if (item.Id == 0)
            {
                return await InsertAsync(item);
            }
            else
            {
                return await UpdateAsync(item);
            }
        }

        protected async override Task<Legder> InsertAsync(Legder item)
        {
            try
            {
                var entity = _mapper.Map<TblLedger>(item);
                entity.CreatedDate = DateTime.UtcNow;
                await _repositoryAsync.InsertAsync(entity);
                _unitOfWork.Commit();
                return _mapper.Map<Legder>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        protected async override Task<Legder> UpdateAsync(Legder item)
        {
            var entity = await GetByIdAsync(item.Id);
            if (entity.Id <= 0)
            {
                return null;
            }
            try
            {

                var updating = _mapper.Map<TblLedger>(item);
                _repositoryAsync.Update(updating);
                _unitOfWork.Commit();
                return _mapper.Map<Legder>(updating);

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}
