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
using test.classes;

namespace test.pages
{
    /// <summary>
    /// Логика взаимодействия для admin.xaml
    /// </summary>
    public partial class admin : Page
    {
        private products _currentProducts = new products();
        public admin(products selectedProducts)
        {
            InitializeComponent();

            if(selectedProducts != null)
                _currentProducts = selectedProducts;

            DataContext = _currentProducts;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(_currentProducts.name))
                errors.AppendLine("Укажите название");
            if (string.IsNullOrWhiteSpace(_currentProducts.descriprion))
                errors.AppendLine("Укажите описание");
            if (string.IsNullOrWhiteSpace(_currentProducts.prise))
                errors.AppendLine("Укажите цену");
            if (string.IsNullOrWhiteSpace(_currentProducts.count))
                errors.AppendLine("Укажите колличество");

            if(errors.Length > 0)
            {
                MessageBox.Show(errors.ToString());
                return;
            }

            if(_currentProducts.id == 0) 
                Test2Entities.GetContext().products.Add(_currentProducts);

            try
            {
                Test2Entities.GetContext().SaveChanges();
                MessageBox.Show("Информация сохранена");
                FrameApp.frameObject.GoBack();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString()); 
            }
        }
    }
}
