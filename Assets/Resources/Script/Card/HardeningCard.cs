using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class HardeningCard : Card {
    public float healthAdd = 10;

    public HardeningCard() {
        id = 1009;
        cost = 1;
        name = "硬化";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "为某一区域的怪物增加生命";
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
