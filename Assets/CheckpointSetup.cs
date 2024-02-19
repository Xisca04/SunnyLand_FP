using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSetup : MonoBehaviour
{
    [SerializeField] GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager.Load();
    }

    
}
