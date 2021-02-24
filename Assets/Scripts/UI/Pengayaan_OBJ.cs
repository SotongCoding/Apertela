using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pengayaan_OBJ : MonoBehaviour {
    public TextMeshProUGUI textUI;
    public Text tittle;
    // Start is called before the first frame update
    public void Initialize (PengayaanData data) {
        textUI.text = data.text;
        this.tittle.text = data.tittle.ToUpper();
    }
}