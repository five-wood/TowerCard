using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int id;
    public List<Card> cardList;
    public int[] curCardPosList;
    public GameObject cardPrefab;
    private Transform root;
    public Base myBase;
    public List<Tower> towerList;

    public void Awake() {
        cardList = new List<Card>();
        curCardPosList = new int[5];
    }

    public void InitCardList() {
        for(int i = 0; i < 15; i++) {
            int randId = i + 1001;
            if(i >= 12) {
                randId = Random.Range(1,13) + 1000;
            }
            randId = 1008;
            Card card = CardMgr.ins.createCard(randId);
            card.pos = i;
            cardList.Add(card);
        }
    }

    public void InitHandCard(Transform parent) {
        root = parent;

        for(int i = 0; i < 5; i++) {
            int randomPos = 0;
            while(true) {
                randomPos = Random.Range(0,cardList.Count);
                if(cardList[randomPos].state == Card.CARD_STATE_ENABLED) {
                    break;
                }
            }
            curCardPosList[i]=randomPos;
            cardList[randomPos].state = Card.CARD_STATE_INHAND;
            GameObject go = Instantiate(cardPrefab,root);
            go.name = i.ToString();
            cardList[randomPos].InitGameObject(go);
        }
    }

    public void GetNewCard() {
        int randPos = 0;
        while(true) {
            randPos = Random.Range(0,cardList.Count);
            if(cardList[randPos].state == Card.CARD_STATE_ENABLED) {
                break;
            }
        }

        for(int i = 0; i < 5; i++) {
            if(curCardPosList[i] == -1) {
                curCardPosList[i] = randPos;
                break;
            }
        }
        cardList[randPos].state = Card.CARD_STATE_INHAND;
        GameObject go = Instantiate(cardPrefab,root);
        
        cardList[randPos].InitGameObject(go);
    }

    public void RemoveHandCard(Card card) {

        DestroyImmediate(card.go);
        card.go = null;
        card.state = Card.CARD_STATE_DISABLED;
        for(int i = 0; i < 5; i++) {
            if(curCardPosList[i] == card.pos) {
                curCardPosList[i] = -1;
                break;
            }
        }
    }

    public Card GetHandCard(int pos) {
        return cardList[curCardPosList[pos]];
    }
}
