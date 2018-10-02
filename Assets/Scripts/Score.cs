using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Text scoreText;

    bool scoreIsFrozen = false;

	// Update is called once per frame
	void Update () {
        if(!scoreIsFrozen)
            scoreText.text = player.position.z.ToString("0");
	}

    public void FreezeScore()
    {
        scoreIsFrozen = true;
    }

    public void SetScore(string score)
    {
        scoreText.text = score;
    }

}
