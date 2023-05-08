﻿using NganHangDe.Commands;
using NganHangDe.Models;
using NganHangDe.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NganHangDe.ViewModels
{
    public class CategoryListViewModel : ViewModelBase
    {
        private ObservableCollection<CategoryViewModel> _categories;
        private readonly ICategoryService _categoryService;
        private CategoryViewModel _selectedCategory;
        public ICommand CategorySelectedCommand { get; }

        public CategoryViewModel SelectedCategory
        {
            get => _selectedCategory;
            set
            {
                _selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));
            }
        }
        public ObservableCollection<CategoryViewModel> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public CategoryListViewModel(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            LoadCategories();
            CategorySelectedCommand = new CategorySelectedCommand(CategorySelected);
        }

        private async void LoadCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            Categories = new ObservableCollection<CategoryViewModel>(categories);
        }
        private void CategorySelected()
        {
            //TODO: 
        }
    }

}
