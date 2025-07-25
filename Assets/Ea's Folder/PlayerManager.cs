using UnityEngine;
using System;
[Serializable]
public class PlayerManager : MonoBehaviour
{
    public Color PlayerColor; // color that players will be tinted with.
    public Transform[] SpawnPoints; //position of spawn
    public int PlayerNumber; //specifies manager
    public string ColoredPlayerText; //string matches with color of player
    public GameObject Player; // reference to player
    public int Wins; //number of wins


    public movement Movement;
    public PlayerControls bombing;
    private GameObject CanvasGameObject;
    

     public void SetUp() 
    {
        Movement = Player.GetComponent<movement>();
        bombing = Player.GetComponent<PlayerControls>();
        CanvasGameObject = Player.GetComponentInChildren<Canvas>().gameObject;
        //movement from component and connect with the number of player
        //bombing from the component and connect with the number of player
        
        
        ColoredPlayerText = "<color=#" + ColorUtility.ToHtmlStringRGB(PlayerColor) + ">Player" + PlayerNumber + "</color>";

        MeshRenderer[] renderers = Player.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < renderers.Length; i++) 
        {
        renderers[i].material.color = PlayerColor;
        }
    }
    public void DisabledControl() 
    {
        Movement.enabled = false;
        bombing.enabled = false;
        CanvasGameObject.SetActive(false);
   
    }
    public void EnableControl() 
    {
        Movement.enabled = true;
        bombing.enabled = true;
        CanvasGameObject.SetActive(true);
    

    }
    
    public void Reset() 
    {
        for (int i = 0; i < SpawnPoints.Length; i++)
        {
            Player.transform.position = SpawnPoints[i].position;
            Player.transform.rotation = SpawnPoints[i].rotation;
        }
        Player.SetActive(false);
        Player.SetActive(true);
    
    }

}
