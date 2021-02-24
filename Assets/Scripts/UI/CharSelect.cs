using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour {

    GPData data;
    private void Awake () {
        data = FindObjectOfType<GPData> ();
    }
    // Start is called before the first frame update
    public void SelectChar (int code) {
        data.SetPlayerSprite_UI (code);
        data.SetPlayerSprite_Play (code);
    }
}