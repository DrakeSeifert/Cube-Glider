using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject startGameAnimation;
    public GameObject levelButton;
    private float waitTime = 0.7f;
    private string levelName;

    public void BeginGameAndAnimation(int level)
    {
        if (level < 10)
            levelName = "0" + level.ToString();
        else
            levelName = level.ToString();

        //Check that player is eligible to play selected level
        if (PlayerPrefs.GetInt("LevelCompleted") >= level - 1)
        {
            //Testing
            if (Application.CanStreamedLevelBeLoaded("Level" + levelName))
            {
                startGameAnimation.SetActive(true);
                Invoke("LoadNextScene", waitTime);
            }
            else
            {
                Debug.Log("Error: Level " + level + " does not exist");
            }
        }
        else
        {
            Debug.Log("Access Denied! Unlock all previous levels");
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene("Level" + levelName);
    }

}
