using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretsUpgrade : MonoBehaviour
{
    [SerializeField]
    private int upgradeCost = 100;
    [SerializeField]
    private int clicksIncrease = 2;
    [SerializeField]
    private const int levels = 3;
    [SerializeField]
    private int curLevel = 0;
    [SerializeField]
    private List<Sprite> turretSprites;
    [SerializeField]
    private Image turretImageToUpgrd;

    public Button upgradeButton;

    void Start()
    {
        UpdateTurretVisual();
    }

    private void UpdateTurretVisual()
    {
        if (turretSprites == null || turretSprites.Count <= curLevel)
        {
            Debug.LogWarning("No turret sprite available for this level.");
            return;
        }

        if (turretImageToUpgrd != null)
        {
            turretImageToUpgrd.sprite = turretSprites[curLevel];
        }
    }

    public void UpgradeTurrets()
    {
        if (ClickManager.Instance == null)
        {
            Debug.LogError("ClickManager.Instance is null");
            return;
        }

        if (curLevel > levels)
            return;

        bool success = ClickManager.Instance.TrySpendClicks(upgradeCost);
        if (success)
        {
            ClickManager.Instance.AddClicksPerSec(clicksIncrease);
            curLevel++;
            UpdateTurretVisual();
            Debug.Log($"Turrets upgraded! +{clicksIncrease} cliccks per sec");
        }
        else
        {
            Debug.Log("Not enough clicks to upgrade turrets!");
        }
    }
}
