using Game_Of_Life.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Game_Of_Life
{
    class FileService
    {
       readonly WritingService writingService = new WritingService();
        readonly string savePath = @$"{Environment.CurrentDirectory}/Saves";

        private string GetFileName()
        {
            DateTime date = DateTime.Now;
            string dateNow = date.ToShortDateString();
            string timeNow = date.ToString("hmmsstt");
            string fileName = dateNow + " " + timeNow;
            return fileName;
        }
        public void PostGameSaving(Grid currentGrid)
        {
            string createSave = writingService.GameOver();
            if (createSave == "y" || createSave == "Y")
            {
                SaveToFile(currentGrid);
                Console.Clear();
                writingService.GameWasSaved();
            }
            else if (createSave == "n" || createSave == "N")
            {
                Console.Clear();
            }
        }
        private void SaveToFile(Grid currentGrid)
        {
            string fileName = GetFileName();
            string jsonConvert = JsonConvert.SerializeObject(currentGrid);
            string path = $@"{savePath}/{fileName}.json";

            using StreamWriter streamWriter = new StreamWriter(path, true);
            streamWriter.Write(jsonConvert.ToString());
            streamWriter.Close();
        }
        public string[] GetFilePaths()
        {
            return Directory.GetFiles(savePath);
        }
        //TODO implement 
        public Grid LoadGrid(string filePath)
        {
            string json = File.ReadAllText(filePath);
            Grid grid;
            grid = JsonConvert.DeserializeObject<Grid>(json);
            return grid;
        }



    }
}
