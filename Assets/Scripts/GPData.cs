using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPData : MonoBehaviour {
    public static GPData instance;
    private void Awake () {
         if (instance == null) {
            DontDestroyOnLoad (gameObject);
            instance = this;
        } else if (instance != this) {
            Destroy (gameObject);
        }

        SetPlayerSprite_Play(0);
    }
    public int levelLoad;
    [SerializeField] Sprite playerSprite_UI, npcSprite_UI;
    [SerializeField] SpritePlay playerSprite_Play;
    public SpritePlay[] playerSprites_Play = new SpritePlay[2];
    public Sprite[] playerSprites_UI = new Sprite[2];

    public void SetPlayerSprite_UI (int index) {
        playerSprite_UI = playerSprites_UI[index];
    }
    public void SetPlayerSprite_Play (int index) {
        playerSprite_Play = playerSprites_Play[index];
    }
    public void SetNPCSprites_UI (Sprite source) {
        npcSprite_UI = source;
        
    }
    public Sprite GetPlayerSprite_UI () {
        return playerSprite_UI;
    }
    public SpritePlay GetPlayerSprite_Play(){
        return playerSprite_Play;
    }
    public Sprite GetNPCSprite_UI () {
        return npcSprite_UI;
    }
}

[System.Serializable]
public class SpritePlay{
    public Sprite kepala;
    public Sprite badan;

    public Sprite kkanan1,kkanan2;
    public Sprite kkiri1,kkiri2;

    public Sprite tkiri1,tkiri2;
    public Sprite tkanan1, tkanan2;
}