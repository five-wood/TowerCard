using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CrazyCard : Card {
    public float speedFactor = 1.5f;
    public float damageFactor = 1.5f;

    public CrazyCard() {
        id = 1008;
        cost = 1;
        name = "狂化";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "狂化某一玩家道路的区域的怪物。增加移动速度和伤害";
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
