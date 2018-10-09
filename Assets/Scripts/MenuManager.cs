using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetInt("FirstPlay", 1);

        if (!PlayerPrefs.HasKey("LevelCompleted"))
        {
            PlayerPrefs.SetInt("LevelCompleted", 0);
        }

        //TESTING
        //PlayerPrefs.SetInt("LevelCompleted", 0);
        Debug.Log("LevelCompleted: " + PlayerPrefs.GetInt("LevelCompleted"));
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Intro");
    }
}
