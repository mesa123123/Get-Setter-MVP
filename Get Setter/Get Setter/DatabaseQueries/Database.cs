using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Get_Setter.Entities;

namespace Get_Setter.DatabaseQueries
{
    public class GetSetterDb
    {

        public SqlConnection dBConn;


        public GetSetterDb()
        {
            SqlConnectionStringBuilder conn = new SqlConnectionStringBuilder
            {
                DataSource = "bowmanpete.database.windows.net",
                UserID = "bowmanpete",
                Password = "St0reh!ghintransit",
                InitialCatalog = "GetSetterDb"
            };

        }

        public List<Exercise> GetExercises()
        {
            List<Exercise> exerciseList = new List<Exercise>();
            string queryString = "";
            SqlCommand dBCmd = new SqlCommand(queryString, dBConn);
            dBConn.Open();
            SqlDataReader dBReader = dBCmd.ExecuteReader();
            while (dBReader.Read())
            {
                IDataRecord dBExerciseData = dBReader;
                Exercise nextExercise = new Exercise
                {
                    ExerciseID = Convert.ToInt16(dBExerciseData.GetValue(0)),
                    ExerciseName = Convert.ToString(dBExerciseData.GetValue(1)),
                    ExerciseType = Convert.ToString(dBExerciseData.GetValue(2)),
                    Musclegroup = Convert.ToString(dBExerciseData.GetValue(3)),
                    MuscleNumber = Convert.ToInt16(dBExerciseData.GetValue(4))
                };
                exerciseList.Add(nextExercise);
            }
            dBConn.Close();
            return exerciseList;
        }

        public List<Routine> RoutineRead()
        {
            List<Routine> routineList = new List<Routine>();
            dBConn.OpenAsync();
            
                return routineList;
        }

        public List<DayShedule> DaySheduleRead()
        {
            List<DayShedule> daySheduleList = new List<DayShedule>();
            
                return daySheduleList;
        }

        public List<LoggedSets> LoggedSetsRead()
        {
            List<LoggedSets> loggedSetsList = new List<LoggedSets>();

            return loggedSetsList;
        }

        public void RoutineWrite(Routine newRoutine)
        {

        }

        public void DaySheduleWrite(DayShedule newDaySheduleList)
        {

        }

        public void LoggedSetsWrite(LoggedSets newLoggedSet)
        {

        }

        public void RoutineUpdate(Routine routineToUpdate)
        {

        }

    }
}
