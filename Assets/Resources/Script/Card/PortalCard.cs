using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// 传送门
/// </summary>
public class PortalCard : Card {
    public PortalCard() {
        id = 1001;
        cost = 1;
        name = "传送门";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "产生一个传送裂缝把目标区域的怪物传送到箭头指向的玩家的路径上";
        existTime = 3;
    }

    public override void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }

    public override void Finish(int srcPlayerId = -1,int tagetId = -1,ArrayList param = null) {
    }
}
