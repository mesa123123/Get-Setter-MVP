using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Setter
{
     public class Exercise : INotifyPropertyChanged
    {
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public string ExerciseType { get; set; }
        public string Musclegroup { get; set; }
        public int MuscleNumber { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
