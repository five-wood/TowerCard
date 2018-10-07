using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SnowstormCard : Card {
    public float speedDownFactor = 0.8f;
    public float damage = 3;
    public SnowstormCard() {
        id = 1005;
        cost = 1;
        name = "暴风雪";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "范围减速，造成伤害";
        existTime = 3;
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
