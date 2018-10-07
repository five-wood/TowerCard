using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMgr : MonoBehaviour {
    public List<Player> playerList;
    public Transform cardArea;
    public List<SCardAction> cardActionList;
    public List<int> removeCardActionIdList;
    private static GameMgr _instance;

    public Slider energySlider;
    public Text energyText;
    public int energy;
    public float energyTimeSpan = 5;
    public float curTime = 0;

    void Awake() {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
        cardActionList = new List<SCardAction>();
        removeCardActionIdList = new List<int>();
        InitPlayers();

    }

    // Update is called once per frame
    void Update () {
        curTime += Time.deltaTime;
        if(curTime > energyTimeSpan) {
            UpdateEnergy(energy + 1);
            curTime = 0;
        }

        removeCardActionIdList.Clear();
        for(int i = 0; i < cardActionList.Count; i++) {
            int srcId = cardActionList[i].srcId;
            int tarId = cardActionList[i].targetId;
            ArrayList parm = cardActionList[i].paramList;
            cardActionList[i].card.Action(srcId,tarId,parm);
            cardActionList[i].curTime += Time.deltaTime;

            // 卡片效果结束
            if(cardActionList[i].curTime >= cardActionList[i].card.existTime) {
                cardActionList[i].card.Finish(srcId,tarId,parm);
                playerList[i].RemoveHandCard(cardActionList[i].card);
                removeCardActionIdList.Add(i);
            }
        }

        for(int i = 0; i < removeCardActionIdList.Count; i++) {
            cardActionList.RemoveAt(removeCardActionIdList[i]);
        }
	}

    private void InitPlayers() {
        for(int i = 0; i < 4; i++) {
            playerList[i].InitCardList();
            if(i == 0) {
                playerList[i].InitHandCard(cardArea);
            }
        }
    }

    public void UseCard(Card card,int srcId,int targetId,ArrayList param) {
        SCardAction action = new SCardAction();
        action.card = card;
        action.targetId = targetId;
        action.srcId = srcId;
        action.paramList = param;
        action.curTime = 0;
        cardActionList.Add(action);
    }

    public static GameMgr ins {
        get {
            return _instance;
        }
    }

    public void UpdateEnergy(int value) {
        if(energy >= 10) {
            return;
        }
        energy = value;
        energySlider.value = energy / 10.0f;
        energyText.text = energy.ToString();
    }
}
