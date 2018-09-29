using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject startGameAnimation;
    private float waitTime = 0.7f;

    public void BeginGameAndAnimation()
    {
        startGameAnimation.SetActive(true);
        Invoke("LoadNextScene", waitTime);
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //public void Quit()
    //{
    //    Debug.Log("QUIT");
    //    Application.Quit();
    //}
}
