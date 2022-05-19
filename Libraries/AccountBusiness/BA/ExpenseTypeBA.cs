using AccountBusiness.Interface;
using AccountBusiness.Model;
using AutoMapper;
using EF.Business.Base;
using EF.Business.Interface;
using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.BA
{
    public class ExpenseTypeBA : BAAbstractBase, IExpenseTypeBA
    {
        protected readonly UnitOfWork<MpContext> _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepositoryAsync<tbl_ExpenseType> _expenseTypeRepository;
 
        public ExpenseTypeBA(
              IMapper mapper,
              UnitOfWork<MpContext> unitOfWork)
        {
            _unitOfWork = unitOfWork; 
            _mapper = mapper;
            _expenseTypeRepository = _unitOfWork.GetRepositoryAsync<tbl_ExpenseType>();
        }

        public async Task<Tuple<ExpenseType, string>> DeleteAsync(ExpenseType item, CancellationToken cancellationToken = default)
        {
            try
            {
                var currentExpenseType = await GetByIdAsync(item.Id, cancellationToken);
                if (currentExpenseType.Id == 0)
                    return new Tuple<ExpenseType, string>(new ExpenseType(), "Expense type: does not exists.");
                var entity = _mapper.Map<tbl_ExpenseType>(item);
                _expenseTypeRepository.Delete(entity);
                _unitOfWork.Commit(entity);
                return new Tuple<ExpenseType, string>(new ExpenseType(), string.Empty); 

            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
                return new Tuple<ExpenseType, string>(new ExpenseType(), ex.Message);
              
            }

        }

        public async Task<ObservableCollection<ExpenseType>>GetObservableCollection(CancellationToken cancellation = default)
        {
            var items = await GetAsync(cancellation);
            ObservableCollection<ExpenseType> expenseTypes = new ObservableCollection<ExpenseType>();
            items.ForEach(x => expenseTypes.Add(x));
            return expenseTypes; 
        }


        public async Task<List<ExpenseType>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _expenseTypeRepository.GetList(enableTracking:false).ToListAsync(cancellationToken);
                return _mapper.Map<List<ExpenseType>>(items);
            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
                
                throw new Exception();
            }
        }

        public async Task<ExpenseType> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var item = await _expenseTypeRepository.GetFirstOrDefaultAsync(x => x.Id == id, enableTracking: false) ; 
                return _mapper.Map<ExpenseType>(item);
            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;

            }
            catch (Exception ex)
            {
                
                throw new Exception();
            }
        }

        public async Task<Tuple<ExpenseType, string>> InsertAsync(ExpenseType expenseType, CancellationToken cancellationToken = default)
        {
            try
            {
                (bool isValid, string errorMessage) = await ValidateExpenseType(expenseType, cancellationToken);
                if (!isValid)
                    return new Tuple<ExpenseType, string>(new ExpenseType(), errorMessage);

                var entity = _mapper.Map<tbl_ExpenseType>(expenseType);
                await _expenseTypeRepository.InsertAsync(entity);
                _unitOfWork.Commit(entity); 
              //  _expenseTypeRepository.Detach(entity); 
                return new Tuple<ExpenseType, string>(await GetByIdAsync(entity.Id, cancellationToken) ?? new ExpenseType(), string.Empty); 

            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
          
                return new Tuple<ExpenseType, string>(new ExpenseType(), "Error: " + ex.Message);
            }
        }

        public async Task<Tuple<ExpenseType, string>> UpdateAsync(ExpenseType expenseType, CancellationToken cancellationToken = default)
        {
            try
            {
                (bool isValid, string errorMessage) = await ValidateExpenseType(expenseType, cancellationToken);
                var currentExpenseType = await GetByIdAsync(expenseType.Id, cancellationToken);
                if (currentExpenseType.Id == 0)
                    return new Tuple<ExpenseType, string>(new ExpenseType(), "Error: Expense type: " + expenseType.Name + " does not exists.");
                if (!isValid)
                    return new Tuple<ExpenseType, string>(new ExpenseType(), errorMessage);

                var entity = _mapper.Map<tbl_ExpenseType>(expenseType);
                 _expenseTypeRepository.Update(entity);
                _unitOfWork.Commit(entity);
                return new Tuple<ExpenseType, string>(_mapper.Map<ExpenseType>(entity) ?? new ExpenseType(), string.Empty);

            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
                return new Tuple<ExpenseType, string>(new ExpenseType(), "Error: " +  ex.Message);
            }
        }

        private async Task<Tuple<bool, string>> ValidateExpenseType(ExpenseType expenseType, CancellationToken cancellationToken)
        {
            var expenseTypes = await _expenseTypeRepository.GetList().ToListAsync(cancellationToken);
            if (string.IsNullOrEmpty(expenseType.Name))
                return new Tuple<bool, string>(false, "Error: ExpenseType Name is Required");

            if (expenseTypes.Select(x => x.Name).Contains(expenseType.Name))
                return new Tuple<bool, string>(false, "Error: ExpenseType " + expenseType.Name + " already exists");

            return new Tuple<bool, string>(true, string.Empty); 
        }
    }
}
