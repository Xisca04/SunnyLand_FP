using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Saves and loads the Player's position

    // Reference
    [SerializeField] PlayerController _playerController;

    // Son constantes porque nunca van a cambiar
    private const string PLAYER_POS_X = "PlayerPositionX";
    private const string PLAYER_POS_Y = "PlayerPositionY";

    // Save the Player's position
    public void Save()
    {
        Vector3 pos = _playerController.GetPosition(); // Access to the Player's position
        // We make 2 data persistence
        PlayerPrefs.SetFloat(PLAYER_POS_X, pos.x); // X Position
        PlayerPrefs.SetFloat(PLAYER_POS_Y, pos.y); // Y Positino
    }

    // Load the saved position
    public void Load()
    {
        float x = PlayerPrefs.GetFloat(PLAYER_POS_X,0); // Loacate the X position saved
        float y = PlayerPrefs.GetFloat(PLAYER_POS_Y, 0); // Loacate the Y position saved
        _playerController.SetPosition(new Vector3(x, y, 0)); // Load both position to the Player's position
    }
}
