using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

    public CharSelect charSelect;
    public LevelSelect levelSelect;
    public Petunjuk petunjuk;
    public Materi materi;

    public GameObject quitPopUp;

    /// <summary>
    /// 1- Char 2-Level 3-Petunjuk
    /// </summary>
    /// <param name="menu"></param>
    public void OpenMenu (int menu) {
        if (menu == 1) {
            charSelect.gameObject.SetActive (true);

            levelSelect.gameObject.SetActive (false);
            petunjuk.gameObject.SetActive (false);
            materi.gameObject.SetActive (false);
        } else if (menu == 2) {
            levelSelect.gameObject.SetActive (true);

            charSelect.gameObject.SetActive (false);
            petunjuk.gameObject.SetActive (false);
            materi.gameObject.SetActive (false);

        } else if (menu == 3) {
            petunjuk.gameObject.SetActive (true);

            levelSelect.gameObject.SetActive (false);
            charSelect.gameObject.SetActive (false);
            materi.gameObject.SetActive (false);

        } else if (menu == 4) {
            materi.gameObject.SetActive (true);

            levelSelect.gameObject.SetActive (false);
            charSelect.gameObject.SetActive (false);
            petunjuk.gameObject.SetActive (false);
        }
    }

    public void Kembali () {
        charSelect.gameObject.SetActive (false);
        levelSelect.gameObject.SetActive (false);
        petunjuk.gameObject.SetActive (false);
        materi.gameObject.SetActive (false);
    }

    public void QuitPopUp (bool isActive) {
        quitPopUp.SetActive (isActive);
        Application.Quit ();
    }

    public void QuitApproval (bool approval) {
        if (!approval) {
            QuitPopUp (false);
        } else {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else 
            Application.Quit ();

#endif

        }
    }
}