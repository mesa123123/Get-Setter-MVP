using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using Get_Setter;
using Get_Setter.Entities;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;

namespace Get_Setter.Database
{
    public class GetSetterDb
    {

        public SqlConnectionStringBuilder conn;


        public GetSetterDb()
        {
            conn = new SqlConnectionStringBuilder
            {
                DataSource = "bowmanpete.database.windows.net",
                UserID = "bowmanpete",
                Password = "St0reh!ghintransit",
                InitialCatalog = "GetSetterDb"
            };

        }

        public ObservableCollection<Exercise> GetExercises(string queryString)
        {
            ObservableCollection<Exercise> exerciseList = new ObservableCollection<Exercise>();

            try
            {
                using (SqlConnection dBConn = new SqlConnection(conn.ConnectionString))
                {
                    SqlCommand dBCmd = new SqlCommand(queryString, dBConn);
                    dBConn.Open();
                    SqlDataReader dBReader = dBCmd.ExecuteReader();
                    while (dBReader.Read())
                    {
                        IDataRecord dBExerciseData = dBReader;
                        Exercise nextExercise = new Exercise
                        {
                            ExerciseID = dBExerciseData.GetInt32(0),
                            ExerciseName = dBExerciseData.GetString(1),
                            ExerciseType = dBExerciseData.GetString(2),
                            Musclegroup = dBExerciseData.GetString(3),
                            MuscleNumber = dBExerciseData.GetInt32(4)
                        };
                        exerciseList.Add(nextExercise);
                    }
                    dBConn.Close();
                }
            } catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }           
            return exerciseList;
        }

        public ObservableCollection<Routine> GetRoutines(string queryString)
        {
            ObservableCollection<Routine> routineList = new ObservableCollection<Routine>();

            try
            {
                using (SqlConnection dBConn = new SqlConnection(conn.ConnectionString))
                {
                    SqlCommand dBCmd = new SqlCommand(queryString, dBConn);
                    dBConn.Open();
                    SqlDataReader dBReader = dBCmd.ExecuteReader();
                    while (dBReader.Read())
                    {
                        IDataRecord dBRoutineData = dBReader;
                        Routine nextRoutine = new Routine
                        {
                            RoutineID = dBRoutineData.GetInt32(0),
                            Goal = dBRoutineData.GetString(1),
                            Days = dBRoutineData.GetInt32(2)
                        };
                        routineList.Add(nextRoutine);
                    }
                    dBConn.Close();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception: " + e.Message);
            }
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

    }
}
