using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogData {
    public bool canNext = true;
    public bool openIlustration = false;
    public Sprite ilustImage;
    public bool forPlayer = false;
    public bool loadChoice;
    public int choiceID;
    public bool minimize;
    public int nextTake;
    [TextArea]
    public string dialogText;
}

[Serializable]
public class Choice {
    public int ID;
    public string qustionText;
    [TextArea]
    public string[] choiceText = new string[4];
    public int choiceAnswer = -1;
    public int score;
}