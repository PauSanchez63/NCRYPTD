using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleActivator : MonoBehaviour
{
    public static PuzzleActivator instance;

    [SerializeField] private GameObject puzzleB;
    [SerializeField] private GameObject puzzleC;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    #region PuzzleActivators
    public void ActivatePuzzleB()
    {
        puzzleB.SetActive(true);
    }

    public void ActivatePuzzleC()
    {
        puzzleC.SetActive(true);
    }

    public void ActivatePuzzleD()
    {
        Debug.Log("Puzzle D activated");
    }

    public void ActivatePuzzleE()
    {
        Debug.Log("Puzzle E activated");
    }
    #endregion
}
