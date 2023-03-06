using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using v0._1.ViewModels;

namespace v0._1.Views
{
    /// <summary>
    /// Логика взаимодействия для BaseWindow.xaml
    /// </summary>
    public partial class BaseWindow : Window
    {
        private BaseWindowViewModel _viewModel;
        public BaseWindowViewModel ViewModel 
        { 
            get
            {
                if (_viewModel==null) 
                    _viewModel=(BaseWindowViewModel)DataContext;
                return _viewModel; 
            } 
            set { _viewModel=value; } 
        }
        public BaseWindow()
        {
            InitializeComponent();
        }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.MainAction();
        }

        private void SortBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.MainAction();
        }

        private void FilterBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ViewModel.MainAction();
        }
    }
}
