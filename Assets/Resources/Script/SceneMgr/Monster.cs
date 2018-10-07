using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Monster
{
    private float attack = 1;
    private float speed = 0.21f;
    private float hp = 100;
    private MonsterMove moveController;

    public Monster(GameObject go,int pathIndex)
    {
        moveController = go.GetComponent<MonsterMove>();
        moveController.setSpeed(speed);
        moveController.setPath(pathIndex);
    }

    public void SetSpeed(float s = 0.21f) {
        speed = s;
        moveController.setSpeed(speed);
    }

    public void SetAttack(float a = 1.0f) {
        attack = a;
    }

    public void MulSpeedFactor(float factor) {
        speed *= factor;
        moveController.setSpeed(speed);
    }

    public void MulAttackFactor(float factor) {
        attack *= factor;
    }
}

public enum MonsterType
{
    Base = 0,
}

