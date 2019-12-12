using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void Level1()
    {
        SceneManager.LoadScene("Level01");
        GameManager.instance.GetPlayerWave();
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level02");
        GameManager.instance.GetPlayerWave();
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level03");
        GameManager.instance.GetPlayerWave();
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Debug.Log("Appliation Quit");
        Application.Quit();
    }
}
