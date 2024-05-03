using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenu : MonoBehaviour
{
    public Text scoureText;
    public int score;

    // Start is called before the first frame update
    void Start()
    {
        LoadScore();
    }

    void LoadScore()
    {
        scoureText.text = "Puntuación: " + score.ToString();
    }

    public void LoadMainmenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}