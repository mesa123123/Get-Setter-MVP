﻿using System;
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
using Get_Setter.DatabaseQueries;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RoutineManagementPage : Page
    {

        private GetSetterDb dbConn;

        public RoutineManagementPage()
        {
            this.InitializeComponent();
            dbConn = new GetSetterDb();
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

    }
}
