using Microsoft.WindowsAzure.MobileServices;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Get_Setter.Models
{
    [Preserve(AllMembers = true)]
    public class Exercises
    {
        [PrimaryKey, AutoIncrement]
        public int ExerciseID { get; set; }
        public string ExerciseName { get; set; }
        public string MuscleGroup { get; set; }
        public string MuscleName { get; set; }
    }
}
