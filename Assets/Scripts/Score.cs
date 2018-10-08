using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Transform player;
    public Transform endTrigger;
    public Text scoreText;

    bool scoreIsFrozen = false;

    const int SCORE_MULTIPLIER = 1000;

	// Update is called once per frame
	void Update () {
        if (!scoreIsFrozen)
            UpdateScore();
	}

    void UpdateScore()
    {
        int mappedScore = Mathf.FloorToInt((player.position.z / endTrigger.position.z) * SCORE_MULTIPLIER);
        //Debug.Log("Player Pos:" + player.position.z);
        //Debug.Log("   End Pos:" + endTrigger.position.z);
        //Debug.Log("     Score:" + mappedScore);
        //scoreText.text = player.position.z.ToString("0");
        scoreText.text = mappedScore.ToString("0");
    }

    public void FreezeScore()
    {
        scoreIsFrozen = true;
    }

    public void SetScore(string score)
    {
        scoreText.text = score;
    }

    public int GetScoreInt()
    {
        return int.Parse(scoreText.text);
    }

    public string GetScoreString()
    {
        return scoreText.text;
    }
}
