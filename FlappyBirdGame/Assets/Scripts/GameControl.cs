using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    // This is the only member that is static to the GameControl class
    public static GameControl instance;

    // Assign what gameObject you would like to control when the player reaches Game Over
    public GameObject gameOverText;
    public Text scoreText;

    public bool gameOver;
    int score = 0;

    void Awake()
    {
        // Singleton Pattern
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }                 
    }
        
    void Update()
    {        
        if (gameOver && Input.GetKeyDown(KeyCode.Space))
        {
            // Reload the scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void BirdDied()
    {
        gameOverText.SetActive(true);
        gameOver = true;
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return;
        }
        else
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
        }        
    }
}
