using AccountBusiness.Interface;
using AccountBusiness.Model;
using AutoMapper;
using EF.Business.Base;
using EF.Business.Interface;
using EF.Data.Models.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBusiness.BA
{
    public class ExpenseBA : BAAbstractBase, IExpenseBA
    {
        protected readonly UnitOfWork<MpContext> _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly IRepositoryAsync<tbl_Expense> _expenseRepository;
        protected readonly IExpenseTypeBA _expenseTypeBA;


        public ExpenseBA(
              IMapper mapper,
              IExpenseTypeBA expenseTypeBA,
              UnitOfWork<MpContext> unitOfWork)
        {
            _unitOfWork         = unitOfWork;
            _mapper             = mapper;
            _expenseRepository  = _unitOfWork.GetRepositoryAsync<tbl_Expense>();
            _expenseTypeBA      = expenseTypeBA; 
        }

        public async Task<List<Expense>> GetAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                var items = await _expenseRepository.GetList(include:x=> x.Include(x=> x.ExpenseType), enableTracking:false).ToListAsync(cancellationToken);
                return _mapper.Map<List<Expense>>(items);
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

        public async Task<Expense> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var item = await _expenseRepository.GetFirstOrDefaultAsync(x => x.Id == id, enableTracking: false);
                return _mapper.Map<Expense>(item);
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

        public async   Task<Tuple<Expense, string>> InsertAsync(Expense expense, CancellationToken cancellationToken = default)
        {
            try
            {
                (bool isValid, string errorMessage) = await ValidateExpenseType(expense, cancellationToken);
                if (!isValid)
                    return new Tuple<Expense, string>(new Expense(), errorMessage);

                var entity = _mapper.Map<tbl_Expense>(expense);
                entity.CreatedDate = DateTime.UtcNow; 
                await _expenseRepository.InsertAsync(entity);
                _unitOfWork.Commit(entity);
         
                return new Tuple<Expense, string>(await GetByIdAsync(entity.Id, cancellationToken) ?? new Expense(), string.Empty);

            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {

                return new Tuple<Expense, string>(expense, "Error: " + ex.Message);
            }
        }

        public async Task<Tuple<Expense, string>> UpdateAsync(Expense expense, CancellationToken cancellationToken = default)
        {
            try
            {
                (bool isValid, string errorMessage) = await ValidateExpenseType(expense, cancellationToken);
                var currentExpense = await GetByIdAsync(expense.Id, cancellationToken);
                if (currentExpense.Id == 0)
                    return new Tuple<Expense, string>(new Expense(), "Error: Expense: " + expense.Name + " does not exists.");
                if (!isValid)
                    return new Tuple<Expense, string>(new Expense(), errorMessage);

                var entity = _mapper.Map<tbl_Expense>(expense);
                _expenseRepository.Update(entity);
                _unitOfWork.Commit(entity);
                return new Tuple<Expense, string>(_mapper.Map<Expense>(entity) ?? new Expense(), string.Empty);

            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
                return new Tuple<Expense, string>(expense, "Error: " + ex.Message);
            }
        }

        public async Task<Tuple<Expense, string>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            try
            {
                var currentExpenseType = await GetByIdAsync(id, cancellationToken);
                if (currentExpenseType.Id == 0)
                    return new Tuple<Expense, string>(new Expense(), "Expense type: does not exists.");
                var entity = _mapper.Map<tbl_Expense>(currentExpenseType);
                _expenseRepository.Delete(entity);
                _unitOfWork.Commit(entity);
                return new Tuple<Expense, string>(new Expense(), string.Empty);

            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
                return new Tuple<Expense, string>(new Expense(), ex.Message);

            }
        }

        private async Task<Tuple<bool, string>> ValidateExpenseType(Expense expense, CancellationToken cancellationToken)
        {
            try
            {



                var expenseType = _expenseTypeBA.GetByIdAsync(expense.Id, cancellationToken);
                if (expenseType.Id == 0)
                    return new Tuple<bool, string>(false, "Error: Invalid Expense Type");

                var expenses = await _expenseRepository.GetList().ToListAsync(cancellationToken);
                if (string.IsNullOrEmpty(expense.Name))
                    return new Tuple<bool, string>(false, "Error: ExpenseType Name is Required");

                if (expenses.Select(x => x.Name).Contains(expense.Name))
                    return new Tuple<bool, string>(false, "Error: ExpenseType " + expense.Name + " already exists");

                return new Tuple<bool, string>(true, string.Empty);
            }
            catch (OperationCanceledException)
            {
                // no need to log it; the request was simply cancelled
                throw;
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(true, ex.Message);
            }
        }
    }
}
