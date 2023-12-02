using Newtonsoft.Json;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tachograph.Services.Domain.Entities;

namespace TachographDataSimulator
{
    public partial class DataSimulator : Form
    {
        private int DrivingDurationInSeconds = 1 * 60 * 60;
        private int RestDurationInSeconds = 45 * 60;
        private string MaxFilesPerDay = ConfigurationManager.AppSettings["MaxFilesPerDay"];
        private string MaxUniqueDrivers = ConfigurationManager.AppSettings["MaxUniqueDrivers"];
        private string MaxDrivingHoursPerDay = ConfigurationManager.AppSettings["MaxDrivingHoursPerDay"];
        private string MaxDrivingHoursPerWeek = ConfigurationManager.AppSettings["MaxDrivingHoursPerWeek"];
        private List<DriverFile> driverFiles = new List<DriverFile>();
        private System.Threading.Timer simulationTimer;
        private Random random = new Random();
        private TimeOnly startTime = new TimeOnly(0, 0);
        private TimeOnly endTime = new TimeOnly(0, 0);
        public DataSimulator()
        {
            InitializeComponent();

            // Initialize timer for data simulation
            simulationTimer = new System.Threading.Timer(GenerateData, null, Timeout.Infinite, Timeout.Infinite);
        }

        private void GenerateData(object state)
        {      
            foreach (var driverFile in driverFiles)
            {
                for (int i = 0; i <= 4; i++)
                {
                    // Simulate Driving or Rest activity
                    var activity = i == 3 ? "Rest" : "Driving";

                    if (startTime == new TimeOnly(0, 0))
                    {
                        startTime = GetRandomTime();
                        endTime = startTime.Add(TimeSpan.FromSeconds(activity == "Driving" ? DrivingDurationInSeconds : RestDurationInSeconds));
                    }
                    else
                    {
                        startTime = endTime;
                        endTime = startTime.Add(TimeSpan.FromSeconds(activity == "Driving" ? DrivingDurationInSeconds : RestDurationInSeconds));
                    }

                    // Create a new record
                    var record = new TachographRecord
                    {
                        driver = driverFile.Driver,
                        date = DateOnly.FromDateTime(Convert.ToDateTime(DateTime.Now)),
                        timestart = startTime,
                        timeend = endTime,
                        activity = activity
                    };

                    // Add the record to the driver file
                    driverFile.Records.Add(record);

                    // Save the record to a JSON file
                    SaveToJson(driverFile.Driver, record);
                }
            }
        }

        public TimeOnly GetRandomTime()
        {
            Random random = new Random();
            int hours = random.Next(0, 12);
            int minutes = random.Next(0, 60);
            int seconds = random.Next(0, 60);

            return new TimeOnly(hours, minutes, seconds);
        }

        private void SaveToJson(string driver, TachographRecord record)
        {
            var fileName = $"{driver}_{DateTime.Now:yyyyMMdd}.json";
            var filePath = Path.Combine(ConfigurationManager.AppSettings["JsonFilesPath"], fileName);

            // Load existing records from the file
            List<TachographRecord> existingRecords;
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                existingRecords = JsonConvert.DeserializeObject<List<TachographRecord>>(json);
            }
            else
            {
                existingRecords = new List<TachographRecord>();
            }

            // Add the new record to the existing records
            existingRecords.Add(record);

            // Save the updated records back to the file
            var updatedJson = JsonConvert.SerializeObject(existingRecords, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);
        }

        private void btnStartSimulation_Click(object sender, EventArgs e)
        {
            // Start simulation
            AddDriver("Driver A");
            AddDriver("Driver B");
            AddDriver("Driver C");
            simulationTimer.Change(0, 30000);
            btnStartSimulation.Enabled = false;
        }

        private void btnStopSimulation_Click(object sender, EventArgs e)
        {
            // Stop simulation
            simulationTimer.Change(Timeout.Infinite, Timeout.Infinite);
            btnStartSimulation.Enabled = true;
        }

        private void AddDriver(string driverName)
        {
            driverFiles.Add(new DriverFile { Driver = driverName });
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
