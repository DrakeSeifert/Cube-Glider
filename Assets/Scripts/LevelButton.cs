using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour {

    public int buttonValue = -1;
    public Button levelButton;
    public Text buttonText;

	void Start () {
        buttonText.text = buttonValue.ToString();
        if (buttonValue > PlayerPrefs.GetInt("LevelCompleted") + 1)
        {
            levelButton.interactable = false;
            buttonText.color = Color.white;
        }  
	}
}
