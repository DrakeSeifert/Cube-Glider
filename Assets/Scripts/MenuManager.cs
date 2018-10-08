using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	void Start () {
        PlayerPrefs.SetInt("FirstPlay", 1);
	}

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("Intro");
    }
}
