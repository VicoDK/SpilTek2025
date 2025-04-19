using System;
using System.ComponentModel.Design;
using UnityEngine;

public enum dir
{
    North,
    South,
    West,
    East
}
public class Explosion : MonoBehaviour
{
    
    public RaycastHit2D[] hitsNorth;
    public RaycastHit2D[] hitsSouth;
    public RaycastHit2D[] hitsWest; 
    public RaycastHit2D[] hitsEast;
    public int Length;
    public GameObject Fire;

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

    }

    private void CheckHit(RaycastHit2D[] hitsNorth)
    {
        foreach (RaycastHit2D hit in hitsNorth)
        {
            if (hit.transform.gameObject.tag == "Player")
            {
                Instantiate(Fire, hit.transform.position, Quaternion.identity);
                hit.transform.gameObject.GetComponent<PlayerStats>().Death();
            }
            else if (hit.transform.gameObject.tag == "Air")
            {
                Instantiate(Fire, hit.transform.position, Quaternion.identity);

            }
            else if (hit.transform.gameObject.tag == "Destructible")
            {

                Destroy(hit.transform.gameObject);
            }
            else if (hit.transform.gameObject.tag == "Wall")
            {
                
                return;
            }

        }
    }
}
