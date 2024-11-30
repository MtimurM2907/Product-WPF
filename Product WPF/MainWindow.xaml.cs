using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Product_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Product> _products;
        public MainWindow()
        {
            InitializeComponent();
            _products = new ObservableCollection<Product>();
            ListBoxProduct.ItemsSource = _products;
        }

        private void AddProduct_Click(object sender, RoutedEventArgs e)
        {
            string name = AddName.Text;
            if (double.TryParse(AddPrice.Text, out double price) && int.TryParse(AddQuantity.Text, out int quantity))
            {
                Product product = new Product(name, price, quantity);
                _products.Add(product);
            }
            else
            {
                MessageBox.Show("Неверный ввод");
            }
        }

        private void AboutProduct_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxProduct.SelectedItem is Product selectedProduct)
            {
                var (name, price, quantity) = selectedProduct;
                MessageBox.Show($"\nName: {name}\nPrice: {price:C}\nQuantity: {quantity}");
            }
            else
            {
                MessageBox.Show("Выберите сначало товар");
            }
        }
    }
}
