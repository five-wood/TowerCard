using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WhiteCard : Card {

    public WhiteCard() {
        id = 1011;
        cost = 1;
        name = "升级";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("palyerArea1");
        tagList.Add("palyerArea2");
        tagList.Add("palyerArea3");
        tagList.Add("palyerArea4");
        desc = "使某其他玩家的所有防御塔属性变为白色，5秒";
        existTime = 5;
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,System.Collections.ArrayList param = null) {

    }
}