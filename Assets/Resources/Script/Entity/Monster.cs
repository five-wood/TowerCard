using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Monster: Base
{
    private float attack = 1;
    private float speed = 0.1f;
    private MonsterMove moveController;

    public Monster(GameObject go,int pathIndex)
    {
        moveController = go.GetComponent<MonsterMove>();
        moveController.setPath(pathIndex);
    }

}

public enum MonsterType
{
    Base = 0,
}

