using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text gameOverText;
    public Text fScore;
    public int finalscore;
    public GameObject gameOverScreen;
    // Start is called before the first frame update
    void Start()
    {
        finalscore = FindObjectOfType<GunShoot>().score;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    bool gameOver = false;
    public void GameOver()
    {
        if(gameOver == false)
        {
            gameOver = true;
            gameOverScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            finalscore = FindObjectOfType<GunShoot>().score;
            fScore.text = "SCORE: " + finalscore.ToString();

        }
        
    }

    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MENU");
    }

}
