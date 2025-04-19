using JetBrains.Annotations;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.VFX;

public class PointsManager : MonoBehaviour
{
    public int NumberRoundsToWin;
    public Counter counter;
    private static PointsManager instance;
    public PlayerManager[] player;
    public GameObject PlayerPrefab;
    private PlayerManager wins;

    private int RoundNumber;
    private PlayerManager RoundWinner;
    private PlayerManager GameWinner;
    private WaitForSeconds StartWait;


    public static PointsManager Instance 
    {
        get { return instance; }
        set { instance = value; }
    }

    public int amount;
    public int Amount 
    {
        get { return amount; }
        set {  amount = value; }

    }
    private void Awake()
    {
        if (instance == null) 
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else 
        {
        Destroy(gameObject);
        }
    }
    private void Start()
    {
        SpawnAllPlayers();
        StartCoroutine(GameLoop());
    }

    private void SpawnAllPlayers()
    {
        for (int i = 0; i < player.Length; i++) 
        {
            player[i].Player = Instantiate(PlayerPrefab, player[i].SpawnPoint.position, player[i].SpawnPoint.rotation) as GameObject;
            player[i].PlayerNumber = i + 1;
            player[i].SetUp();
        }
        
    }
    private IEnumerator GameLoop() 
    {
        yield return StartCoroutine(Roundstarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if (wins != null) 
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
        DisablePlayerControl();
        RoundWinner = null;
       
    //get round winner
        throw new NotImplementedException();
    }

    private IEnumerator RoundPlaying()
    {
        EnablePlayerControl();
        while (!OnePlayerLeft()) 
        {
            yield return null;
        }
      
    }

    private IEnumerator Roundstarting()
    {
        ResetAllPlayers();
        DisablePlayerControl();
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
    private void EnablePlayerControl() 
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].EnableControl();
        }
    }

    private void DisablePlayerControl()
    {
        for (int i = 0; i < player.Length; i++)
        {
            player[i].DisabledControl();
        }
    }
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
