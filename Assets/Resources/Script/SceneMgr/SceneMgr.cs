using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour {
    public int monsterNumPer=3;  //每条路每一波的怪物数量
    public int perIntervalTime = 20;  //每条路每一波的怪物数量
    public int pathNum=4; //路径数量
    public float genSpeed = 6; //每条路几秒成一个怪物
    private Dictionary<int, List<Monster>> allMonstersDict = new Dictionary<int, List<Monster>>();
    private GameObject allMonstersGo;
    private GameObject MPrefabGo;
    private Vector3 monsterOriginScale=new Vector3(1,1,1);
    void Awake()
    {
        //Debug.LogError("SceneMgr Awake");
        allMonstersGo =transform.FindChild("Base/BossBase/allMonsters").gameObject;
        MPrefabGo = (GameObject)Resources.Load("Prefabs/monster");
    }

    private IEnumerator CreatePerMonster()
    {
        while (true)
        {
            for (int j = 0; j < monsterNumPer; j++)
            {
                for (int i = 0; i < pathNum; i++)
                {
                    Transform parent = allMonstersGo.transform.GetChild(i);
                    GameObject monsterGo = Instantiate(MPrefabGo);
                    RectTransform rect = monsterGo.GetComponent<RectTransform>();
                    //Debug.LogError("monsterGo.transform.localScale: " + monsterGo.transform.localScale);
                    monsterGo.transform.SetParent(parent);
                    monsterGo.transform.localScale = monsterOriginScale;
                    Monster monster = MonsterCreator.Create(MonsterType.Base, monsterGo, i);
                    if (!allMonstersDict.ContainsKey(i))
                        allMonstersDict.Add(i, new List<Monster>());
                    allMonstersDict[i].Add(monster);
                }
                yield return new WaitForSeconds(genSpeed);
            }
            yield return new WaitForSeconds(perIntervalTime);
        } 
    }

	// Use this for initialization
	void Start () {
        StartCoroutine(CreatePerMonster());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
