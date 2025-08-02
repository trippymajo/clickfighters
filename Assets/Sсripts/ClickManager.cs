using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance;

    [SerializeField]
    private int clickCount = 0;
    [SerializeField]
    private int clicksPerSecond = 0;
    [SerializeField]
    private int clickMultiplier = 1;

    [SerializeField]
    private int outOfBounds = 2000000000;

    [SerializeField] 
    private Animator playerAnimator;

    private float _tickTimer = 0f;
    private bool isSwitchingScene = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isSwitchingScene)
            return;

        if (clickCount < 0 || clickCount > outOfBounds)
        {
            Debug.LogWarning("Click count out of bounds, starting scene switch...");
            StartCoroutine(SwitchSceneSafely("End"));
            isSwitchingScene = true;
            return;
        }

        _tickTimer += Time.deltaTime;
        if (_tickTimer >= 1f)
        {
            _tickTimer = 0f;
            AddClicks(clicksPerSecond);
        }
    }

    private IEnumerator SwitchSceneSafely(string sceneName)
    {
        // Удаляем все persistent-объекты
        var persistentObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var obj in persistentObjects)
        {
            if (obj.scene.name == null || obj.scene.name == "")
            {
                Destroy(obj);
            }
        }

        // Ждём 1 кадр — объекты будут реально удалены
        yield return null;

        // Теперь безопасно загружаем сцену
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }

    public void AddClickManually()
    {
        AddClicks(clickMultiplier);
        playerAnimator.SetTrigger("Shoot");
    }

    public void AddClicks(int amount)
    {
        clickCount += amount;
        UIPlaysiteManager.Instance?.UpdateClickDisplay(clickCount);
    }
    
    public void SetClicksMultiplier(int multi)
    {
        clickMultiplier = multi;
    }

    /// <summary>
    /// Add clicks per secs
    /// </summary>
    /// <param name="addPersec"></param>
    public void AddClicksPerSec(int addPersec)
    {
        clicksPerSecond += addPersec;
    }

    /// <summary>
    /// Buy process, spend clicks
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool TrySpendClicks(int amount)
    {
        if (clickCount < amount)
            return false;

        clickCount -= amount;
        UIPlaysiteManager.Instance?.UpdateClickDisplay(clickCount);
        return true;
    }
}