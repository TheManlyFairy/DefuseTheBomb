using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;
    static int strikes;
    Manager[] puzzleManagers;

	// Use this for initialization
	void Start () {

        gameManager = this;
        strikes = 3;
	}

    public static void CheckAllPuzzles()
    {
        bool flag = true;
        int index = 0;

        while(flag == true && index < gameManager.puzzleManagers.Length)
        {
            if (!gameManager.puzzleManagers[index].isPuzzleSolved)
                flag = false;
            index++;
        }
        if(flag)
        {
            Debug.Log("Victory");
        }
    }

    public static void StrikeDown()
    {
        strikes--;
        Debug.Log(strikes + " left");
        if (strikes == 0)
            SceneManager.LoadScene("Main");
    }

    public static void WinGame()
    {
        Debug.Log("Win Game");
    }

    public static void LoseGame()
    {
        Debug.Log("Lost the game");
    }
}
