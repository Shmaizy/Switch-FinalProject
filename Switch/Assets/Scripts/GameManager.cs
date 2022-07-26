
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject gameOverScreen;
    public GameObject youWinScreen;
    public void EndGame()
    {
        gameOverScreen.SetActive(true);
        Debug.Log("You Died");

    }

    public void WinGame()
    {
        youWinScreen.SetActive(true);
        Debug.Log("You Win");  
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level Manu");
    }


}
