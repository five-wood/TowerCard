using System;
using System.Collections.Generic;
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
        desc = "提升防御塔等级，增强属性";
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,System.Collections.ArrayList param = null) {

    }
}
