using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Tower : Base {
    public float damage = 10;   // 炮弹伤害
    public float distance = 10; // 射击范围
    public float range = 0;     // 炮弹爆炸范围，为0时为单体伤害
    public float speed = 2;     // 攻击速度
    public int level = 1;       // 防御塔等级

    public int type = 0;
    public const int TOWER_TYPE_GUN = 0;
    public const int TOWER_TYPE_ARROW = 1;
    public const int TOWER_TYPE_MAGGIC = 2;

    public int attr = 0;
    public const int TOWER_ATTR_NONE = 0;
    public const int TOWER_ATTR_BLACK = 1;
    public const int TOWER_ATTR_WHITE = 2;

    public Tower() {
        hp = 30;
    }

    public void Upgrade() {
        level++;
        damage = damage * level * 1.5f;
        distance = distance * level * 1.5f;
    }
}
