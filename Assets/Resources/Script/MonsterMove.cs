/*
author:lin
date:2018-10-03
*/
using UnityEngine;
using System.Collections;
using System;

public class MonsterMove : MonoBehaviour
{
    public GameObject[] points;    //保存所有的路点
    public float speed = 0.21f;//移动速度

    private int currentPointIndex = 1;//记录下一个即将到达的路点
    private Quaternion quaternionZero = new Quaternion(0,0,0,0);
    private Vector3 direction = Vector3.zero;//移动方向 
    private int pathIndex = -1;

    /// <summary>
    /// 从1开始
    /// </summary>
    /// <param name="pathIndex"></param>
    public void setPath(int path)
    {
        if (path < 0)
            Debug.LogError("setPath 参数需要大于等于0");
        pathIndex = path;
        //获取所有的路点
        points = GameObject.FindGameObjectsWithTag("path" + pathIndex);
        //上面的方法获取到的路点在数组中保存的顺序是降序的，我们使用Sort重新排序  Sort默认是升序状态  我们也可以使用Reverse 反转数组  里面使用的Lambda表达式排序
        Array.Sort(points, (x, y) => { return x.name.CompareTo(y.name); });
        //设置游戏对象的起始位置
        transform.position = points[0].transform.position;
        //设置游戏对象的方向
        direction = GetDirection(transform.position, points[1].transform.position);
        //游戏对象方向的标准化
        transform.forward = direction.normalized;
    }

    // Use this for initialization
    void Start()
    {
        //Debug.LogError("MonsterMove Start");
        if(pathIndex==-1)
            setPath(0);     
    }

    // Update is called once per frame
    void Update()
    {
        //当游戏对象的位置距离目标点还有0.1m的时候
        if (Vector3.Distance(transform.position, points[currentPointIndex].transform.position) < 0.01f)
        {
            //设置目标点为游戏对象自身的位置
            transform.position = points[currentPointIndex].transform.position;
            //判断有没有下一个目标点
            if (currentPointIndex + 1 < points.Length)
            {
                currentPointIndex++;
            }
        }
        if (transform.position != points[points.Length - 1].transform.position)
        {   //玩家移动的方向
            direction = GetDirection(transform.position, points[currentPointIndex].transform.position);
            transform.forward = direction.normalized;
            transform.Translate(Vector3.forward * Time.deltaTime* speed);
            transform.localRotation = quaternionZero;
        }
        else
        {
        }
    }
    //得到一个实时的方向
    private Vector3 GetDirection(Vector3 v1, Vector3 v2)
    {
        return v2 - v1;
    }
}
 