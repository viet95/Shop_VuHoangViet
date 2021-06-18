using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;

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

    public SpriteAtlas atlas;

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
        iconImg.sprite = atlas.GetSprite(icon);
        nameTxt.text = name;
        priceTxt.text = price.ToString();
    }
}
