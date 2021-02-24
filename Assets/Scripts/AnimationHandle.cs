using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
public class AnimationHandle : MonoBehaviour {
    //Testing Commit
    [SerializeField] Animator[] obj;

    public int curTake = 0;

    void SetTake () {
        foreach (var item in obj) {
            item.SetInteger ("toTake", curTake);
        }
    }

    public void SetTakeNumber (int takeNumber) {
        curTake = takeNumber;
        SetTake ();
    }
    public void CallAnim (int index, string animName) {
        obj[index].transform.GetChild (0).GetComponent<Animator> ().SetBool (animName, true);

        StartCoroutine (backFalse (index, animName));
    }

    IEnumerator backFalse (int index, string animName) {
        yield return new WaitForSeconds (0.3f);
        obj[index].transform.GetChild (0).GetComponent<Animator> ().SetBool (animName, false);

    }
}