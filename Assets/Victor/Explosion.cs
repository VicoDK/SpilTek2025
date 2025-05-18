using System;
using System.ComponentModel.Design;
using Mirror;
using UnityEngine;

public enum dir
{
    North,
    South,
    West,
    East
}
public class Explosion : NetworkBehaviour
{
    
    public RaycastHit2D[] hitsNorth;
    public RaycastHit2D[] hitsSouth;
    public RaycastHit2D[] hitsWest; 
    public RaycastHit2D[] hitsEast;
    public int Length;
    public GameObject Fire;
    public DWallManager dWallManager;

    [Client]    
    void Start()
    {

        hitsNorth = Physics2D.RaycastAll(transform.position, Vector2.up, Length);
        hitsSouth = Physics2D.RaycastAll(transform.position, Vector2.down, Length);
        hitsWest = Physics2D.RaycastAll(transform.position, Vector2.left, Length);
        hitsEast = Physics2D.RaycastAll(transform.position, Vector2.right, Length);

        CheckHit(hitsNorth);
        CheckHit(hitsSouth);
        CheckHit(hitsWest);
        CheckHit(hitsEast);

        GameObject.Find("Dwalls").GetComponent<DWallManager>().RemoveFromList(transform.position.x - 0.5f, transform.position.y - 0.5f);

        NetworkServer.Destroy(transform.parent.gameObject);
        Destroy(transform.parent.gameObject);
        Debug.Log("Explosion");
        

    }

    [Client]
    private void CheckHit(RaycastHit2D[] hitsNorth)
    {
        foreach (RaycastHit2D hit in hitsNorth)
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                hit.transform.gameObject.GetComponent<PlayerStats>().Death();
            }
            else if (hit.transform.gameObject.tag == "Air")
            {

                GameObject fire = Instantiate(Fire, hit.transform.position, Quaternion.identity);
                NetworkServer.Spawn(fire);

            }
            else if (hit.transform.gameObject.tag == "Destructible")
            {

                GameObject.Find("Dwalls").GetComponent<DWallManager>().RemoveFromList(hit.transform.position.x - 0.5f, hit.transform.position.y - 0.5f);
                NetworkServer.Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.gameObject.tag == "Wall")
            {

                return;
            }

        }
    }

}
