using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect_UIInitial : MonoBehaviour {
    public Transform starpos;
    public void SetStarView (int amount) {
        Debug.Log(amount);
        
        for (int i = 0; i < starpos.childCount; i++) {
            if (i <= amount - 1) {
                starpos.transform.GetChild (i).GetChild (0).gameObject.SetActive (true);
                starpos.transform.GetChild (i).GetChild (1).gameObject.SetActive (false);
            } else {
                starpos.transform.GetChild (i).GetChild (0).gameObject.SetActive (false);
                starpos.transform.GetChild (i).GetChild (1).gameObject.SetActive (true);
            }

        }
    }
}