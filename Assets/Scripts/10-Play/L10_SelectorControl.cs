using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L10_SelectorControl : MonoBehaviour
{
    public GameObject questionsUI;
    public L10_QuestionLoader questionLoader;
    
    public void OpenQuestion(int questionCode){
        questionLoader.Initialize(questionCode);
    }
}
