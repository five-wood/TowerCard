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
                card = new PortalCard();
                break;
            case 1002:
                card = new StrengtheningTowerCard();
                break;
            case 1003:
                card = new StrengtheningAllTowerCard();
                break;
            case 1004:
                card = new OilCard();
                break;
            case 1005:
                card = new SnowstormCard();
                break;
            case 1006:
                card = new BarrierCard();
                break;
            case 1007:
                card = new HornCard();
                break;
            case 1008:
                card = new CrazyCard();
                break;
            case 1009:
                card = new HardeningCard();
                break;
            case 1010:
                card = new UpgradeCard();
                break;
            case 1011:
                card = new BlackCard();
                break;
            case 1012:
                card = new WhiteCard();
                break;
        }
        return card;
    }
}
