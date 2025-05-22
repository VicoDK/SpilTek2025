using NUnit.Framework;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    List<GameObject> playerlist = new List<GameObject>();
    public bool MoreThanOnePlayer;
    public TMP_InputField input;
    public string winner = "shkdfhsjgfhgsfkjsfgdsajlgefræpsagfuisgefgbweKAYHPSEFUHUFD";
    
    public GameObject canvas;
    
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MoreThanOnePlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] player = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject players in player)
        {
            if (!playerlist.Contains(players)) 
            {
            playerlist.Add(players);
            }
        }

            Debug.Log(player.Length +"" + MoreThanOnePlayer);
        if (player.Length <= 1&& MoreThanOnePlayer) 
        {
            winner = input.text.ToString();
            canvas.SetActive(true);
            
        }

        if (playerlist.Count >= 2) 
        {
            MoreThanOnePlayer = true;
        }

    }

    public void RemovePlayer(GameObject player) 
    {
    playerlist.Remove(player);
    }



}
