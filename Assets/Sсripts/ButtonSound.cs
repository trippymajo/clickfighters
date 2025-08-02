using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    [SerializeField]
    private AudioClip clickSound;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(PlaySound);
    }

    void PlaySound()
    {
        if (clickSound != null)
        {
            UIButtonsSound.Instance.Play(clickSound);
        }
    }
}
