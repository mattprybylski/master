using AutoMapper;
using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MP.EF.Business.AbstractBase;
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
    public class StateProvinceBA : BusinessLayer<StateProvince>
    {
 
        private IRepository<TblStateProvince> _repository;
     
        private IRepositoryAsync<TblStateProvince> _repositoryAsync;
        private readonly ILogger<StateProvinceBA> _logger;
        public StateProvinceBA(ILogger<StateProvinceBA> logger)
        {
            _repositoryAsync = _unitOfWork.GetRepositoryAsync<TblStateProvince>();
            _logger = logger; 
        }
        public override void Delete(StateProvince item)
        {
            try
            {
                var entity = _mapper.Map<TblStateProvince>(item);
                _repositoryAsync.Delete(entity);
                _unitOfWork.Commit(); 
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<StateProvince>> GetBySearch(string search, CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _repositoryAsync.GetList(x => x.Abbreviation.Contains(search.ToLower().Trim())).ToListAsync(cancellationToken);
                return _mapper.Map<List<StateProvince>>(items);
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public override async Task<List<StateProvince>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _repositoryAsync.GetList().ToListAsync();
                return _mapper.Map<List<StateProvince>>(items);
            }
            catch(Exception ex)
            {
                throw ex; 
            }
      
        }

        public override async Task<StateProvince> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
        {
            try
            {
                var entity = await 
                    _repositoryAsync.GetFirstOrDefaultAsync(x => x.Id == Id); 

                return _mapper.Map<StateProvince>(entity);
            }
            catch(Exception ex)
            {
                throw ex; 
            }
        }

        public override async Task<StateProvince> SaveAsync(StateProvince item)
        {
            if(item.Id == 0)
            {
                return await  InsertAsync(item); 
            }
            else
            {
                return await UpdateAsync(item); 
            }
        }

        protected override async Task<StateProvince> InsertAsync(StateProvince item)
        {
            try
            {
                var entity = _mapper.Map<TblStateProvince>(item);
                entity.CreatedDate = DateTime.UtcNow;
                await _repositoryAsync.InsertAsync(entity);
                _unitOfWork.Commit();
                return _mapper.Map<StateProvince>(entity); 
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
              
        }

 
        protected async override Task<StateProvince> UpdateAsync(StateProvince item)
        {
            var entity = await GetByIdAsync(item.Id);
            if (entity.Id <= 0)
            {
                return null;
            }
            try
            {

                var updating = _mapper.Map<TblStateProvince>(item);
                _repositoryAsync.Update(updating);
                _unitOfWork.Commit();
                return _mapper.Map<StateProvince>(updating);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception();
            }
        }
 
    }
}
