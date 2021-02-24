using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelData {
    public int highScore;
    public int star;
    public bool isUnlock;

    public int StarOpen () {

        return star;
    }

    // public void SetHighScore (int inputScore) {
    //     if (inputScore > highScore) {
    //         highScore = inputScore;
    //     }
    // }
}