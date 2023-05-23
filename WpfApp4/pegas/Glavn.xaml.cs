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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp4.pegas
{
    /// <summary>
    /// Логика взаимодействия для Glavn.xaml
    /// </summary>
    public partial class Glavn : Page
    {
        public Frame frame1;
        public Glavn(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            var allTypes = GazetaSmoEntities.GetContext().ProductType.ToList();
            allTypes.Insert(0, new ProductType
            {
                Title = "Все типы"
            });
            ComboType.ItemsSource = allTypes;
            ComboType.SelectedIndex = 0;
            frame1 = frame;
            var current = GazetaSmoEntities.GetContext().Product.ToList();
            LViewTours.ItemsSource = current;
        }
        private void UpdateAgent()
        {
            var currentProduct = GazetaSmoEntities.GetContext().Product.ToList();
            if (ComboType.SelectedIndex > 0)
            {
                for (int i = 0; i < currentProduct.Count; i++)
                {
                    if (currentProduct[i].ProductType.Title != ComboType.Text)
                    {
                        currentProduct.RemoveAt(i);
                        i--;
                    }
                }
            }
            currentProduct = currentProduct.Where(p => p.Title.ToLower().Contains(TBoxSearch.Text.ToLower())).ToList();
            LViewTours.ItemsSource = currentProduct.ToList();
        }

        private void TBoxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void ComboType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateAgent();
        }

        private void AddMaska_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new DobAgent(frame1));
        }

        private void Back_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LViewTours_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Dell_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame1.Navigate(new DelAgent(frame1));
        }
    }
}
