using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class ChoiceUIMan : MonoBehaviour {
    QuestionInitializer questionMan;
    ScoreCounter scoreMan;
    QuestionUIHandler questionUI;

    public GameObject choiceBox;

    private void Awake () {
        scoreMan = FindObjectOfType<ScoreCounter> ();
        questionMan = FindObjectOfType<QuestionInitializer> ();
        questionUI = FindObjectOfType<QuestionUIHandler> ();
    }
    // Start is called before the first frame update
    public void Initial (Choice choiceData) {
        //Membuat 4 Objek dengan isi Script load kalimat selanjutnya dan hitung scor
        for (int i = 0; i < 4; i++) {
            GameObject choice = Instantiate (choiceBox, transform);
            //Set text 
            choice.GetComponentInChildren<TextMeshProUGUI> ().text = choiceData.choiceText[i];

            if (i == choiceData.choiceAnswer) {
                choice.GetComponent<Button> ().onClick.AddListener (delegate { TrueAnswer (choiceData.score); });
            } else {
                choice.GetComponent<Button> ().onClick.AddListener (delegate { FalseAnswer (); });
            }

            choice.transform.localScale = Vector3.one;
        }

    }

    public void TrueAnswer (int score) {
        //questionMan.npcDialog.text = text;

        questionMan.nextButton.gameObject.SetActive (true);
        questionMan.nextButton.onClick.RemoveAllListeners ();
        foreach (Transform item in questionMan.choiceUI.transform) {
            Destroy (item.gameObject);
        }

        scoreMan.AddScore (score);
        SoundControl.PlaySfx (sfx_sound.true_answer);

        questionUI.ShowBenarSalah (true);
        StartCoroutine (LoadNextQuestion ());
    }
    public void FalseAnswer () {
        //questionMan.npcDialog.text = text;

        questionMan.nextButton.gameObject.SetActive (true);
        questionMan.nextButton.onClick.RemoveAllListeners ();
        // questionMan.nextButton.onClick.AddListener (
        //     delegate { questionMan.InitialQuestion (questionMan.curDialognumber + 1); });

        foreach (Transform item in questionMan.choiceUI.transform) {
            Destroy (item.gameObject);
        }
        SoundControl.PlaySfx (sfx_sound.false_answer);
        questionUI.ShowBenarSalah (false);
        StartCoroutine (LoadNextQuestion ());
    }

    IEnumerator LoadNextQuestion () {
        yield return new WaitForSeconds (2f);
        //questionMan.curDialognumber++;
        questionMan.InitialQuestion ();
    }
}