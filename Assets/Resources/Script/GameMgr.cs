using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgr : MonoBehaviour {
    public List<Player> playerList;
    public Transform cardArea;
	// Use this for initialization
	void Start () {
        //InitPlayers();		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void InitPlayers() {
        for(int i = 0; i < 4; i++) {
            playerList[i].InitCardList();
            if(i == 0) {
                playerList[i].InitHandCard(cardArea);
            }
        }
    }
}
