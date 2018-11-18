using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Get_Setter.DatabaseQueries;
using System.Data.SqlClient;
using Get_Setter.Entities;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private GetSetterDb dbConn;
        List<Exercise> listyList;

        public MainPage()
        {
            this.InitializeComponent();
            dbConn = new GetSetterDb();
        }

        public void displayExercises(object sender, RoutedEventArgs e)
        {
            listyList  = dbConn.GetExercises();

        }

        private void NavToRoutineManagement(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RoutineManagementPage(dbConn)));
        }

        private void NavToNewRoutine(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(NewRoutinePage));
        }

        private void NavToRoutineRecords(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RoutineRecords));
        }

        private void NavToThisWorkout(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Workout));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConn = new SqlConnection(dbConn.conn.ConnectionString))
            {
                sqlConn.OpenAsync();
                this.Starter.Text = sqlConn.State.ToString();
            }
        }

    }
}
