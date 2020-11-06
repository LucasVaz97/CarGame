using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public bool isNotMenu;
    float Score;
    public Text text;
    // Start is called before the first frame update
    public void Start()
    {
        if (isNotMenu)
        {
            Score = PlayerPrefs.GetFloat("Time");


            text.text = "Your Best Time: \n" + Score.ToString();
            print(Score);

        }
     
    }
    public void playGame()
    {
        SceneManager.LoadScene("Track");
    }

    public void quit()
    {
        Application.Quit();
    }
}
