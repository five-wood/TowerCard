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
    private GameObject go;

    public Monster(GameObject go,int pathIndex)
    {
        this.go = go;
        moveController = go.GetComponent<MonsterMove>();
        moveController.setSpeed(speed);
        moveController.setPath(pathIndex);
    }

    public void AddHp(float value) {
        hp += value;
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

    public void MulScale(float factor) {
        go.transform.localScale *= factor;
    }
}

public enum MonsterType
{
    Base = 0,
}

