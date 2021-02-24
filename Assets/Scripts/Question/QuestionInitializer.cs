using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionInitializer : MonoBehaviour {
    [Header ("Other data")]
    public Button nextButton;
    public int curDialognumber;
    public Canvas QuestionObj;
    GPData playData;
    [Header ("Question")]
    public Image playerPict;
    public Image npcPict;
    public TextMeshProUGUI btmDialog, upDialog;
    public GameObject questionBox;
    public GameObject choiceUI;
    public Text mainQuestion;

    public GameObject ilust;
    public Image ilusPlace;

    int[] starLogic;
    [Header ("Dialog Data")]
    List<DialogData> dialogs;
    [Header ("Choice Data")]
    List<Choice> choices;
    [Header ("Pengayaan Data")]
    public GameObject pengayaanUI;
    PengayaanData[] textPengayaan;

    private void Start () {
        curDialognumber = 0;

        LevelQuestionData levelData = FindObjectOfType<LevelQuestionData> ();

        dialogs = levelData.dialogs;
        choices = levelData.choices;
        textPengayaan = levelData.pengayaan.ToArray ();
        starLogic = levelData.starLogic;

        playData = FindObjectOfType<GPData> ();

        playerPict.sprite = playData.GetPlayerSprite_UI ();

        InitialQuestion ();
    }

    public void InitialQuestion () {
        QuestionObj.enabled = true;
        nextButton.onClick.RemoveAllListeners ();
        nextButton.gameObject.SetActive (true);
        npcPict.sprite = playData.GetNPCSprite_UI ();

        if (curDialognumber < dialogs.Count) {

            if (dialogs[curDialognumber].nextTake > 0) {
                FindObjectOfType<ActionHandle> ().NextTake (dialogs[curDialognumber].nextTake);
            }

            bool forPlayer = dialogs[curDialognumber].forPlayer;
            bool isOpenIlust = dialogs[curDialognumber].openIlustration;
            bool choiceOn = dialogs[curDialognumber].loadChoice;

            //Set NPC Color
            if (forPlayer) {
                playerPict.color = Color.white;
                npcPict.color = new Color32 (90, 90, 90, 255);
            } else {
                playerPict.color = new Color32 (90, 90, 90, 255);
                npcPict.color = Color.white;
            }

            //Set Illustration
            Color result;
            ilust.SetActive (isOpenIlust);
            if (isOpenIlust) {
                ilusPlace.sprite = dialogs[curDialognumber].ilustImage;
                ColorUtility.TryParseHtmlString ("#FFFFFF", out result);
                result.a = 1;
            } else {
                ilusPlace.sprite = null;
                ColorUtility.TryParseHtmlString ("#636363", out result);
                result.a = 0.4f;
            }
            ilusPlace.color = result;

            //Set ChoiceBtn
            choiceUI.SetActive (choiceOn);
            questionBox.SetActive (choiceOn);
            if (choiceOn) {
                upDialog.transform.localPosition = Vector3.zero;
                upDialog.text = dialogs[curDialognumber].dialogText;
                choiceUI.GetComponent<ChoiceUIMan> ().Initial (GetChoice (dialogs[curDialognumber].choiceID));
                btmDialog.text = "";

                playerPict.enabled = false;
                npcPict.enabled = false;

                //Set Main Question
                mainQuestion.text = GetChoice (dialogs[curDialognumber].choiceID).qustionText.ToUpper ();
            } else {
                // Set Dialogtext
                btmDialog.text = dialogs[curDialognumber].dialogText;
                playerPict.enabled = true;
                npcPict.enabled = true;
            }

            //Set NextClick Status
            if (dialogs[curDialognumber].canNext) {
                nextButton.onClick.AddListener (delegate { InitialQuestion (); });
            } else if (!dialogs[curDialognumber].canNext) {
                nextButton.gameObject.SetActive (false);
            }

            //Set Question UI
            if (!dialogs[curDialognumber].minimize) {
                QuestionObj.enabled = true;
            } else {
                QuestionObj.enabled = false;
            }
            curDialognumber++;
        } else {
            playerPict.sprite = null;
            npcPict.sprite = null;
            QuestionObj.GetComponent<Canvas> ().enabled = false;

            //Load Pengayaan
            pengayaanUI.SetActive (true);
            foreach (var item in textPengayaan) {
                pengayaanUI.GetComponent<Pengayaan> ().CreatePengayaan (item);
            }
            print ("Dialog Close");
            FindObjectOfType<QuestionUIHandler> ().SetStar (starLogic, out int star);

            ScoreCounter sc = FindObjectOfType<ScoreCounter> ();
            BaseData baseData = FindObjectOfType<BaseData> ();

            baseData.AddScoreToLevel (playData.levelLoad, sc.curScore, star);
            baseData.SaveData ();
            //sc.curScore = 0;
        }
    }
    Choice GetChoice (int id) {
        if (choices != null) {
            foreach (var item in choices) {
                if (item.ID == id) {
                    return item;
                }
            }
            return null;
        } else {
            return null;
        }
    }
}