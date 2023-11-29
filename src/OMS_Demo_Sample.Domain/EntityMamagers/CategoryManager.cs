using OMS_Demo_Sample.Entities;
using OMS_Demo_Sample.EntityMamagers.Interfaces;
using System.Threading.Tasks;
using System.Threading;
using Volo.Abp.Domain.Services;
using Volo.Abp.Domain.Repositories;
using System;
using System.Text.RegularExpressions;

namespace OMS_Demo_Sample.EntityMamagers
{
    #region Business rules definition
    // 1. Создаваемый экземпляр Category не должен содержать CategoryName, который уже существует в бд
    // 2. Создаваемый экземпляр Category не должен содержать CategoryName, который содержит в себе кириллицу
    // 3. Экземпляр Category можно создать только с понедельника по пятницу с 9 часов утра до 18 часов вечера
    // 4. Удалять Category запрещено в пятницу
    #endregion
    public class CategoryManager : DomainService, ICategoryRepository
    {
        private readonly IRepository<Category, int> _categoryRepository;

        public CategoryManager(IRepository<Category, int> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        //public CategoryManager(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}

        public async Task<Category> CreateCategory(Category category, CancellationToken token)
        {
            await IsDuplicateCategoryName(category.CategoryName, token);
            IsCyrillicCategoryName(category.CategoryName);
            IsValidCreationTime();
            return category;
        }

        public async Task<Category> DeleteAsync(Category category, CancellationToken token)
        {
            IsFriday();
            return category;
        }

        #region Business rules implementations
        /// <summary>
        /// Business rule №1
        /// </summary>
        private async Task IsDuplicateCategoryName(string categoryName, CancellationToken token)
        {
            if(await _categoryRepository.AnyAsync(c => c.CategoryName == categoryName, token))
                throw new ArgumentException($"{categoryName} already exists!");
        }

        /// <summary>
        /// Business rule №2
        /// </summary>
        private void IsCyrillicCategoryName(string categoryName)
        {
            if (Regex.IsMatch(categoryName, @"^\p{IsCyrillic}"))
                throw new Exception($"{categoryName} CategoryName should not start with Cyrillic characters.");
        }

        /// <summary>
        /// Business rule №3
        /// </summary>
        /// <returns></returns>
        private void IsValidCreationTime()
        {
            DateTime now = DateTime.Now;

            bool isWeekend = now.DayOfWeek == DayOfWeek.Saturday || now.DayOfWeek == DayOfWeek.Sunday;
            bool isOutsideAllowedTimeRange = now.TimeOfDay < TimeSpan.FromHours(9) || now.TimeOfDay > TimeSpan.FromHours(18);

            if (isWeekend || isOutsideAllowedTimeRange)
                throw new Exception($"Category cannot be created now.");
        }

        /// <summary>
        /// Business rule №4
        /// </summary>
        private void IsFriday()
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Friday)
                throw new Exception($"It is forbidden to delete Category on Friday.");
        }
        #endregion
    }
}