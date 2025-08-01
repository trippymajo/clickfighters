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

    public Button upgradeButton;

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
            Debug.Log($"Turrets upgraded! +{clicksIncrease} cliccks per sec");
        }
        else
        {
            Debug.Log("Not enough clicks to upgrade turrets!");
        }
    }
}
