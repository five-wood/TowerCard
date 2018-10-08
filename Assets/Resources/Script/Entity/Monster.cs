using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Monster:Base
{
    private float attack = 1;
    private float speed = 0.21f;
    public MonsterMove moveController;
    public GameObject go;
    public Collider2D collider2D;
    public int path;

    public Monster(GameObject gameGo,int pathIndex,int monsterId)
    {
        go = gameGo;
        id = monsterId;
        path = pathIndex;
        //碰撞体
        collider2D = go.GetComponent<Collider2D>();
        //移动控制器
        moveController = go.GetComponent<MonsterMove>();
        if (moveController == null)
            moveController = go.AddComponent<MonsterMove>();
        moveController.monster = this;
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

    public void Destroy()
    {
        GameObject.Destroy(go);
        go = null;
        moveController = null;
        collider2D = null;
    }
}

public enum MonsterType
{
    Base = 0,
}

