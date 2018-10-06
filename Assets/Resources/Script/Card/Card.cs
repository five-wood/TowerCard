using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Card  {
    public int id;
    public string bgUrl;
    public string cardUrl;
    public string desc;
    public int cost;
    public int state = 0;
    public GameObject go;
    public List<string> tagList;

    public const int CARD_STATE_ENABLED = 0;
    public const int CARD_STATE_DISABLED = 1;
    public const int CARD_STATE_INHAND = 2;

    public Card() {
        tagList = new List<string>();
        state = CARD_STATE_ENABLED;
    }

    public void Action(int srcPlayerId = -1,int targetId = -1) {

    }

    public bool IsHitTarget(string tag) {
        return tagList.Contains(tag);
    }

    public void InitGameObject(GameObject obj) {
        go = obj;
        var icon = go.transform.FindChild("Root/Icon").GetComponent<Image>();
        Sprite sprite = Resources.Load("Image/shandian01", typeof(Sprite)) as Sprite;
        icon.sprite = sprite;

    }
}
