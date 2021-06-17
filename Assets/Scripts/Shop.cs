using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
using System;

public class Shop : MonoBehaviour
{
    public static Shop instance;

    int numberCountItem;

    [SerializeField]
    Transform content;

    [SerializeField]
    Scrollbar scrollbar;

    [SerializeField]
    GameObject rowPrefabs;

    public TextAsset shopJson;

    [Serializable]
    public class itemOb
    {
        public int id;
        public string icon;
        public string name;
        public string describe;
        public int price;
    }

    public List<itemOb> items;

    public GameObject buyPanel;
    public Text nameBuy;
    public Image iconBuy;
    public Text describeBuy;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }
        instance = this;

        numberCountItem = 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        JSONNode root = JSON.Parse(shopJson.text);
        JSONArray itemsArray = root["items"].AsArray;

        for (int i = 0; i < itemsArray.Count; i++)
        {
            items.Add(new itemOb());
            items[i].id = itemsArray[i]["id"];
            items[i].icon = itemsArray[i]["icon"];
            items[i].name = itemsArray[i]["title"];
            items[i].describe = itemsArray[i]["desc"];
            items[i].price = itemsArray[i]["price"];
        }


        for (int i = 0; i < itemsArray.Count / 3; i++)
        {
            GameObject rowOb = Instantiate(rowPrefabs, content);
            for (int j = 1; j < rowOb.transform.childCount; j++)
            {
                rowOb.transform.GetChild(j).GetComponent<Item>().icon = items[numberCountItem].icon;
                rowOb.transform.GetChild(j).GetComponent<Item>().name = items[numberCountItem].name;
                rowOb.transform.GetChild(j).GetComponent<Item>().describe = items[numberCountItem].describe;
                rowOb.transform.GetChild(j).GetComponent<Item>().price = items[numberCountItem].price;
                rowOb.transform.GetChild(j).GetComponent<Item>().setItem();
                numberCountItem++;
            }
        }

        scrollbar.value = 1;
    }

    public void ShowsItem(string na, Sprite ic, string des)
    {
        buyPanel.SetActive(true);
        nameBuy.text = na;
        iconBuy.sprite = ic;
        describeBuy.text = des;
    }

}
