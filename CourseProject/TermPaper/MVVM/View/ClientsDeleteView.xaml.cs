using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// Логика взаимодействия для ClientsDeleteView.xaml
    /// </summary>
    public partial class ClientsDeleteView : UserControl
    {

        BaseField baseField = new BaseField();
        private SqlConnection sqlConnection = null;
        public ClientsDeleteView()
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

        private void ___DeleteLoad__Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            sqlConnection.Open();
            GroupComboBoxRefresh();


        }
        public void GroupComboBoxRefresh()
        {
            string queryString = "SELECT * From Clients";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ComboBoxDelete.Items.Clear();
            while (sqlDataReader.Read())
            {
                int ClientsId = sqlDataReader.GetInt32(0);
                string FirstName = sqlDataReader.GetString(1);
                string LastName = sqlDataReader.GetString(2);
                ComboBoxDelete.Items.Add($"{ClientsId}: {FirstName}: {LastName}");
            }         
        }

        private void ComboBox_DropDownClosed(object sender, EventArgs e)
        {
            baseField.ClientsID = Convert.ToInt32(SearchElementID(ComboBoxDelete.Text));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string query = $"Delete From [dbo].[Clients] WHERE ClientsID = {baseField.ClientsID}"; 
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            GroupComboBoxRefresh();
        }
    }
}
