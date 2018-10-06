using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OilCard:Card {
    public float damage = 5;
    public OilCard() {
        id = 1004;
        cost = 1;
        name = "滚油";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path4");
        desc = "在路径的一侧区域覆盖上滚油，持续造成伤害";
        existTime = 3;
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
