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
using Get_Setter.Database;
using Get_Setter.Entities;
using System.Collections.ObjectModel;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Get_Setter
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NewRoutinePage : Page
    {
        private string RoutineGoal;
        private Routine newRoutine;
        private List<Exercise> chestCollection1 = new List<Exercise>();
        private List<Exercise> chestCollection2 = new List<Exercise>();
        private List<Exercise> chestCollection3 = new List<Exercise>();
        private List<Exercise> backCollection1 = new List<Exercise>();
        private List<Exercise> backCollection2 = new List<Exercise>();
        private List<Exercise> backCollection3 = new List<Exercise>();
        private List<Exercise> legCollection1 = new List<Exercise>();
        private List<Exercise> legCollection2 = new List<Exercise>();
        private List<Exercise> legCollection3 = new List<Exercise>();
        private List<Exercise> armCollection1 = new List<Exercise>();
        private List<Exercise> armCollection2 = new List<Exercise>();
        private List<Exercise> armCollection3 = new List<Exercise>();

        public NewRoutinePage()
        {
            this.InitializeComponent();
            IEnumerable<Exercise> exerciseEnum = new GetSetterDb().GetExercises("SELECT * FROM Exercises");
            List<Exercise> exerciseCollection = new List<Exercise>(exerciseEnum);
            SortCollections(exerciseCollection);
            PopulateRadioButtons(chestCollection1, StackChest1, "chest1Group", Chest1_Checked);
            PopulateRadioButtons(chestCollection2, StackChest2, "chest2Group", Chest1_Checked);
            PopulateRadioButtons(chestCollection3, StackChest3, "chest3Group", Chest1_Checked);
            PopulateRadioButtons(backCollection1, StackBack1, "back1Group", Chest1_Checked);
            PopulateRadioButtons(backCollection2, StackBack2, "back2Group", Chest1_Checked);
            PopulateRadioButtons(backCollection3, StackBack3, "back3Group", Chest1_Checked);
            PopulateRadioButtons(legCollection1, StackLeg1, "leg1Group", Chest1_Checked);
            PopulateRadioButtons(legCollection2, StackLeg2, "leg2Group", Chest1_Checked);
            PopulateRadioButtons(legCollection3, StackLeg3, "leg3Group", Chest1_Checked);
            PopulateRadioButtons(armCollection1, StackArm1, "arm1Group", Chest1_Checked);
            PopulateRadioButtons(armCollection2, StackArm2, "arm2Group", Chest1_Checked);
            PopulateRadioButtons(armCollection3, StackArm3, "arm3Group", Chest1_Checked);
        }

        private void PopulateRadioButtons(List<Exercise> exerciseCollection, StackPanel stackName, string groupName, RoutedEventHandler handler)
        {
            Style RadioBluePrint = Application.Current.Resources["RadioBluePrint"] as Style;
            for (int i = 0; i < exerciseCollection.Count; i++)
            {
                RadioButton nextRadio = new RadioButton();
                nextRadio.Checked += handler;
                nextRadio.Margin = new Thickness(10.0);
                nextRadio.Style = RadioBluePrint;
                nextRadio.Content = exerciseCollection.ElementAt(i)?.ExerciseName.ToString().ToUpper();
                nextRadio.GroupName = groupName;
                stackName.Children.Add(nextRadio);
            }
        }

        public void PrintCollections(List<Exercise> collectioner)
        {
            for (int i = 0; i < collectioner.Count; i++)
            {
                Debug.WriteLine(i + "|| Next Please: " + " " + collectioner.ElementAt(i).ExerciseName);
            }
        }

        public void SortCollections(List<Exercise> fullCollection)
        {
            for (int i = 0; i < fullCollection?.Count; i++)
            {
                if (fullCollection.ElementAt(i).Musclegroup.Equals("Chest"))
                    {
                        if (fullCollection.ElementAt(i).MuscleNumber.Equals(1))
                        {
                            chestCollection1.Add(fullCollection.ElementAt(i));
                        }
                        else if (fullCollection.ElementAt(i).MuscleNumber.Equals(2))
                        {
                            chestCollection2.Add(fullCollection.ElementAt(i));
                        }
                        else if (fullCollection.ElementAt(i).MuscleNumber.Equals(3))
                        {
                            chestCollection3.Add(fullCollection.ElementAt(i));
                        }
                    }
                else if (fullCollection.ElementAt(i).Musclegroup.Equals("Back"))
                {
                    if (fullCollection.ElementAt(i).MuscleNumber.Equals(1))
                    {
                        backCollection1.Add(fullCollection.ElementAt(i));
                    }
                    else if (fullCollection.ElementAt(i).MuscleNumber.Equals(2))
                    {
                        backCollection2.Add(fullCollection.ElementAt(i));
                    }
                    else if (fullCollection.ElementAt(i).MuscleNumber.Equals(3))
                    {
                        backCollection3.Add(fullCollection.ElementAt(i));
                    }
                }
                else if (fullCollection.ElementAt(i).Musclegroup.Equals("Legs"))
                {
                    if (fullCollection.ElementAt(i).MuscleNumber.Equals(1))
                    {
                        legCollection1.Add(fullCollection.ElementAt(i));
                    }
                    else if (fullCollection.ElementAt(i).MuscleNumber.Equals(2))
                    {
                        legCollection2.Add(fullCollection.ElementAt(i));
                    }
                    else if (fullCollection.ElementAt(i).MuscleNumber.Equals(3))
                    {
                        legCollection3.Add(fullCollection.ElementAt(i));
                    }
                }
                else if (fullCollection.ElementAt(i).Musclegroup.Equals("Arms"))
                {
                    if (fullCollection.ElementAt(i).MuscleNumber.Equals(1))
                    {
                        armCollection1.Add(fullCollection.ElementAt(i));
                    }
                    else if (fullCollection.ElementAt(i).MuscleNumber.Equals(2))
                    {
                        armCollection2.Add(fullCollection.ElementAt(i));
                    }
                    else if (fullCollection.ElementAt(i).MuscleNumber.Equals(3))
                    {
                        armCollection3.Add(fullCollection.ElementAt(i));
                    }
                }
                else
                {
                    continue;
                }
             
            }

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

        private void Chest1_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pickedExercise = sender as RadioButton;
        }

        private void Chest2_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pickedExercise = sender as RadioButton;
        }

        private void Chest3_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pickedExercise = sender as RadioButton;
        }

    }
}
