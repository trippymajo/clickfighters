using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

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