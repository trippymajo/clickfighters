using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundSwitching : MonoBehaviour
{
    [SerializeField] private Image targetImage;            // Image on panel
    [SerializeField] private List<Sprite> backgrounds;     // Backgroundss list
    [SerializeField] private float delay = 80f;             // umm delay in sex

    private int currentIndex = 0;

    void Start()
    {
        if (targetImage != null && backgrounds.Count > 0)
        {
            StartCoroutine(SwitchLoop());
        }
    }

    // uhhhmmm okay lets pretend itss alright
    private IEnumerator SwitchLoop()
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);

            currentIndex = (currentIndex + 1) % backgrounds.Count;
            targetImage.sprite = backgrounds[currentIndex];
        }
    }
}
