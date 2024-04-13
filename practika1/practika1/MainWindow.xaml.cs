using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using practika1.yandex_storeDataSetTableAdapters;

namespace practika1
{
    public partial class MainWindow : Window
    {
        DeliveryTableAdapter deliveryAdapter = new DeliveryTableAdapter();
        ProductsTableAdapter productsAdapter = new ProductsTableAdapter();
        OrdersTableAdapter ordersAdapter = new OrdersTableAdapter();

        public MainWindow()
        {
            InitializeComponent();


            DeliveryDataGrid.ItemsSource = deliveryAdapter.GetData();
            DeliveryDataGrid.DisplayMemberPath = "delivery_id";

            ProductsDataGrid.ItemsSource = productsAdapter.GetData();
            ProductsDataGrid.DisplayMemberPath = "product_name";

            OrdersDataGrid.ItemsSource = ordersAdapter.GetData();
            OrdersDataGrid.DisplayMemberPath = "order_id";
        }

   
        private void DeliveryDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (DeliveryDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = DeliveryDataGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    var id = selectedRow.Row[0];
                    var status = selectedRow.Row[2];
                    MessageBox.Show($"Delivery ID: {id}, Status: {status}");
                }
            }
        }
  
        private void ProductsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ProductsDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = ProductsDataGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    var id = selectedRow.Row[0];
                    var name = selectedRow.Row[1];
                    MessageBox.Show($"Product ID: {id}, Name: {name}");
                }
            }
        }

        private void OrdersDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (OrdersDataGrid.SelectedItem != null)
            {
                DataRowView selectedRow = OrdersDataGrid.SelectedItem as DataRowView;
                if (selectedRow != null)
                {
                    var id = selectedRow.Row[0];
                    var date = selectedRow.Row[1];
                    MessageBox.Show($"Order ID: {id}, Date: {date}");
                }
            }
        }
    }
}
