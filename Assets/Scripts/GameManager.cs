using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;

    // Son constantes porque nunca van a cambiar
    private const string PLAYER_POS_X = "PlayerPositionX";
    private const string PLAYER_POS_Y = "PlayerPositionY";

    public void Save()
    {
        Debug.Log($"Save");

        // GUARDAR POSICIÓN --> Accedemos a player prefs hacemos persitentes 2 datos --> posX y posY del Player --> SE HAN DE HACER SI O SI POR SEPARADAS
        Vector3 pos = _playerController.GetPosition(); // Accede a la posición del player
        PlayerPrefs.SetFloat(PLAYER_POS_X, pos.x);
        PlayerPrefs.SetFloat(PLAYER_POS_Y, pos.y);
        Debug.Log($"Position {pos}");
        // Así Ya tenemos guardada la posición del jugador
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(PLAYER_POS_X))
        {
            Debug.Log($"Load");
            // Position
            float x = PlayerPrefs.GetFloat(PLAYER_POS_X);
            float y = PlayerPrefs.GetFloat(PLAYER_POS_Y);
            _playerController.SetPosition(new Vector3(x, y, 0));
            Debug.Log($"Position {x}, {y}");
        }
        else
        {
            Debug.LogError("No Data");
        }
    }
}
