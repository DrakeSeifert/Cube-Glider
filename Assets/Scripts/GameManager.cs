using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool playerHasDied = false;
    bool levelComplete = false;

    private float restartDelay = 2.5f;
    //public Material PlayerMat;
    public GameObject completeLevelUI;
    public GameObject deathOverlayBlockCollision;
    public GameObject deathOverlayFellOffEdge;
    public GameObject startLevel;

    void Start()
    {
        startLevel.SetActive(true);
    }

    public void CompleteLevel()
    {
        if(!playerHasDied)
        {
            Debug.Log("LEVEL COMPLETE");
            levelComplete = true;
            completeLevelUI.SetActive(true);
        }
    }


    //deathType:
        //BlockCollision
        //FellOffEdge
    public void EndGame(string deathType)
    {
        //Debug.Log(deathType);
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

    //public void EndGame(bool FellOffEdge)
    //{
    //    if (!playerHasDied && !levelComplete)
    //    {
    //        playerHasDied = true;
    //        Debug.Log("GAME OVER");
    //        deathOverlay.SetActive(true);
    //        Invoke("Restart", restartDelay);
    //    }
    //}

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Level01");
            //If you want to load a specific scene
    }
}
