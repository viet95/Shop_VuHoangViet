using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    [HideInInspector]
    public string icon;
    [HideInInspector]
    public string name;
    [HideInInspector]
    public string describe;
    [HideInInspector]
    public int price;

    public Image iconImg;
    public Text nameTxt;
    public Text priceTxt;

    Button btn;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();

        btn.onClick.AddListener(click);
    }

    void click()
    {
        Shop.instance.ShowsItem(name, iconImg.sprite, describe);
    }

    public void setItem()
    {
        iconImg.sprite = Resources.Load<Sprite>("ShopItems/" + icon);
        nameTxt.text = name;
        priceTxt.text = price.ToString();
    }
}
