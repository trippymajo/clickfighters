using UnityEngine;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance;

    public int clickCount = 0;
    public int clicksPerSecond = 0;
    public int clickMultiplier = 1;

    private float _tickTimer = 0f;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        _tickTimer += Time.deltaTime;
        if (_tickTimer >= 1f)
        {
            _tickTimer = 0f;
            AddClicks(clicksPerSecond);
        }
    }

    public void AddClickManually()
    {
        AddClicks(clickMultiplier);
    }

    public void AddClicks(int amount)
    {
        clickCount += amount;
        UIManager.Instance?.UpdateClickDisplay(clickCount);
    }

    public bool TrySpendClicks(int amount)
    {
        if (clickCount < amount)
            return false;

        clickCount -= amount;
        UIManager.Instance?.UpdateClickDisplay(clickCount);
        return true;
    }
}