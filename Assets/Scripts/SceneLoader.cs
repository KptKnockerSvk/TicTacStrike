using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadSceneLMaps()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LvlMenu"); 
    }

    public void LoadSceneMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Start Screen");
    }
    public void LoadLev1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level01");
    }
    public void LoadLev2()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level02");
    }
    public void LoadLev3()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level03");
    }
    public void LoadLev4()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level04");
    }
    public void LoadLev5()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level05");
    }
}
