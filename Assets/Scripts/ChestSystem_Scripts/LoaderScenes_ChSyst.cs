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

    public void LoadSecondLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadFinalLevel()
    {
        SceneManager.LoadScene("Final_Level");
    }

    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Level1");
    }
}
