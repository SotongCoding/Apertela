using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BaseData : MonoBehaviour {
    static BaseData instance;

    string path;
    string fileName = "levelDat.dat";

    public List<LevelData> levelSaveData = new List<LevelData> ();
    private void Awake () {

#if UNITY_EDITOR
        path = Application.dataPath;
#elif UNITY_ANDROID
        path = Application.persistentDataPath;
#else
        path = Application.dataPath;
#endif
        if (instance == null) {
            DontDestroyOnLoad (gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy (gameObject);
        }
    }

    private void Update () {
        // if (Input.GetKeyDown (KeyCode.Return)) {
        //     SaveData ();
        // } else if (Input.GetKeyDown (KeyCode.Escape)){
        //     LoadData();
        // }
    }

    public void SaveData () {
        SaveLoadManager.SaveData<LevelData> (levelSaveData, path, fileName);
    }
    public void LoadData () {
        SaveLoadManager.LoadData<LevelData> (path, fileName, out List<LevelData> result);

        var temp = new List<LevelData> ();
        temp = result;

        levelSaveData = temp;
    }
    public List<LevelData> GetSaveData () {
        return levelSaveData;
    }
    public void AddScoreToLevel (int level, int score, int star) {
        Debug.Log (level + " : " + score);
        levelSaveData[level - 1].highScore =
            levelSaveData[level - 1].highScore >= score ? levelSaveData[level - 1].highScore : score;
        levelSaveData[level - 1].star = star;

        if (levelSaveData[level - 1].star >= 1) {
            levelSaveData[level].isUnlock = true;
        }
    }

}