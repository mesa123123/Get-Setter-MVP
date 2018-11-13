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
using SQLite.Net.Attributes;
using System.Collections;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewRoutinePage : Page
    {

        string dBPath;
        SQLiteConnection dBConnection;
        List<string> exerciseList;

        public NewRoutinePage()
        {
            this.InitializeComponent();
            dBPath = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "GetSetterDb.db");
            dBConnection = new SQLiteConnection(new
                   SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), dBPath);
        }

        private void ChooseExercises(object sender, RoutedEventArgs e)
        {
            var query = dBConnection.Table<Exercises>();

            this.exerciseList = new List<string>();
            foreach (var record in query)
            {
                this.exerciseList.Add(record.ExerciseName);
            }


        }
    }


    public class Exercises
    {
        [PrimaryKey, AutoIncrement]
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public string MuscleGroup { get; set; }
        public string MuscleName { get; set; }

    }

}
