using JetBrains.Annotations;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.VFX;

public class PointsManager : MonoBehaviour
{
    public int NumberRoundsToWin;
    
    

    public PlayerManager[] player;

    public GameObject PlayerPrefab;

    public TMP_Text MessageText;
   
    public TMP_Text CountText;


    private int RoundNumber;
    private PlayerManager RoundWinner;
    private PlayerManager GameWinner;

    private WaitForSeconds StartWait;
    private WaitForSeconds EndWait;

    private void SetCountText()
    {
        CountText.text = RoundNumber.ToString();

    }

   
    private void Start()
    {
        StartWait = new WaitForSeconds(3f);
        EndWait = new WaitForSeconds(3f);
        SetCountText();
        SpawnAllPlayers();
        StartCoroutine(GameLoop());
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < player.Length; i++) 
        {
            player[i].Player = Instantiate(PlayerPrefab, player[i].SpawnPoints[i].position, player[i].SpawnPoints[i].rotation) as GameObject;
            player[i].PlayerNumber = i + 1;
            player[i].SetUp();
        }
        
    }
    private IEnumerator GameLoop() 
    {
        yield return StartCoroutine(Roundstarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if (GameWinner != null) 
        {
            SceneManager.LoadScene("EasScene");
        }
        else 
        {
            StartCoroutine(GameLoop());
        }

    }

    private IEnumerator RoundEnding()
    {
        //DisablePlayerControl();
        RoundWinner = null;

        //RoundWinner = GetRoundWinner();
        //get round winner
        if (RoundWinner != null)
            RoundWinner.Wins++;
        GameWinner = GetGameWinner();

        string message = EndMessage();
        MessageText.text = message;
        yield return EndWait;
        
    }
    private string EndMessage()
    {
       
        string message = "tie";

        
        if (RoundWinner != null)
            message = RoundWinner.ColoredPlayerText + " Wins round";

        
        message += "\n\n\n\n";

        
        for (int i = 0; i < player.Length; i++)
        {
            message += player[i].ColoredPlayerText + ": " + player[i].Wins + " WINS\n";
        }

        
        if (GameWinner != null)
            message = GameWinner.ColoredPlayerText + " Wins game";

        return message;
    }

    private PlayerManager GetGameWinner()
    {
        for(int i = 0; i < player.Length; i++) 
        {
            if (player[i].Wins == NumberRoundsToWin)
                return player[i];
        }
        return null;
    }

    /*private PlayerManager GetRoundWinner()
    {
        for(int i = 0; i < player.Length; i++) 
        {
            if (player[i].Player.activeSelf) 
            {
            return player[i];
            }
        }
        return null;
        
    }*/

    private IEnumerator RoundPlaying()
    {
        //EnablePlayerControl();
        while (!OnePlayerLeft()) 
        {
            yield return null;
        }
      
    }

    private IEnumerator Roundstarting()
    {
        ResetAllPlayers();
        //DisablePlayerControl();
        RoundNumber++;
        yield return StartWait;
    }

    private void ResetAllPlayers() 
    {
        for(int i=0; i < player.Length; i++) 
        {
            player[i].Reset();
        }
    }
    /*private void EnablePlayerControl() 
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].EnableControl();
        }
    }*/

    /*private void DisablePlayerControl()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].DisabledControl();
        }
    }*/
    private bool OnePlayerLeft() 
    {
        int NumberPlayerLeft = 0;
        for(int i = 0;i < player.Length; i++) 
        {
           
        if(player[i].Player.activeSelf)
                NumberPlayerLeft++;
        }
        return NumberPlayerLeft <= 0;
    }

}
