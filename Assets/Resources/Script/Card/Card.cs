using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card  {
    public int id;
    public string cardUrl;
    public string desc;
    public int cost;
    public int state = 0;
    public string name;
    public GameObject go;
    public List<string> tagList;
    public float existTime = 0;

    public const int CARD_STATE_ENABLED = 0;
    public const int CARD_STATE_DISABLED = 1;
    public const int CARD_STATE_INHAND = 2;

    public Card() {
        tagList = new List<string>();
        state = CARD_STATE_ENABLED;
        name = "";
        cost = 0;
    }

    public void Action(int srcPlayerId = -1,int targetId = -1, ArrayList param = null) {
        
    }

    public void Finish(int srcPlayerId = -1,int tagetId = -1,ArrayList param = null) {

    }

    public bool IsHitTarget(string tag) {
        return tagList.Contains(tag);
    }

    public void InitGameObject(GameObject obj) {
        go = obj;
        var icon = go.transform.FindChild("Root/Icon").GetComponent<Image>();
        Sprite sprite = Resources.Load("Image/ui/shandian0", typeof(Sprite)) as Sprite;
        icon.sprite = sprite;

        var costTxt = go.transform.FindChild("Root/Cost/Text").GetComponent<Text>();
        costTxt.text = cost.ToString();

        var nameTxt = go.transform.FindChild("Root/Name").GetComponent<Text>();
        nameTxt.text = name;
    }
}
