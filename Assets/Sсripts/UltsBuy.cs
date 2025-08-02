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
}

public class UltsBuy : MonoBehaviour
{
    [SerializeField] private List<UltInfo> ults = new();

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
        foreach (var dir in ult.combination)
        {
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
