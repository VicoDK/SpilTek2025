using UnityEngine;
using System;
[Serializable]
public class PlayerManager : MonoBehaviour
{
    public Color PlayerColor; // color that players will be tinted with.
    public Transform SpawnPoint; //position of spawn
    public int PlayerNumber; //specifies manager
    public string ColoredPlayerText; //string matches with color of player
    public GameObject Player; // reference to player
    public int Wins; //number of wins

    //add movement
    //add bombing

    public void SetUp() 
    {
        //movement from component and connect with the number of player
        //bombing from the component and connect with the number of player

        ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(PlayerColor) + ">Player" + PlayerNumber + "</color>";
        MeshRenderer[] renderers = Player.GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < renderers.Length; i++) 
        {
        renderers[i].material.color = PlayerColor;
        }
    }
    
    public void Reset() 
    {
        Player.transform.position = SpawnPoint.position;
        Player.transform.rotation = SpawnPoint.rotation;
        
        Player.SetActive(false);
        Player.SetActive(true);
    
    }

}
