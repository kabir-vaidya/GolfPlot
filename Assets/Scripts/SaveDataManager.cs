using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveDataManager {


    public static void SaveJsonData(ScoreSaveData scoreSaveData) {
        ScoreSaveData score = scoreSaveData;
        if (FileManager.WriteToFile("SaveData.json", score.ToJson())) {
            Debug.Log("Save successful");
        }
    }

    public static void LoadJsonData(ScoreSaveData scoreSaveData) {
        if (!File.Exists("SaveData.json")) {
            List<Score> scores = new List<Score> {
                new Score() { level_number = 1, score = 0 },
                new Score() { level_number = 2, score = 0 },
                new Score() { level_number = 3, score = 0 },
                new Score() { level_number = 4, score = 0 },
                new Score() { level_number = 5, score = 0 },
                new Score() { level_number = 6, score = 0 },
                new Score() { level_number = 7, score = 0 },
                new Score() { level_number = 8, score = 0 },
                new Score() { level_number = 9, score = 0 },
                new Score() { level_number = 10, score = 0 },
	        };
            ScoreSaveData scoreSave = new ScoreSaveData() { scores = scores };
            SaveJsonData(scoreSave);
        }
        if (FileManager.LoadFromFile("SaveData.json", out var json)) {
            Debug.Log("Load complete");
            scoreSaveData.LoadFromJson(json);
        }
    }

}

