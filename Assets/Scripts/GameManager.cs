using System;
using System.Linq;
using UnityEngine;

public class GameManager {
    static GameManager instance; 
    int starCount;

    ScoreSaveData _scoreSaveData;

    GameManager() {
        starCount = 0;
    }
    
    public static GameManager Instance() { 
        if(instance== null) {
            instance = new GameManager();
	    }
        return instance;
    }

    public void LoadScoreSaveData() {
        _scoreSaveData = new ScoreSaveData();
        SaveDataManager.LoadJsonData(_scoreSaveData);
    }

    public void DisplayScoreSaveData() {
        if (_scoreSaveData == null) LoadScoreSaveData();
        Debug.Log(_scoreSaveData.ToJson());
    }

    public ScoreSaveData GetScoreSaveData() {
        return _scoreSaveData;
    }

    public void SetScore(int levelNumber, int score) {
        Debug.Log(_scoreSaveData.ToJson());
        if(score > _scoreSaveData.scores[levelNumber].score) {
            _scoreSaveData.scores[levelNumber].score = score;
            SaveDataManager.SaveJsonData(_scoreSaveData);
            Debug.Log(_scoreSaveData.ToJson());
        }
    }

    public int GetLevelScore(int levelNumber) {
        var selectedScore = from score in _scoreSaveData.scores 
			                where score.level_number == levelNumber 
			                select score;
        return selectedScore.First().score;
    }

    public int GetFirstZeroScoreLevel() {
        var selectedScore = from score in _scoreSaveData.scores 
			                where score.score == 0
			                select score;
        return selectedScore.First().level_number;
    }

    public void ResetInstance() {
        starCount = 0;
    }

    public void IncrementStarCount() {
        Debug.Log("Number of stars: " + starCount);
        starCount++;
    }

    public int GetStarCount() {
        return starCount;
    }

}



