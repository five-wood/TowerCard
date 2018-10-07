using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BlackCard : Card {

    public BlackCard() {
        id = 1012;
        cost = 1;
        name = "升级";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("palyerArea1");
        tagList.Add("palyerArea2");
        tagList.Add("palyerArea3");
        tagList.Add("palyerArea4");
        desc = "使某其他玩家的所有防御塔属性变为黑色，5秒";
        existTime = 5;
    }

    public override void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }

    public override void Finish(int srcPlayerId = -1,int tagetId = -1,ArrayList param = null) {
    }
}
