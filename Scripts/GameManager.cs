
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private int score = 0;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject getReady;
    public GameObject gameOver;

    public void Awake()
    {

        Application.targetFrameRate = 60;
        AtStart();
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);
        getReady.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }

    public void AtStart()
    {
        Time.timeScale = 0f;
        player.enabled = false;
        getReady.SetActive(true);
        gameOver.SetActive(false);
    }
    public void Pause()
    {

        Time.timeScale = 0f;
        player.enabled = false;
        gameOver.SetActive(true);

    }

    public void GameOver()
    {
        Debug.Log("Game over");
        playButton.SetActive(true);
        Pause();

    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
}
