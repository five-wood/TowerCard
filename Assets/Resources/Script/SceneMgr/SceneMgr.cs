using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour {
    public int monsterNumPer=16;  //每条路每一波的怪物数量
    public int pathNum=4; //路径数量
    public float genSpeed = 1; //每条路几秒成一个怪物
    public float perIntervalTime = 20;//每一波间隔时间
    private Dictionary<int, List<Monster>> allMonstersDict = new Dictionary<int, List<Monster>>();
    private GameObject allMonstersGo;
    private GameObject MPrefabGo;
    private Vector3 monsterOriginScale=new Vector3(1,1,1);
    private static SceneMgr _instance;
    public delegate void CardEffectDelegate(int pathNum,Monster monster);
    private CardEffectDelegate _cardEffectDelegates;

    void Awake()
    {
        _instance = this;
        //Debug.LogError("SceneMgr Awake");
        allMonstersGo =transform.FindChild("Base/BossBase/allMonsters").gameObject;
        MPrefabGo = (GameObject)Resources.Load("Prefabs/monster");
    }

    private IEnumerator CreatePerMonster()
    {
        while(true)
        {
            for(int j = 0; j < monsterNumPer; j++) {
                for(int i = 0; i < pathNum; i++) {
                    Transform parent = allMonstersGo.transform.GetChild(i);
                    GameObject monsterGo = Instantiate(MPrefabGo);
                    RectTransform rect = monsterGo.GetComponent<RectTransform>();
                    //Debug.LogError("monsterGo.transform.localScale: " + monsterGo.transform.localScale);
                    monsterGo.transform.SetParent(parent);
                    monsterGo.transform.localScale = monsterOriginScale;
                    Monster monster = MonsterCreator.Create(MonsterType.Base,monsterGo,i);
                    if(_cardEffectDelegates != null) {
                        _cardEffectDelegates(i,monster);
                    }
                    if(!allMonstersDict.ContainsKey(i))
                        allMonstersDict.Add(i,new List<Monster>());
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
	
    public static SceneMgr ins {
        get {
            return _instance;
        }
    }

    public void UpdateMonsterSpeed(int path, float speedFactor) {
        if(!allMonstersDict.ContainsKey(path))
            return;

        for(int i = 0; i < allMonstersDict[path].Count; i++) {
            allMonstersDict[path][i].MulSpeedFactor(speedFactor);
        }
    }

    public void UpdateMonsterAttack(int path,float atkFactor) {
        if(!allMonstersDict.ContainsKey(path))
            return;

        for(int i = 0; i < allMonstersDict[path].Count; i++) {
            allMonstersDict[path][i].MulAttackFactor(atkFactor);
        }
    }

    public void UpdateMonsterScale(int path,float scaleFactor) {
        if(!allMonstersDict.ContainsKey(path))
            return;

        for(int i = 0; i < allMonstersDict[path].Count; i++) {
            allMonstersDict[path][i].MulScale(scaleFactor);
        }
    }

    public void AddMonsterHp(int path,float value) {
        if(!allMonstersDict.ContainsKey(path))
            return;

        for(int i = 0; i < allMonstersDict[path].Count; i++) {
            allMonstersDict[path][i].AddHp(value);
        }
    }


    public void AddCardEffectDelegate(CardEffectDelegate func) {
        if(_cardEffectDelegates == null) {
            _cardEffectDelegates = func;
        }
        else {
            _cardEffectDelegates += func;
        }
    }

    public void RemoveCardEffectDelegate(CardEffectDelegate func) {
        if(_cardEffectDelegates == null)
            return;
        _cardEffectDelegates -= func;
    }

}
