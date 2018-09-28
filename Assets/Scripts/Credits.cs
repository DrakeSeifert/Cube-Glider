using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour {

    public void Quit()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void GoToMenu()
    {
        //Menu Scene should be at location 0 in the build index
        SceneManager.LoadScene(0);
    }

}
