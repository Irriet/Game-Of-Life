using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Game_Of_Life
{
    class Saves
    {
        WritingService writingService = new WritingService();
        private string GetFileName()
        {
            DateTime date = DateTime.Now;
            string dateNow = date.ToShortDateString();
            string timeNow = date.ToString("hmmsstt");
            string fileName = dateNow + " " + timeNow;
            return fileName;
        }
        public void PostGameSaving(Data.Grid currentGrid)
        {
            string createSave = writingService.GameOver();
            if (createSave == "y" || createSave == "Y")
            {
                Saves saves = new Saves();
                saves.SaveToFile(currentGrid);
                Console.Clear();
                writingService.GameWasSaved();
            }
            else if (createSave == "n" || createSave == "N")
            {
                Console.Clear();
            }
        }


        public void SaveToFile(Data.Grid currentGrid)
        {
            string fileName = GetFileName();
            string jsonConvert = JsonConvert.SerializeObject(currentGrid);
            string path = $@"C:\Users\Irriet\Desktop\C#\Game Of Life\Saves\{fileName}.json";

            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.Write(jsonConvert.ToString());
                streamWriter.Close();
            }
        }
        public void RunSave()
        {

        }



    }
}
