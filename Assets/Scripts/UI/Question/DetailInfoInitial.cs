using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailInfoInitial : MonoBehaviour {

    public TextMeshProUGUI infoText;

    [SerializeField]int curOpenIndex;
    public List<DeatailInfo> detailList = new List<DeatailInfo> ();

    public void OpenInfo (int index) {
        infoText.text = detailList[index].infoText;
    }

    public void Open_NPInfo (int increment) {
        if (increment > 0 && curOpenIndex + increment < detailList.Count) {
            OpenInfo (curOpenIndex + increment);
            curOpenIndex = curOpenIndex + increment;
        } else if (increment < 0 && curOpenIndex - 1 >= 0) {
            print(curOpenIndex + increment);
            OpenInfo (curOpenIndex + increment);
            curOpenIndex = curOpenIndex + increment;

        }
    }
}

[System.Serializable]
public class DeatailInfo {
    [TextArea]
    public string infoText;
}