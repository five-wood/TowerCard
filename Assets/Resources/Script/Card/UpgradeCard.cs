using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;

public class UpgradeCard : Card {
    public float healthAdd = 10;

    public UpgradeCard() {
        id = 1010;
        cost = 1;
        name = "升级";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("tower1");
        tagList.Add("tower2");
        tagList.Add("tower3");
        tagList.Add("tower0");
        desc = "提升防御塔等级，增强属性";
    }

    public override void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }

    public override void Finish(int srcPlayerId = -1,int tagetId = -1,ArrayList param = null) {
    }
}
