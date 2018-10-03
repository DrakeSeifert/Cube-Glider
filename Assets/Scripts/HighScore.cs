using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text highScoreText;
    public Score score;
    public Transform player;

	// Use this for initialization
	void Start () {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString("0");
    }

    void LateUpdate()
    {
        if (int.Parse(highScoreText.text) < score.GetScoreInt())
            highScoreText.text = score.GetScoreString();
    }

    

    public void SetNewHighScore(int newHighScore)
    {
        if(newHighScore > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", newHighScore);
    }
}
