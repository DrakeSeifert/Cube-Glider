using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool playerHasDied = false;
    bool levelComplete = false;
    //bool firstPlay = true; //Checks if player came from menu screen or if scene was reloaded

    private float restartDelay = 2.5f;
    public GameObject completeLevelUI;
    public GameObject deathOverlayBlockCollision;
    public GameObject deathOverlayFellOffEdge;
    public GameObject startLevel;
    public GameObject FirstPlayStartLevel;

    void Start()
    {
        if(PlayerPrefs.GetInt("FirstPlay") == 1)
        {
            FirstPlayStartLevel.SetActive(true);
            PlayerPrefs.SetInt("FirstPlay", 0);
        } else
        {
            startLevel.SetActive(true);
        }
    }

    public void CompleteLevel()
    {
        if(!playerHasDied)
        {
            levelComplete = true;
            completeLevelUI.SetActive(true);
            PlayerPrefs.SetInt("FirstPlay", 1); //Reset FirstPlay so correct animation displays upon next level load
        }
    }


    //deathType:
        //BlockCollision
        //FellOffEdge
    public void EndGame(string deathType)
    {
        if (!playerHasDied && !levelComplete)
        {
            playerHasDied = true;
            Debug.Log("GAME OVER");
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
