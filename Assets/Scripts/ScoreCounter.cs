using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {
    // Start is called before the first frame update
    public int curScore;

    public void AddScore (int Value) {
        curScore += Value;
    }

    private void Start() {
        print(this.gameObject.name);
    }
}