using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] PlayerController _playerController;

    // Son constantes porque nunca van a cambiar
    private const string PLAYER_POS_X = "PlayerPositionX";
    private const string PLAYER_POS_Y = "PlayerPositionY";

    private bool firstTime = true;
    public bool chestCompleted = false;

    private void Start()
    {
        if(chestCompleted == false)
        {
            DeleteKeyPlayer();
        }
        else if(chestCompleted == true)
        {
            Load();
        }
    }

    private void DeleteKeyPlayer()
    {
        PlayerPrefs.DeleteKey("PlayerPositionX");
        PlayerPrefs.DeleteKey("PlayerPositionX");
        firstTime = true;
    }

    public void Save()
    {
        Debug.Log($"Save");
        // GUARDAR POSICI�N --> Accedemos a player prefs hacemos persitentes 2 datos --> posX y posY del Player --> SE HAN DE HACER SI O SI POR SEPARADAS
        Vector3 pos = _playerController.GetPosition(); // Accede a la posici�n del player
        PlayerPrefs.SetFloat(PLAYER_POS_X, pos.x);
        PlayerPrefs.SetFloat(PLAYER_POS_Y, pos.y);
        firstTime = false;
        Debug.Log($"{pos}");
    }

    public void Load()
    {
        Debug.Log($"Load");
        // Position
        float x = PlayerPrefs.GetFloat(PLAYER_POS_X,0);
        float y = PlayerPrefs.GetFloat(PLAYER_POS_Y, 0);
        _playerController.SetPosition(new Vector3(x, y, 0));
    }
}
