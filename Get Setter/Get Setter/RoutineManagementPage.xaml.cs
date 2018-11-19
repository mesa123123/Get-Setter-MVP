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
using Get_Setter.Database;
using System.Collections.ObjectModel;
using Get_Setter.Entities;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoutineManagementPage : Page
    {

        ObservableCollection<Routine> routinesList;

        public RoutineManagementPage()
        {
            this.InitializeComponent();
            routinesList = new GetSetterDb().GetRoutines("SELECT DISTINCT * FROM Routines");
            Debug.Write(routinesList.Count);
            DrawRoutinesLists();
        }

        private void DrawRoutinesLists()
        {
            Style DarkButton = Application.Current.Resources["DarkButton"] as Style;
            foreach (Routine routine in routinesList)
            {
                Viewbox viewboxy = new Viewbox();
                Button routineButton = new Button();
                routineButton.Content = "ROUTINE: " + routine.RoutineID;
                routineButton.Style = DarkButton;
                routineButton.Foreground = new SolidColorBrush(Windows.UI.Colors.White);
                routineButton.FontFamily = new FontFamily("./Assets/Draftsman.tff#Draftsman");
                routineButton.Click += NavToRoutineRecords;
                routineButton.HorizontalAlignment = HorizontalAlignment.Stretch;
                routineButton.VerticalAlignment = VerticalAlignment.Stretch;
                routineButton.Margin = new Thickness(3);
                viewboxy.Child = routineButton;
                viewboxy.HorizontalAlignment = HorizontalAlignment.Stretch;
                viewboxy.VerticalAlignment = VerticalAlignment.Stretch;
                RoutineStacker.Children.Add(viewboxy);
            }
        }

        private void PaneTrigger(object sender, RoutedEventArgs e)
        {
            NavigationPane.IsPaneOpen = !NavigationPane.IsPaneOpen;
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
        
        private void NavToHome(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        private void ScrollViewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
