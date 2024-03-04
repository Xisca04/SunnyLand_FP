using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScenes_ChSyst : MonoBehaviour
{
    // Load the scenes for the Chest System -> UI Buttons 

    public void LoadLabyrinthScene() // Load the Labyrinth challenge
    {
        Loader.Load(Loader.Scene.C_First_Level);
    }

    public void LoadCaveScene() // Load the Cave challenge
    {
        Loader.Load(Loader.Scene.C_Cave_Level);
    }

}
