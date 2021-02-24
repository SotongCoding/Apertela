using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour {

    public AudioSource bgm, sfx;

    public AudioClip[] bgm_clips;
    public AudioClip[] sfx_clips;
    static SoundControl instance;

    bool bgmVal, sfxVal;

    private void Awake () {
        if (instance == null) {
            DontDestroyOnLoad (gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy (gameObject);
        }
        bgm.volume = 0.3f;
        bgmVal = sfxVal = true;
    }
    public static void PlaySfx (sfx_sound sound) {
        instance.sfx.PlayOneShot (instance.sfx_clips[(int) sound]);
    }
    public static void PlayBGM (bgm_sound sound) {
        instance.bgm.clip = instance.bgm_clips[(int) sound];
        instance.bgm.Play ();
    }

    public void TrunBGM (Image bttn) {
        bgmVal = !bgmVal;
        if (bgmVal) {
            bttn.color = Color.blue;
            bgm.UnPause ();
        } else {
            bttn.color = Color.black;
            bgm.Pause ();
        }
    }
    public void TrunSFX (Image bttn) {
        sfxVal = !sfxVal;
        if (sfxVal) {
            sfx.UnPause ();
            bttn.color = Color.red;
        } else {
            bttn.color = Color.black;
            sfx.Pause ();
        }
    }
}

public enum sfx_sound {
    true_answer,
    false_answer
}
public enum bgm_sound {
    menu,
    l1_l4,
    l5_l8,
    l9_l10
}