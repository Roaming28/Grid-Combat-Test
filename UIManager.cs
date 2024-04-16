using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    void Awake() {
        if(Instance == null) {
            Instance = this;
        } else {
            Destroy(this);
        }
    }

    public void PlayerMakeMove(Actor caller) {
        //Purpose is for player to select a move which will be returned to the player to make
        //Receive call from player controller fighter
        //Take their moveset
        //Separate it by types into move, attacks, skills
        //IEnumerator UI for player to select type
        //Player selects move
        //Move is returned to the caller for them to make
    }
}
