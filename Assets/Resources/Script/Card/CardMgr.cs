using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CardMgr: MonoBehaviour {
    private static CardMgr _instance;

    void Awake() {
        _instance = this;
    }

    public static CardMgr ins {
        get {
            return _instance;
        }
    }

    public Card createCard(int cardId) {
        Card card = null;
        switch(cardId) {
            case 1001:

                break;
            case 1002:

                break;
            case 1003:

                break;
            case 1004:

                break;
            case 1005:

                break;
            case 1006:

                break;
            case 1007:

                break;
            case 1008:
                break;

            case 1009:

                break;
            case 1010:

                break;
        }
        return card;
    }
}
