using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class StrengtheningTowerCard:Card {
    private int addHP = 25;
    public StrengtheningTowerCard() {
        id = 1002;
        cost = 1;
        name = "加固";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("tower1");
        desc = "增加目标防御塔生命25点";
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
