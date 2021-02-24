using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Petunjuk : MonoBehaviour {
    float contentSize;
    float scroll_pos;
    float[] pos;
    float itemSize;
    [SerializeField] int curPos;
    bool isManual;
    RectTransform content_rect;
    public GameObject content;
    public Text mainText;
    //
    [Header ("Data")]
    public string[] data;

    private void Start () {
        curPos = 0;
        content_rect = content.GetComponent<RectTransform> ();

        itemSize = content.transform.GetChild (0).GetComponent<RectTransform> ().sizeDelta.x + content.GetComponent<HorizontalLayoutGroup> ().spacing; //size + spacing

        pos = new float[content.transform.childCount];
        for (int i = 0; i < pos.Length; i++) {
            pos[i] = itemSize * i * -1;
        }
    }
    void Update () {
        contentSize = content_rect.sizeDelta.x;
        if (Input.GetMouseButton (0)) {
            scroll_pos = content_rect.anchoredPosition.x;
        } else if (!isManual) {
            for (int i = 0; i < pos.Length; i++) {
                if (scroll_pos < pos[i] + (itemSize / 2) && scroll_pos > pos[i] - (itemSize / 2)) {
                    content_rect.anchoredPosition = new Vector2 (pos[i], content_rect.anchoredPosition.y); // new Vector2 (
                    // Mathf.Lerp (content_rect.anchoredPosition.x, pos[i], 1f), 0);
                    curPos = i;
                    mainText.text = data[curPos];
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

    public void GetContent (bool isNext) {
        if (isNext && curPos + 1 < pos.Length) {
            Debug.LogWarning ("here");
            content_rect.anchoredPosition = new Vector2 (pos[curPos + 1], content_rect.anchoredPosition.y);
            scroll_pos = pos[curPos + 1];
            curPos++;
        } else if (!isNext && curPos - 1 >= 0) {
            content_rect.anchoredPosition = new Vector2 (pos[curPos - 1], content_rect.anchoredPosition.y);
            scroll_pos = pos[curPos - 1];
            curPos--;
        }
        isManual = true;

        StartCoroutine (SetManualNormal ());
    }
    public IEnumerator SetManualNormal () {
        yield return new WaitForSeconds (0.2f);
        isManual = false;

    }
}