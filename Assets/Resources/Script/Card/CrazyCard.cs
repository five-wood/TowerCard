using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CrazyCard : Card {
    public float speedFactor = 2f;
    public float damageFactor = 2f;
    public float scaleFactor = 1.5f;
    public int target = -1;
    public bool isUse = false;

    public CrazyCard() {
        id = 1008;
        name = "狂化";
        state = CARD_STATE_ENABLED;
        tagList = new List<string>();
        tagList.Add("path1");
        tagList.Add("path2");
        tagList.Add("path3");
        tagList.Add("path0");
        desc = "狂化某一玩家道路的区域的怪物。增加移动速度和伤害";
        existTime = 5;
    }

    public override void Action(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {
        if(!isUse) {
            SceneMgr.ins.UpdateMonsterSpeed(targetId,speedFactor);
            SceneMgr.ins.UpdateMonsterAttack(targetId,damageFactor);
            SceneMgr.ins.UpdateMonsterScale(targetId,scaleFactor);
            SceneMgr.ins.AddCardEffectDelegate(UpdateMonsterAttr);
            target = targetId;
            isUse = true;
        }
    }

    public override void Finish(int srcPlayerId = -1,int targetId = -1,ArrayList param = null) {
        SceneMgr.ins.UpdateMonsterSpeed(targetId,1/speedFactor);
        SceneMgr.ins.UpdateMonsterAttack(targetId,1/damageFactor);
        SceneMgr.ins.UpdateMonsterScale(targetId,1/ scaleFactor);
        SceneMgr.ins.RemoveCardEffectDelegate(UpdateMonsterAttr);
        isUse = false;
    }

    public void UpdateMonsterAttr(int pathNum,Monster monster) {
        if(pathNum == target) {
            monster.MulAttackFactor(damageFactor);
            monster.MulSpeedFactor(speedFactor);
            monster.MulScale(scaleFactor);
        }
    }
}
