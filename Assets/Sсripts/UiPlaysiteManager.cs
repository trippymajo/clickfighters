using TMPro;
using UnityEngine;

public class UIPlaysiteManager : MonoBehaviour
{
    public static UIPlaysiteManager Instance;

    public TMP_Text clickText;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateClickDisplay(int count)
    {
        clickText.text = $"Clicks: {count}";
    }
}