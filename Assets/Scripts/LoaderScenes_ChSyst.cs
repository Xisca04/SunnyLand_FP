using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoaderScenes_ChSyst : MonoBehaviour
{
    // Load the scenes for the chest system

    public void LoadFinalScene()
    {
        SceneManager.LoadScene("C_Final_Level");
    }

    public void LoadChaseScene()
    {
        SceneManager.LoadScene("C_First_Level");
    }

    public void LoadCaveScene()
    {
        SceneManager.LoadScene("C_Cave_Level");
    }

    public void LoadIceScene()
    {
        SceneManager.LoadScene("C_Ice_Level");
    }
}