using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace TermPaper.MVVM.View
{
    /// <summary>
    /// Логика взаимодействия для ReservationsEditView.xaml
    /// </summary>
    public partial class ReservationsEditView : UserControl
    {
        DataBase dataBase = new DataBase();
        BaseField baseField = new BaseField();
        public ReservationsEditView()
        {
            InitializeComponent();
        }
        public string SearchElementID(string SearchRow)
        {
            string SearchElementId = null;
            for (int i = 0; i < SearchRow.Length; i++)
            {
                if (SearchRow[i] == ':')
                {
                    break;
                }
                else
                {
                    SearchElementId += SearchRow[i];
                }
            }
            return SearchElementId;
        }
        public void GroupComboBoxRefresh_2()
        {
            dataBase.openConnection();
            string queryString = $"SELECT * From Reservations WHERE ReservationsID = {baseField.ReservationsId}";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {

                DatePickerCheckInDate.Text = Convert.ToString(sqlDataReader.GetDateTime(1));
                DatePickerCheckOutDate.Text = Convert.ToString(sqlDataReader.GetDateTime(2));
                RoomIDText.Text = Convert.ToString(sqlDataReader.GetInt32(3));
                ReservationStatusText.Text = sqlDataReader.GetString(4);
                TypePaymentText.Text = sqlDataReader.GetString(5);
                ClientIDText.Text = Convert.ToString(sqlDataReader.GetInt32(6));

            }
            dataBase.closeConnection();
        }
        public void GroupComboBoxRefresh()
        {
            dataBase.openConnection();
            string queryString = "SELECT * From Reservations";
            SqlCommand command = new SqlCommand(queryString, dataBase.getConnection());
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ComboBoxEdit.Items.Clear();
            while (sqlDataReader.Read())
            {
                int ReservationsId = sqlDataReader.GetInt32(0);
                string CheckInDate = Convert.ToString(sqlDataReader.GetDateTime(1));
                string CheckOutDate = Convert.ToString(sqlDataReader.GetDateTime(2));
                ComboBoxEdit.Items.Add($"{ReservationsId}: {CheckInDate}: {CheckOutDate}");
            }
            dataBase.closeConnection();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataBase.openConnection();
            baseField.CheckInDate = Convert.ToDateTime(DatePickerCheckInDate.Text);
            baseField.CheckOutDate = Convert.ToDateTime(DatePickerCheckOutDate.Text);
            string query = $"UPDATE [dbo].[Reservations] SET [CheckInDate] = '{baseField.CheckInDate.Date.Year}-{baseField.CheckInDate.Date.Month}-{baseField.CheckInDate.Date.Day}', [CheckOutDate] = '{baseField.CheckOutDate.Date.Year}-{baseField.CheckOutDate.Date.Month}-{baseField.CheckInDate.Date.Day}', [RoomID] = '{RoomIDText.Text}', [ReservationStatus] = { ReservationStatusText.Text},[typePayment] = '{TypePaymentText.Text}',[ClientID] = '{ClientIDText.Text}' WHERE ReservationsID = {baseField.ReservationsId}";
            SqlCommand command = new SqlCommand(query, dataBase.getConnection());
            command.ExecuteNonQuery();
            GroupComboBoxRefresh();
            dataBase.closeConnection();
        }

        private void ComboBoxEdit_DropDownClosed(object sender, EventArgs e)
        {
            baseField.ReservationsId = Convert.ToInt32(SearchElementID(ComboBoxEdit.Text));
            GroupComboBoxRefresh_2();
        }

        private void Edit_Loaded(object sender, RoutedEventArgs e)
        {
            GroupComboBoxRefresh();

        }

        private void ReservationStatusText_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
