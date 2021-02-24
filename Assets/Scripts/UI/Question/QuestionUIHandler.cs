using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionUIHandler : MonoBehaviour {
    public GameObject quitNotice;
    public GameObject noticeBox;

    public GameObject benar_banner, salah_banner;
    public Image[] star;
    public Sprite[] starSprite;

    public void QuitApprove (bool isQuit) {
        if (isQuit) {
            SceneManager.LoadScene (0, LoadSceneMode.Single);
            SoundControl.PlayBGM (bgm_sound.menu);
        } else {
            QuitNotice (false);
        }
    }

    public void ShowBenarSalah (bool isBenar) {
        noticeBox.SetActive (true);
        if (isBenar) {
            benar_banner.SetActive (true);
            salah_banner.SetActive (false);
        } else {
            benar_banner.SetActive (false);
            salah_banner.SetActive (true);
        }

        StartCoroutine (CloseSalahBenarBanner ());
    }

    IEnumerator CloseSalahBenarBanner () {
        yield return new WaitForSeconds (2f);
        noticeBox.SetActive (false);
        benar_banner.SetActive (false);
        salah_banner.SetActive (false);
    }

    public void QuitNotice (bool isOn) {
        if (isOn) {
            noticeBox.SetActive (true);
            quitNotice.SetActive (isOn);
        } else {
            noticeBox.SetActive (false);
            quitNotice.SetActive (false);
        }
    }

    public void RestartLevel () {
        SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
    }

    public void SetStar (int[] starStat, out int getStar) {
        getStar = 0;
        int score = FindObjectOfType<ScoreCounter> ().curScore;
        for (int i = 0; i < 3; i++) {
            star[i].sprite = score >= starStat[i] ? starSprite[1] : starSprite[0];
            if (score >= starStat[i]) {
                getStar++;
            }
        }

    }
}