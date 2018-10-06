using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public int id;
    public List<Card> cardList;
    public List<int> curCardPosList;
    public GameObject cardPrefab;
    private Transform root;

    public void Start() {
        cardList = new List<Card>();
        curCardPosList = new List<int>();
    }

    public void InitCardList() {
        for(int i = 0; i < 15; i++) {
            int randId = i + 1001;
            if(i >= 12) {
                randId = Random.Range(1,13) + 1000;
            }
            Card card = CardMgr.ins.createCard(randId);
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
            curCardPosList.Add(randomPos);
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
        
        curCardPosList.Add(randPos);
        cardList[randPos].state = Card.CARD_STATE_INHAND;
        GameObject go = Instantiate(cardPrefab,root);
        cardList[randPos].InitGameObject(go);
    }

    public void RemoveHandCard(Card card) {
        int pos = -1;
        for(int i = 0; i < curCardPosList.Count; i++) {
            if(cardList[curCardPosList[i]].id == card.id) {
                cardList[curCardPosList[i]].state = Card.CARD_STATE_DISABLED;
                pos = i;
            }
        }
        if(pos >= 0) {
            cardList.RemoveAt(pos);
        }
    }

    public Card GetHandCard(int pos) {
        return cardList[curCardPosList[pos]];
    }
}
