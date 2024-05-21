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
using test.pages;

namespace test.pages
{
    /// <summary>
    /// Логика взаимодействия для user.xaml
    /// </summary>
    public partial class user : Page
    {
        public user()
        {
            InitializeComponent();
            //DGridProducts.ItemsSource = testEntities.GetContext().products.ToList();

        }

        public void refresh()
        {
            DGridProducts.ItemsSource = Test2Entities.GetContext().products.ToList();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObject.Navigate(new admin((sender as Button).DataContext as products));
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frameObject.Navigate(new admin(null));
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            var productsFroRemoving = DGridProducts.SelectedItems.Cast<products>().ToList();

            if (MessageBox.Show($"Удалить? {productsFroRemoving.Count()} fds?", "Внимание",
                MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    Test2Entities.GetContext().products.RemoveRange(productsFroRemoving);
                    Test2Entities.GetContext().SaveChanges();
                    MessageBox.Show("Удалено");
                    refresh();
                } 
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
                
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if(Visibility == Visibility.Visible) 
            {
                Test2Entities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                refresh();
            }
        }
    }
}
