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
    /// Логика взаимодействия для DobAgent.xaml
    /// </summary>
    public partial class DobAgent : Page
    {
        Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
        Frame frame1;
        Image img = new Image();
        public DobAgent(Frame frame)
        {
            InitializeComponent();
            frame1 = frame;
            var allTypes = GazetaSmoEntities.GetContext().ProductType.ToList();
            ProductTypes.ItemsSource = allTypes;
            var uriImageSource = new Uri(@"/Image/picture.png", UriKind.RelativeOrAbsolute);
            Sources.Source = new BitmapImage(uriImageSource);
            img.Source = Sources.Source;
        }

       

        private void Bck_Click(object sender, RoutedEventArgs e)
        {
            frame1.Navigate(new Glavn(frame1));
        }

        private void Dob_Click(object sender, RoutedEventArgs e)
        {
            List<Product> products = new List<Product> { new Product() };
            int count = GazetaSmoEntities.GetContext().Product.Count();
            try
            {


                products[0].ID = count + 1;
                products[0].Title = txtTittle.Text;
                products[0].ProductTypeID = ProductTypes.SelectedIndex + 1;
                products[0].ArticleNumber = txtArticle.Text;

                var uriImageSource1 = new Uri(@"/Image/picture.png", UriKind.RelativeOrAbsolute);
                if (Sources.Source != img.Source)
                {

                    var uriImageSource = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
                    Sources.Source = new BitmapImage(uriImageSource);
                    products[0].Image = uriImageSource.ToString();
                }
                else
                {
                    products[0].Image = uriImageSource1.ToString();
                }
                GazetaSmoEntities.GetContext().Product.Add(products[0]);
                GazetaSmoEntities.GetContext().SaveChanges();
                frame1.Navigate(new Glavn(frame1));
            }
            catch (Exception error)
            {
                MessageBox.Show("Неверный формат полей");
            }
        }

        private void Sources_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            dlg.FileName = "Picture";
            dlg.DefaultExt = ".png";
            dlg.Filter = "Picture (.png)|*.png";

            Nullable<bool> result = dlg.ShowDialog();
            if (result != false)
            {
                var uriImageSource = new Uri(dlg.FileName, UriKind.RelativeOrAbsolute);
                Sources.Source = new BitmapImage(uriImageSource);
            }
        }

        private void ProductTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
