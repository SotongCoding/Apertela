using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    // Start is called before the first frame update
    public Transform player;

    private void Update () {
        this.transform.position =
            new Vector3 (player.position.x -0.3f,
                transform.position.y,-10);
    }
}