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
    /// Логика взаимодействия для RoomsDeleteView.xaml
    /// </summary>
    public partial class RoomsDeleteView : UserControl
    {
        public RoomsDeleteView()
        {
            InitializeComponent();
        }

        BaseField baseField = new BaseField();
        private SqlConnection sqlConnection = null;


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

      
        public void GroupComboBoxRefresh()
        {
            string queryString = "SELECT * From Rooms";
            SqlCommand command = new SqlCommand(queryString, sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            ComboBoxDelete.Items.Clear();
            while (sqlDataReader.Read())
            {
                int RoomsId = sqlDataReader.GetInt32(0);
                string Number = sqlDataReader.GetString(1);
              
                ComboBoxDelete.Items.Add($"{RoomsId}: {Number}");
            }
        }

       

       

        private void ComboBoxDelete_DropDownClosed(object sender, EventArgs e)
        {
            baseField.RoomsId = Convert.ToInt32(SearchElementID(ComboBoxDelete.Text));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string query = $"Delete From [dbo].[Rooms] WHERE RoomsID= {baseField.RoomsId}";
            SqlCommand command = new SqlCommand(query, sqlConnection);
            command.ExecuteNonQuery();
            GroupComboBoxRefresh();
        }

        private void delete_Loaded(object sender, RoutedEventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString);
            sqlConnection.Open();
            GroupComboBoxRefresh();
        }
    }
}

