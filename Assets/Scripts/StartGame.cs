using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject startGameAnimation;
    private float waitTime = 0.7f;
    private string levelName;

    private void Start()
    {
        if(!PlayerPrefs.HasKey("LevelCompleted"))
        {
            PlayerPrefs.SetInt("LevelCompleted", 0);
        }

        //TESTING
        PlayerPrefs.SetInt("LevelCompleted", 0);
        Debug.Log("LevelCompleted: "+ PlayerPrefs.GetInt("LevelCompleted"));
    }

    public void BeginGameAndAnimation(int level)
    {
        //Testing
        if (level < 10)
            levelName = "0" + level.ToString();
        else
            levelName = level.ToString();

        //Check that player is eligible to play selected level
        if(PlayerPrefs.GetInt("LevelCompleted") >= level - 1 && Application.CanStreamedLevelBeLoaded("Level" + levelName))
        {
            startGameAnimation.SetActive(true);
            Invoke("LoadNextScene", waitTime);
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
