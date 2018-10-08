using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShoot : MonoBehaviour {
    public int pathIndex;
    public List<Monster> enemiesInRanges=new List<Monster>();
    private float lastShotTime;
    private float shotInterval=1f;//几秒开火一次
    private GameObject bulletPrefab;
    private Vector3 orginScale = new Vector3(1, 1, 1);

    //进入范围开始射击
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogError("OnTriggerEnter2D");
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Monster monster= other.gameObject.GetComponent<MonsterMove>().monster;
            enemiesInRanges.Add(monster);
        }
    }

    //离开范围的不射击
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.LogError("OnTriggerExit2D");
        if (other.gameObject.tag.Equals("Enemy"))
        {
            Monster monster = other.gameObject.GetComponent<MonsterMove>().monster;
            enemiesInRanges.Add(monster);
        }
    }
    void Awake()
    {
         bulletPrefab = (GameObject)Resources.Load("Prefabs/bullet");
    }

    // Use this for initialization
    void Start ()
    {
        lastShotTime = Time.time;
    }
    void Shoot(Monster target)
    {
        GameObject targetGo = target.go;
        Vector3 startPosition = gameObject.transform.position;
        Vector3 targetPosition = targetGo.transform.position;
        //startPosition.z = bulletPrefab.transform.position.z;
        //targetPosition.z = bulletPrefab.transform.position.z;

        GameObject newBullet = (GameObject)Instantiate(bulletPrefab);
        newBullet.transform.parent = transform;
        newBullet.transform.localScale = orginScale;
        newBullet.transform.position = startPosition;
        BulletBehaviour bulletComp = newBullet.GetComponent<BulletBehaviour>();
        bulletComp.target = target;
        bulletComp.startPosition = startPosition;
        bulletComp.targetPosition = targetPosition;
        bulletComp.towerShoot = this;
        /*音效
        Animator animator = monsterData.CurrentLevel.visualization.GetComponent<Animator>();
        animator.SetTrigger("fireShot");
        AudioSource audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioSource.clip);
        */
    }
    // Update is called once per frame
    void Update () {
        Monster target = null;
        int minimalEnemyDistance = int.MaxValue;
        foreach (Monster enemy in enemiesInRanges)
        {
            int distanceToGoal = enemy.moveController.currentPointIndex;
            if (distanceToGoal < minimalEnemyDistance)
            {
                target = enemy;
                minimalEnemyDistance = distanceToGoal;
            }
        }
        if (target != null)
        {
            if (Time.time - lastShotTime > shotInterval)
            {
                Shoot(target);
                lastShotTime = Time.time;
            }
            //Vector3 direction = gameObject.transform.position - target.transform.position;
            //gameObject.transform.rotation = Quaternion.AngleAxis(
            //    Mathf.Atan2(direction.y, direction.x) * 180 / Mathf.PI,
            //    new Vector3(0, 0, 1));
        }
    }
    public void OnEnemyDestroy(Monster enemy)
    {
        enemiesInRanges.Remove(enemy);
    }
}

