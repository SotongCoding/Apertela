using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class L10_QuestionLoader : MonoBehaviour {

    [TextArea]
    [SerializeField] L10_Question[] questions;
    [SerializeField] Choice[] choices;
    [SerializeField] PengayaanData[] pengayaans;

    [Header ("SetVaraible")]
    public GameObject choiceUI;
    public TextMeshProUGUI questions_text;
    public Text mainQuestion;

    // Start is called before the first frame update
    public void Initialize (int code) {
        this.gameObject.SetActive (true);

        mainQuestion.text = questions[code].question;
        questions_text.text = questions[code].someText;
        choiceUI.GetComponent<ChoiceUIMan> ().Initial (choices[code]);

    }
}

[System.Serializable]
public class L10_Question {
    public string someText;
    public string question;
}