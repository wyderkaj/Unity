using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Transform[] Images;
    public GameObject winText;
    public static bool youWin;

    // Start is called before the first frame update
    void Start()
    {
        youWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Images[0].rotation.z == 0 && Images[1].rotation.z == 0 &&
           Images[2].rotation.z == 0 && Images[3].rotation.z == 0 &&
           Images[4].rotation.z == 0 && Images[5].rotation.z == 0
           )
        {
            youWin = true;
            winText.SetActive(true);

        }
    }

    public void reStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void PlaySecondGame()
    {
        SceneManager.LoadScene("Puzzle2");
    }

    public void PlayThirdGame()
    {
        SceneManager.LoadScene("Puzzle3");
    }

    public void PlayFourthGame()
    {
        SceneManager.LoadScene("Puzzle4");
    }


    public void GoBack()
    {
        SceneManager.LoadScene("MainMenuScene");
    }

}
