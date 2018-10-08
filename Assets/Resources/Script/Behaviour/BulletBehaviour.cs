using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class BulletBehaviour:MonoBehaviour
{
    public int damage=1;
    public float speed = 1;
    public Monster target;
    public Vector3 startPosition;
    public Vector3 targetPosition;
    public TowerShoot towerShoot;
    private float distance;
    private float startTime;
   
    void Start()
    {
        startTime = Time.time;
        distance = Vector3.Distance(startPosition, targetPosition);       
    }

    void Update()
    {
        float timeInterval = Time.time - startTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, targetPosition, timeInterval * speed / distance);

        if (gameObject.transform.position.Equals(targetPosition))
        {
            if (target != null)
            {
                //Transform healthBarTransform = target.transform.FindChild("HealthBar");
                //HealthBar healthBar = healthBarTransform.gameObject.GetComponent<HealthBar>();
                //healthBar.currentHealth -= Mathf.Max(damage, 0);
                //if (healthBar.currentHealth <= 0)
                {
                    DestoryMonster(target);                  
                   /*玩家分数增加
                   */
                }
            }
            Destroy(gameObject);
            towerShoot = null;
        }
    }

    private void DestoryMonster(Monster monster)
    {
        towerShoot.OnEnemyDestroy(monster);
        SceneMgr.ins.DestoryMonster(monster);        
    }
}

