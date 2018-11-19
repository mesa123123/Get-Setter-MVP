using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Get_Setter.Entities;
using Get_Setter.Database;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        GetSetterDb dBConn;

        public MainPage()
        {
            this.InitializeComponent();
           dBConn = new GetSetterDb();
        }

        private void NavToRoutineManagement(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RoutineManagementPage));
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

    }
}
