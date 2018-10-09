using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool playerHasDied = false;
    bool levelComplete = false;

    private float restartDelay = 2.5f;
    public int levelNumber = 0;

    public PlayerMovement playerMovement;
    public Score score;
    public HighScore highScore;
    public Transform endTrigger;

    //Animations
    public GameObject completeLevelUI;
    public GameObject deathOverlayBlockCollision;
    public GameObject deathOverlayFellOffEdge;
    public GameObject startLevel;
    public GameObject firstPlayStartLevel;

    void Start()
    {
        if(PlayerPrefs.GetInt("FirstPlay") == 1)
        {
            firstPlayStartLevel.SetActive(true);
            PlayerPrefs.SetInt("FirstPlay", 0);
            PlayerPrefs.SetInt("HighScore", 0);
        } else
        {
            startLevel.SetActive(true);
        }
    }

    public void CompleteLevel()
    {
        //Rewind only if player hasn't crossed the finish line just after a collision
        if(!playerHasDied)
        {
            levelComplete = true;

            //Adjust scores
            score.SetScore(1000.ToString()); //Top score will consistently be the same value
            score.FreezeScore();
            highScore.SetNewHighScore(score.GetScoreInt());

            //Save player progress
            PlayerPrefs.SetInt("LevelCompleted", levelNumber);

            playerMovement.StartRewind();
        }
    }

    public void StartCompleteLevelAnimation()
    {
        completeLevelUI.SetActive(true);
        PlayerPrefs.SetInt("FirstPlay", 1); //Reset FirstPlay so correct animation displays upon next level load
    }

    public void EndGame(string deathType)
    {
        if (!playerHasDied && !levelComplete)
        {
            playerHasDied = true;
            switch (deathType)
            {
                case "BlockCollision":
                    deathOverlayBlockCollision.SetActive(true);
                    break;
                case "FellOffEdge":
                    deathOverlayFellOffEdge.SetActive(true);
                    break;
            }
            highScore.SetNewHighScore(score.GetScoreInt());
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
