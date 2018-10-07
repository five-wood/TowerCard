using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class OilCard:Card {
    public float speedFactor = 0.5f;
    public bool isUse = false;
    public int target = -1;
    public OilCard() {
        id = 1004;
        cost = 1;
        name = "滚油";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "在路径的一侧区域覆盖上滚油，持续造成伤害";
        existTime = 3;
    }

    public override void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {
        if(!isUse) {
            SceneMgr.ins.UpdateMonsterSpeed(targetId,speedFactor);
            target = targetId;
            SceneMgr.ins.AddCardEffectDelegate(UpdateMonsterAttr);
            isUse = true;
        }
    }

    public override void Finish(int srcPlayerId = -1,int tagetId = -1,ArrayList param = null) {
    }

    public void UpdateMonsterAttr(int pathNum,Monster monster) {
        if(pathNum == target) {
            monster.MulSpeedFactor(speedFactor);
        }
    }
}
