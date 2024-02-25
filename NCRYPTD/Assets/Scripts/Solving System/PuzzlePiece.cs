using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePiece : MonoBehaviour
{
    private Id _id;
    [SerializeField] private bool _isInPosition;

    public bool IsInPosition { get { return _isInPosition; } }

    private void Start()
    {
        _id = GetComponent<Id>();
    }

    private void OnTriggerEnter(Collider other)
    {
        var idScript = other.GetComponent<Id>();
        if (idScript != null)
        {
            if(idScript.ID == _id.ID)
            {
                _isInPosition = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var idScript = other.GetComponent<Id>();
        if (idScript != null)
        {
            if (idScript.ID == _id.ID)
            {
                _isInPosition = false;
            }
        }
    }
}
