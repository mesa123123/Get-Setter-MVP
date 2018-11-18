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
using SQLite.Net;
using SQLite.Net.Attributes;
using System.Collections;
using Get_Setter.DatabaseQueries;
using Get_Setter.Entities;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewRoutinePage : Page
    {
        private string RoutineGoal;
        private string Day11;
        private string Day12;
        private string Day13;
        private string Day21;
        private string Day22;
        private string Day23;
        private string Day31;
        private string Day32;
        private string Day33;
        private string Day41;
        private string Day42;
        private string Day43;
        private GetSetterDb dbConn;
        private Routine newRoutine;

        public NewRoutinePage(GetSetterDb dbConn)
        {
            this.InitializeComponent();
            this.dbConn = dbConn;
        }

        private void NavToHomePage(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void PaneTrigger(object sender, RoutedEventArgs e)
        {
            NavigationPane.IsPaneOpen = !NavigationPane.IsPaneOpen;
        }

        private void NavToRoutineManagement(object sender, RoutedEventArgs e)
        {
            dbConn.RoutineWrite(newRoutine);
            this.Frame.Navigate(typeof(RoutineManagementPage));
        }

        private void NavToRoutineRecords(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RoutineRecords));
        }

        private void NavToThisWorkout(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Workout));
        }

        private void Goal_Button_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton checkedGoal = sender as RadioButton;
            newRoutine = new Routine
            {
                Goal = checkedGoal.Tag.ToString(),
                Days = 4,
                CurrentDay = 1
            };

        }

        private void Day1_1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pickedExercise = sender as RadioButton;
            Day11 = pickedExercise.Tag.ToString();
        }

        private void Day1_2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pickedExercise = sender as RadioButton;
            Day12 = pickedExercise.Tag.ToString();
        }

        private void Day1_3_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pickedExercise = sender as RadioButton;
            Day13 = pickedExercise.Tag.ToString();
        }

    }
}
