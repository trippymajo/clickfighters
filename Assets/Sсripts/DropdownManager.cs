using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropdownManager : MonoBehaviour
{
    public GameObject dropdownPanel;
    //public GameObject gemsPanel;
    //public GameObject arrowCellPrefab;
    //public UnityEngine.UI.Button[] optionButtons;

    //public GameObject gemCellPrefab;

    public void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public void OnOptionSelected(int index)
    //{
    //    GameObject clickedObject = EventSystem.current.currentSelectedGameObject;
    //    if (clickedObject == null)
    //    {
    //        Debug.LogWarning("No button was clicked");
    //        return;
    //    }

    //    TMP_Text label = clickedObject.GetComponentInChildren<TMP_Text>();
    //    if (label == null)
    //    {
    //        Debug.LogWarning("Button has no Text component");
    //        return;
    //    }

    //    OnPanelAButtonClick(label.text);

    //    clickedObject.SetActive(false);
    //}

    public void ToggleDropdown()
    {
        dropdownPanel.SetActive(!dropdownPanel.activeSelf);
    }

    //public void OnPanelAButtonClick(string buttonName)
    //{
    //    if (!_combos.ContainsKey(buttonName))
    //        return;

    //    GameObject newGem = Instantiate(gemCellPrefab, gemsPanel.transform);
    //    newGem.name = "GemCell_" + buttonName;
    //    Transform innerGrid = newGem.transform;

    //    foreach (var dir in _combos[buttonName])
    //    {
    //        GameObject arrow = Instantiate(arrowCellPrefab, innerGrid);
    //        arrow.GetComponentInChildren<TMP_Text>().text = DirToSymbol(dir);
    //    }
    //}

    //private bool CreateGemInstructions(string gemName)
    //{
    //    if (!_combos.ContainsKey(gemName))
    //        return false;
    //    return false;
    //}
}
