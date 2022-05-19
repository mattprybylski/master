using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using MP.EF.Business.Interfaces;
using MyAccountModels;
using MyAccountsBusiness.BusinessLayerBase;
using MyAccountsBusiness.DataEncryption;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAccountsBusiness.BA
{
    public class AccountBA : BusinessLayer<Account>
    {
        private readonly IRepositoryAsync<TblAccount> _repositoryAsync;
        private readonly DataProtectionEncryption dataProtectionEncryption; 
        public AccountBA()
        {
            _repositoryAsync = _unitOfWork.GetRepositoryAsync<TblAccount>();
            dataProtectionEncryption = new DataProtectionEncryption(); 
        }

        public override void Delete(Account item)
        {
            var entity = _mapper.Map<TblAccount>(item);
            _repositoryAsync.Delete(entity);
            _unitOfWork.Commit();
        }

        public  async override Task<List<Account>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {

                var entities = await _repositoryAsync.GetList().ToListAsync(cancellationToken);
               var items =  _mapper.Map<List<Account>>(entities);
                items.ForEach(x => x.RoutingNumber = dataProtectionEncryption.DecryptStringAES(x.RoutingNumber));
                items.ForEach(x => x.AccountNumber = dataProtectionEncryption.DecryptStringAES(x.AccountNumber));
           
                return items;
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public async override Task<Account> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await
                    _repositoryAsync.GetFirstOrDefaultAsync(x => x.Id == Id);

                return _mapper.Map<Account>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        public async override Task<Account> SaveAsync(Account item)
        {
            item.AccountNumber =
               dataProtectionEncryption.Encrypt(item.AccountNumber);
            item.RoutingNumber =
          dataProtectionEncryption.Encrypt(item.RoutingNumber);

            if (item.Id == 0)
            {
                return await InsertAsync(item);
            }
            else
            {
                return await UpdateAsync(item);
            }

        }

        protected async override Task<Account> InsertAsync(Account item)
        {
            try
            {
                var entity = _mapper.Map<TblAccount>(item);
                entity.CreatedDate = DateTime.UtcNow;
                await _repositoryAsync.InsertAsync(entity);
                _unitOfWork.Commit();
                return _mapper.Map<Account>(entity);
            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }

        protected async override Task<Account> UpdateAsync(Account item)
        {
            var entity = await GetByIdAsync(item.Id);
            if (entity.Id <= 0)
            {
                return null;
            }
            try
            {

                var updating = _mapper.Map<TblAccount>(item);
                _repositoryAsync.Update(updating);
                _unitOfWork.Commit();
                return _mapper.Map<Account>(updating);

            }
            catch (Exception ex)
            {

                throw new Exception();
            }
        }
    }
}
