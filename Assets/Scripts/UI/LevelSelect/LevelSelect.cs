using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour {
    public List<LevelData> level = new List<LevelData> ();
    public GameObject content;
    RectTransform content_rect;
    private float scroll_pos = 0;
    float[] pos;

    //Zone Size 
    float itemSize;
    float contentSize;

    public Text mainText;

    //
    BaseData baseData;
    // Start is called before the first frame update
    private void OnEnable () {
        if (!File.Exists (Application.dataPath + "/" + "levelDat.dat")) {
            baseData.SaveData ();
        }

        baseData.LoadData ();
        level = baseData.GetSaveData ();
        SetStarView ();
    }

    private void Awake () {
        if (baseData == null) {
            baseData = FindObjectOfType<BaseData> ();
        }
    }
    void Start () {
        content_rect = content.GetComponent<RectTransform> ();

        itemSize = content.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta.x + content.GetComponent<HorizontalLayoutGroup> ().spacing; //size + spacing

        pos = new float[content.transform.childCount];
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = itemSize * i * -1;
        }

    }

    // Update is called once per frame
    void Update () {
        contentSize = content_rect.sizeDelta.x;
        if (Input.GetMouseButton (0)) {
            scroll_pos = content_rect.anchoredPosition.x;
        } else {
            for (int i = 0; i < pos.Length; i++) {
                if (scroll_pos < pos[i] + (itemSize / 2) && scroll_pos > pos[i] - (itemSize / 2)) {
                    content_rect.anchoredPosition = new Vector2 (pos[i], content_rect.anchoredPosition.y); // new Vector2 (
                    // Mathf.Lerp (content_rect.anchoredPosition.x, pos[i], 1f), 0);
                    mainText.text = "Level " + (i + 1);
                }
            }
        }

        for (int i = 0; i < pos.Length; i++) {
            if (scroll_pos < pos[i] + (itemSize / 2) && scroll_pos > pos[i] - (itemSize / 2)) {
                content.transform.GetChild (i).localScale = Vector2.Lerp (content.transform.GetChild (i).localScale, new Vector2 (1.2f, 1.2f), 0.1f);
                for (int j = 0; j < pos.Length; j++) {
                    if (j != i) {
                        content.transform.GetChild (j).localScale = Vector2.Lerp (content.transform.GetChild (j).localScale, new Vector2 (0.8f, 0.8f), 0.1f);
                    }
                }
            }
        }

    }

    public void OpenLevel (int SelectLevel) {
        SceneManager.LoadScene ("Level-" + SelectLevel, LoadSceneMode.Single);
        FindObjectOfType<GPData> ().levelLoad = SelectLevel;
        if (SelectLevel >= 1 && SelectLevel <= 4) {
            SoundControl.PlayBGM (bgm_sound.l1_l4);
        } else if (SelectLevel >= 5 && SelectLevel <= 8) {
            SoundControl.PlayBGM (bgm_sound.l5_l8);
        } else if (SelectLevel >= 9 && SelectLevel <= 10) {
            SoundControl.PlayBGM (bgm_sound.l9_l10);
        }
    }

    void SetStarView () {
        foreach (LevelData item in level) {
            Transform levelTarget = content.transform.GetChild (level.IndexOf (item));
            //Set Level Open
            levelTarget.GetComponent<Button> ().interactable = item.isUnlock;
            //Set Star view
            levelTarget.GetComponent<LevelSelect_UIInitial> ().SetStarView (item.StarOpen ());
        }
    }

}