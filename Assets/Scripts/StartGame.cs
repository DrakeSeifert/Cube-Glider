using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

    public GameObject startGameAnimation;
    private float waitTime = 0.7f;

    public void BeginGame()
    {
        startGameAnimation.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Invoke("BeginGame2", waitTime);
    }

    void BeginGame2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
