using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelQuestionData : MonoBehaviour {
    [Header ("Dialog Data")]
    public List<DialogData> dialogs;
    [Header ("Choice Data")]
    public List<Choice> choices;
    [Header ("Choice Data")]
    public List<PengayaanData> pengayaan;

    public int[] starLogic = new int[3];
    // Start is called before the first frame update
}