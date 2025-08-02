using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum InputDirection
{
    Left,
    Right
}

[System.Serializable]
public class UltInfo
{
    public Button button;
    public string name;
    public Sprite icon;
    public int price;
    public List<InputDirection> combination;
    public bool isOwned = false;
    public int addClicks;
}

public class UltsBuy : MonoBehaviour
{
    public List<UltInfo> ults = new();
   
    public GameObject ultsPanel;
    public GameObject ultsCellPrefab;
    public GameObject ultsToClickPrefab;

    public Sprite leftIcon;
    public Sprite rightIcon;

    void Start()
    {
        foreach (var ult in ults)
        {
            var curUlt = ult;
            if (ult.button != null)
                ult.button.onClick.AddListener(() => BuyUlt(ult));
        }
    }

    public void BuyUlt(UltInfo ult)
    {
        int price = ult.price;

        if (ClickManager.Instance == null)
        {
            Debug.LogError("ClickManager.Instance is null");
            return;
        }


        bool success = ClickManager.Instance.TrySpendClicks(price);
        if (success)
        {
            // Add to panel wwith grid ceell
            CreateUltVisual(ult);

            ult.button.interactable = false;
            ult.isOwned = true;
        }
        else
        {
            Debug.Log("not enough money or already bought");
        }
    }

    private void CreateUltVisual(UltInfo ult)
    {
        // makee a cell
        GameObject newUlt = Instantiate(ultsCellPrefab, ultsPanel.transform);
        Transform innerGrid = newUlt.transform;

        // make a combo to click
        for (int i = 0; i < ult.combination.Count; i++)
        {
            var dir = ult.combination[i];

            if (i ==0)
            {
                GameObject MainIcon = Instantiate(ultsToClickPrefab, innerGrid);
                Image icon = MainIcon.GetComponentInChildren<Image>();
                icon.sprite = ult.icon;
            }
            GameObject toClick = Instantiate(ultsToClickPrefab, innerGrid);
            Image img = toClick.GetComponentInChildren<Image>();

            // pick icon for combo
            if (img != null)
            {
                img.sprite = dir switch
                {
                    InputDirection.Left => leftIcon,
                    InputDirection.Right => rightIcon,
                    _ => null
                };
            }
        }
    }
}
