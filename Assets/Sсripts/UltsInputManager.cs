using System.Collections.Generic;
using UnityEngine;

public class UltsInputManager : MonoBehaviour
{
    public UltsBuy ultsBuy;

    private List<InputDirection> inputBuffer = new();
    private bool isInputActive = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))// rmb
        {
            if (!isInputActive)
            {
                StartInput();
            }
        }

        if (isInputActive)
        {
            if (Input.GetMouseButtonDown(0))
                AddInput(InputDirection.Left);
            if (Input.GetMouseButtonDown(1))
                AddInput(InputDirection.Right);

        }
    }

    void StartInput()
    {
        isInputActive = true;
        inputBuffer.Clear();
        Debug.Log("ULT iNPUT STARTED");
    }

    void AddInput(InputDirection dir)
    {
        inputBuffer.Add(dir);
        Debug.Log("Input: " + dir);

        CheckCombination();
    }

    void CheckCombination()
    {
        foreach (var ult in ultsBuy.ults)
        {
            if (!ult.isOwned) continue;

            if (IsSameCombination(ult.combination, inputBuffer))
            {
                Debug.Log($"ULT ACTIVATED: {ult.name}");
                // Make ult work
                ClickManager.Instance.AddClicks(ult.addClicks);
                ResetInput();
                return;
            }
        }

        // if no matcch and too long input - skip
        int maxLen = 0;
        foreach (var ult in ultsBuy.ults)
            if (ult.isOwned && ult.combination.Count > maxLen)
                maxLen = ult.combination.Count;

        if (inputBuffer.Count > maxLen)
        {
            Debug.Log("No match. Input reset.");
            ResetInput();
        }
    }

    private bool IsSameCombination(List<InputDirection> combo1, List<InputDirection> combo2)
    {
        if (combo1.Count != combo2.Count)
            return false;

        for (int i = 0; i < combo1.Count; i++)
        {
            if (combo1[i] != combo2[i])
                return false;
        }

        return true;
    }

    void ResetInput()
    {
        inputBuffer.Clear();
        isInputActive = false;
    }
}
