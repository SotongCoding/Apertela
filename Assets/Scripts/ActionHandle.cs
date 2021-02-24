using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionHandle : MonoBehaviour {
    GPData data;
    AnimationHandle handle;
    public int animIndex;
    private void Awake () {
        data = FindObjectOfType<GPData> ();
        handle = FindObjectOfType<AnimationHandle> ();
        NextTake (1);
    }
    public void SetNPCPict (string name) {
        data.SetNPCSprites_UI (GetSpriteUI (name));
    }
    Sprite GetSpriteUI (string name) {
        return Resources.Load<Sprite> ("UI/Gameplay/CharChat/" + name);
    }

    public void LoadQuestion_First () {
        SceneManager.LoadScene ("QuestionAndInfo", LoadSceneMode.Additive);
    }
    public void MaximizeQuestion () {
        QuestionInitializer ques = FindObjectOfType<QuestionInitializer> ();
        ques.QuestionObj.enabled = true;
        ques.npcPict.sprite = data.GetNPCSprite_UI();
    }
    public void NextTake (int take) {
        handle.SetTakeNumber (take);
    }

    public void ParalaxON (int isOn) {
        if (isOn == 1) {
            FindObjectOfType<ParalaxEffect> ().enabled = true;
        } else if (isOn == 0) {
            FindObjectOfType<ParalaxEffect> ().enabled = false;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="object"> 0 = player, 1-dst = other</param>
    public void SetAnim (string animName) {
        FindObjectOfType<AnimationHandle> ().CallAnim (animIndex, animName);
    }

    public void EndGame () {
        ScoreCounter score = FindObjectOfType<ScoreCounter> ();
        GPData data = FindObjectOfType<GPData> ();

        Debug.LogWarning (score.curScore);
    }
}