using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSetup : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    
    private void Update()
    {
        if (_gameManager.chestCompleted == true)
        {
            _gameManager.Load();
        }
    }
    
    /*
    private void Start()
    {
        _gameManager.Load();
    }
    */
}
