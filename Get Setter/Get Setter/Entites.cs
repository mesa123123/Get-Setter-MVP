using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Setter.Entities
{
    public class Routine : INotifyPropertyChanged
    {
        public int RoutineID { get; set; }
        public string Goal { get; set; }
        public int Days { get; set; }
        public int CurrentDay { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class DayShedule : INotifyPropertyChanged
    {
        public int SheduleID { get; set; }
        public int RoutineID { get; set; }
        public int ExerciseID { get; set; }
        public int ExerciseNumber { get; set; }
        public int DayNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class LoggedSets : INotifyPropertyChanged 
    {
        public int LogID { get; set; }
        public int SheduleID { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int SetNumber { get; set; }
        public int Reps { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
