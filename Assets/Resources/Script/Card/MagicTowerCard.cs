using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MagicTowerCard : Card {
    public MagicTowerCard() {
        id = 10013;
        name = "箭塔";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("tower0");
        tagList.Add("tower1");
        tagList.Add("tower2");
        tagList.Add("tower3");
    }


    public override void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {
    }


    public override void Finish(int srcPlayerId = -1,int tagetId = -1,ArrayList param = null) {
    }

}
