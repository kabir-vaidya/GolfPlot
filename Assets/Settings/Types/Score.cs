using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Score {
    public int level_number;
    public int score;

    //public Score(int levelNumber, int score) {
    //    level_number = levelNumber;
    //    this.score = score;
    //} 
}

public class ScoreSaveData {
    //public List<Score> scores { get; set; } = new List<Score>();
    public List<Score> scores;

    //public ScoreSaveData(List<Score> scores) {
    //    this.scores = scores;
    //}

    public string ToJson() {
        return JsonConvert.SerializeObject(this);
    }

    public void LoadFromJson(string jsonData) {
       var saveData = JsonConvert.DeserializeObject<ScoreSaveData>(jsonData);
       this.scores = saveData.scores;
    }
}

