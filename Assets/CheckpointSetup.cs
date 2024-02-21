using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSetup : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    
    private void Start()
    {
        _gameManager.Load();
    }
}
