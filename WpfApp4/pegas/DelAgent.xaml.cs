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
    /// Логика взаимодействия для DelAgent.xaml
    /// </summary>
    public partial class DelAgent : Page
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        Image img = new Image();
        Frame frame1;
        public DelAgent(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string titleToDelete = txtTittle.Text; // Получите заголовок продукта для удаления из соответствующего текстового поля

                Product product = GazetaSmoEntities.GetContext().Product.FirstOrDefault(p => p.Title == titleToDelete);
                if (product != null)
                {
                    GazetaSmoEntities.GetContext().Product.Remove(product);
                    GazetaSmoEntities.GetContext().SaveChanges();
                    frame1.Navigate(new Glavn(frame1));
                    // Опционально: выполнить дополнительные действия после удаления объекта
                }
                else
                {
                    MessageBox.Show("Продукт с указанным заголовком не найден.");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Ошибка при удалении объекта: " + error.Message);
            }

        }

        private void Bck1_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Glavn(frame1));
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Sources_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void ProductTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
