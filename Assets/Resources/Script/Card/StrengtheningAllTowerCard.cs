using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class StrengtheningAllTowerCard : Card {
    private int addHP = 10;

    public StrengtheningAllTowerCard() {
        id = 1003;
        cost = 1;
        name = "全体加固";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("ground");
        desc = "增加自己所有防御塔10点血";
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1, ArrayList param = null) {

    }
}
