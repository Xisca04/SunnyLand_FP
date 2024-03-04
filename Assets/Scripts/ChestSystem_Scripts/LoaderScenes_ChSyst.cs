using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScenes_ChSyst : MonoBehaviour
{
    // Load the scenes for the chest system

    public void LoadFinalScene()
    {
        Loader.Load(Loader.Scene.C_Final_Level);
    }

    public void LoadLabyrinthScene()
    {
        Loader.Load(Loader.Scene.C_First_Level);
    }

    public void LoadCaveScene()
    {
        Loader.Load(Loader.Scene.C_Cave_Level);
    }

    public void LoadSecondLevel()
    {
        Loader.Load(Loader.Scene.Level2);
    }

    public void LoadFinalLevel()
    {
        Loader.Load(Loader.Scene.Final_Level);
    }

    public void LoadFirstLevel()
    {
        Loader.Load(Loader.Scene.Level1);
    }

    // Guardar la escena actual antes de cambiar
    // PlayerPrefs.SetString("Level1", SceneManager.GetActiveScene().name);
}
