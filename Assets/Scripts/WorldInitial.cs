using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WorldInitial : MonoBehaviour {
    public SpriteRenderer kepala;
    public SpriteRenderer badan;

    public SpriteRenderer kkanan1, kkanan2;
    public SpriteRenderer kkiri1, kkiri2;

    public SpriteRenderer tkiri1, tkiri2;
    public SpriteRenderer tkanan1, tkanan2;
    GPData data;
    public GameObject quitUI;
    // Start is called before the first frame update
    private void Awake () {
        data = FindObjectOfType<GPData> ();
        SetCharaSprite (data.GetPlayerSprite_Play());
    }

    void SetCharaSprite (SpritePlay sprites) {
        kepala.sprite = sprites.kepala;
        badan.sprite = sprites.badan;

        kkanan1.sprite = sprites.kkanan1;
        kkanan2.sprite = sprites.kkanan2;
        kkiri1.sprite = sprites.kkiri1;
        kkiri2.sprite = sprites.kkiri2;

        tkanan1.sprite = sprites.tkanan1;
        tkanan2.sprite = sprites.tkanan2;
        tkiri1.sprite = sprites.tkiri1;
        tkiri2.sprite = sprites.tkiri2;
    }
    public void OpenQuitUI () {
        if (quitUI.activeSelf) {
            quitUI.SetActive (false);
            Time.timeScale = 1;
        } else {
            quitUI.SetActive (true);
            Time.timeScale = 0;
        }
    }
    public void QuitApproval (bool isQuit) {
        if (isQuit) {
            SceneManager.LoadScene (0, LoadSceneMode.Single);
            SoundControl.PlayBGM (bgm_sound.menu);
        } else {
            quitUI.SetActive (false);

        }
        Time.timeScale = 1;
    }
}