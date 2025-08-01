using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[System.Serializable]
public class WeaponInfo
{
    public Button button;
    public int cost;
    public int multiplierBonus;
    public bool isOwned = false;
}


public class WeaponsUpgradeController : MonoBehaviour
{
    [SerializeField] private List<WeaponInfo> weapons = new();
    [SerializeField] private int mostMulti = 0;

    private void Start()
    {
        foreach (var weapon in weapons)
        {
            var currentWeapon = weapon;
            weapon.button.onClick.AddListener(() => TryBuyWeapon(currentWeapon));
        }
    }

    public void TryBuyWeapon(WeaponInfo weapon)
    {
        if (weapon.isOwned || weapon.multiplierBonus <= mostMulti)
        {
            Debug.Log("Already owned or bonus is smalleer than current");
            return;
        }

        if (ClickManager.Instance.TrySpendClicks(weapon.cost))
        {
            ClickManager.Instance.SetClicksMultiplier(weapon.multiplierBonus);
            weapon.isOwned = true;
            weapon.button.interactable = false;
            mostMulti = weapon.multiplierBonus;


            Text txt = weapon.button.GetComponentInChildren<Text>();
            if (txt != null)
                txt.text = "Owned";

            Debug.Log($"Bought weapon! +{weapon.multiplierBonus} multiplier.");
        }
        else
        {
            Debug.Log("Not enough clicks.");
        }
    }
}

