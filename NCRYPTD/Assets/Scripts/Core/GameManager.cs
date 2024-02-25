using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    [NonSerialized] public UnityEvent OnPuzzleSolved = new UnityEvent();

    private PuzzleID _lastSolvedPuzzle;

    public PuzzleID LastSolvedPuzzle { get { return _lastSolvedPuzzle; } set { _lastSolvedPuzzle = value; } }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        OnPuzzleSolved.AddListener(ActivateNewPuzzle);
    }

    private void ActivateNewPuzzle()
    {
        switch(_lastSolvedPuzzle)
        {
            case PuzzleID.puzzleA:
                PuzzleActivator.instance.ActivatePuzzleB();
                PuzzleActivator.instance.ActivatePuzzleC();
                break;
            case PuzzleID.puzzleB:
                PuzzleActivator.instance.ActivatePuzzleD();
                break;
            case PuzzleID.puzzleC:
                PuzzleActivator.instance.ActivatePuzzleE();
                break;
        }
    }
}
