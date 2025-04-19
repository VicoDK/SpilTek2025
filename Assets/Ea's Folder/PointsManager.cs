using JetBrains.Annotations;
using System;
using UnityEngine;
using UnityEngine.VFX;

public class PointsManager : MonoBehaviour
{
    public int NumberRoundsToWin;
    public Counter counter;
    private static PointsManager instance;
    public PlayerManager[] player;
    public GameObject PlayerPrefab;


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
}
