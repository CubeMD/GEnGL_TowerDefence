using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void Level1()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level01");
        GameManager.instance.GetPlayer();
    }
    public void Level2()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level02");
        GameManager.instance.GetPlayer();
    }
    public void Level3()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Level03");
        GameManager.instance.GetPlayer();
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
