using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public HighScore highScore;
    public Text highScoreValue;
    public GameObject highScoreMenu;

    public void StartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame(){
        Application.Quit();
    }

    public void OpenHighScore(){
        highScoreMenu.SetActive(true);
        highScoreValue.text = highScore.highScore.ToString();
    }

    public void CloseHighScore(){
        highScoreMenu.SetActive(false);
    }

    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
