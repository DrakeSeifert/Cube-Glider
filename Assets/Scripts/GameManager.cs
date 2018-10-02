using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool playerHasDied = false;
    bool levelComplete = false;

    private float restartDelay = 2.5f;

    public PlayerMovement playerMovement;
    public Score score;
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
        } else
        {
            startLevel.SetActive(true);
        }
    }

    public void CompleteLevel()
    {
        score.SetScore(endTrigger.position.z.ToString()); //Top score will consistently be the same value
        score.FreezeScore();
        if(!playerHasDied)
        {
            levelComplete = true;
            playerMovement.StartRewind();
        }
    }

    public void StartCompleteLevelAnimation()
    {
        completeLevelUI.SetActive(true);
        PlayerPrefs.SetInt("FirstPlay", 1); //Reset FirstPlay so correct animation displays upon next level load
    }

    //deathType:
        //BlockCollision
        //FellOffEdge
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
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Level01");
            //If you want to load a specific scene
    }
}
