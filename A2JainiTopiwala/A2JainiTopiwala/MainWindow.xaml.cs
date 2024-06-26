using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace A2JainiTopiwala
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void DisplayData(string query, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(Data.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                if (parameters != null)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                grdEmployees.ItemsSource = dt.DefaultView;
            }
        }

        private void btnGetAllEmp_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT EmployeeID, FirstName, LastName, Title, CONVERT(VARCHAR, BirthDate, 101) AS BirthDate FROM Employees";
            DisplayData(query);
        }

        private void btnSearchbyTitle_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT EmployeeID, FirstName, LastName, Title, CONVERT(VARCHAR, BirthDate, 101) AS BirthDate FROM Employees WHERE Title LIKE @Title";
            DisplayData(query, new SqlParameter("@Title", $"%{txtTitle.Text}%"));
        }

        private void btnSortbyAge_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT EmployeeID, FirstName, LastName, Title, BirthDate, DATEDIFF(year, BirthDate, GETDATE()) AS Age FROM Employees ORDER BY Age DESC"; // Or ASC for ascending
            DisplayData(query);
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            string query = @"SELECT o.OrderID, 
                                    e.FirstName + ' ' + e.LastName AS EmployeeName, 
                                    CONVERT(VARCHAR, o.OrderDate, 101) AS OrderDate, 
                                    CONVERT(VARCHAR, o.ShippedDate, 101) AS ShippedDate, 
                                    o.ShipCity, 
                                    o.ShipCountry 
                             FROM Orders o 
                             INNER JOIN Employees e ON o.EmployeeID = e.EmployeeID";
            DisplayData(query);
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void grdEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (grdEmployees.SelectedItem is DataRowView dataRow)
            {
                txtID.Text = dataRow["EmployeeID"].ToString();
                txtTitle.Text = dataRow["Title"].ToString();
                txtFirstname.Text = dataRow["FirstName"].ToString();
                
                DateTime birthDate;
                if (DateTime.TryParse(dataRow["BirthDate"].ToString(), out birthDate))
                {
                    txtBirthDate.Text = birthDate.ToShortDateString(); 
                }
                else
                {
                    txtBirthDate.Text = "";
                }
            }
        }
    }
}