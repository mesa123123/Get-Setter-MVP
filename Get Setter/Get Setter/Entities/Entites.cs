using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Setter.Entities
{
    public class Exercise
    {
        public int ExerciseID {get; set;}
        public string ExerciseName { get; set; }
        public string ExerciseType { get; set; }
        public string Musclegroup { get; set; }
        public int MuscleNumber { get; set; }
    }

    public class Routine
    {
        public int RoutineID { get; set; }
        public string Goal { get; set; }
        public int Days { get; set; }
        public int CurrentDay { get; set; }
    }

    public class DayShedule
    {
        public int SheduleID { get; set; }
        public int RoutineID { get; set; }
        public int ExerciseID { get; set; }
        public int ExerciseNumber { get; set; }
        public int DayNumber { get; set; }
    }

    public class LoggedSets
    {
        public int LogID { get; set; }
        public int SheduleID { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public int SetNumber { get; set; }
        public int Reps { get; set; }
    }

}
