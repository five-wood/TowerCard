using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MonsterCreator
{
    static public Monster Create(MonsterType type,GameObject go,int pathIndex)
    {
        Monster monster = null;
        switch (type)
        {
            case MonsterType.Base:
                monster = new Monster(go, pathIndex);
                break;
            default:
                break;
        }
        return monster;
    }
}
