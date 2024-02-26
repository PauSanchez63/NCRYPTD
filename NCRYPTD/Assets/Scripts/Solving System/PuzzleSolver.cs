using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSolver : MonoBehaviour
{
    [SerializeField] private PuzzlePiece[] puzzlePieces;
    [SerializeField] private PuzzleID puzzle;
    private bool _solved = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckPuzzle());
    }

    IEnumerator CheckPuzzle()
    {
        while(!_solved)
        {
            yield return new WaitForSeconds(0.25f);
            _solved = true;
            foreach(var piece in puzzlePieces)
            {
                if(!piece.IsInPosition)
                {
                    _solved = false;
                    break;
                }
            }
        }

        GameManager.instance.LastSolvedPuzzle = puzzle;
        GameManager.instance.OnPuzzleSolved?.Invoke();
    }
}
