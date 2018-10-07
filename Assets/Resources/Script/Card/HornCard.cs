using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HornCard : Card {
    public HornCard() {
        id = 1007;
        cost = 1;
        name = "号角";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "让其他玩家的道路出现精英怪";
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
