using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    bool playerHasDied = false;
    bool levelComplete = false;

    public float restartDelay = 3f;
    //public Material PlayerMat;
    public GameObject completeLevelUI;
    public GameObject deathOverlay;

    public void CompleteLevel()
    {
        if(!playerHasDied)
        {
            Debug.Log("LEVEL COMPLETE");
            levelComplete = true;
            completeLevelUI.SetActive(true);
        }
    }

    public void EndGame()
    {
        if (!playerHasDied)
        {
            playerHasDied = true;
            Debug.Log("GAME OVER");
            deathOverlay.SetActive(true);
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
