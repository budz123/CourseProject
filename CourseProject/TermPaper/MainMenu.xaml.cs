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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using TermPaper.MVVM.View;



namespace TermPaper
{
   
    /// <summary>
    /// Логика взаимодействия для MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        DataBase dataBase = new DataBase();
        private SqlConnection sqlConnection = null;
        public string tableName;
        
        public MainMenu()
        {
           
        InitializeComponent();
        }


        public void Resever(string tableName)
        {
            dataBase.openConnection();
            string zapros = "SELECT Reservations.ReservationsID, Reservations.CheckInDate,Reservations.CheckOutDate,Reservations.ReservationStatus,Reservations.typePayment,Rooms.Number,Clients.[Name],Clients.LastName FROM Reservations left join Rooms on Rooms.RoomsID = Reservations.RoomID left join Clients on Clients.ClientsID = Reservations.ClientID";
            SqlCommand command = new SqlCommand(zapros, dataBase.getConnection());
            command.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable($"{tableName}");
            sqlDataAdapter.Fill(dt);
            DataGrid1.ItemsSource = dt.DefaultView;
            sqlDataAdapter.Update(dt);
            dataBase.closeConnection();
        }

        public void DataGridRefsecens(string tableName)
        {

           
            dataBase.openConnection();
            string zapros = $"Select * From {tableName}";
            SqlCommand command = new SqlCommand(zapros, dataBase.getConnection());
            command.ExecuteNonQuery();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable($"{tableName}");
            sqlDataAdapter.Fill(dt);
            DataGrid1.ItemsSource = dt.DefaultView;
            sqlDataAdapter.Update(dt);
            dataBase.closeConnection();

            // DataBase.OpenConnection(); 
            // SqlCommand cmd = new SqlCommand(zapros, DataBase.GetConnection());
            // cmd.ExecuteNonQuery();
            // SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            // DataTable dt = new DataTable($"{tableName}");
            //  sqlDataAdapter.Fill(dt);
            // DataGrid1.ItemsSource = dt.DefaultView;
            // sqlDataAdapter.Update(dt);
            // DataBase.CloseConnection();

        }

       public void Button_Reservations(object sender, RoutedEventArgs e)
        {
            Resever("Reservations");
        }

        public void Button_Rooms(object sender, RoutedEventArgs e)
        {

            DataGridRefsecens("Rooms");
        }

        public void Button_Clients(object sender, RoutedEventArgs e)
        {
            DataGridRefsecens("Clients");
        }

        public void Button_Reservations_add(object sender, RoutedEventArgs e)
        {
            ReservationsView Window1 = new ReservationsView();
            Window1.Show();
        }

        private void Button_Rooms_add(object sender, RoutedEventArgs e)
        {
            RoomsView Window2 = new RoomsView();
            Window2.Show();
        }

        private void Button_Clients_add(object sender, RoutedEventArgs e)
        {
            ClientsView Window3 = new ClientsView();
            Window3.Show();
        }

        private void Button_Rooms_Remove(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Reservations_Remove(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Clients_Remove(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Rooms_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Reservations_Edit(object sender, RoutedEventArgs e)
        {

        }

        private void Button_clients_Edit(object sender, RoutedEventArgs e)
        {

        }
    }
}
