﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BarrierCard : Card {
    public BarrierCard() {
        id = 1006;
        cost = 1;
        name = "屏障";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path4");
        desc = "设置一道屏障。持续8秒";
        existTime = 8;
    }

    public new void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {

    }
}
