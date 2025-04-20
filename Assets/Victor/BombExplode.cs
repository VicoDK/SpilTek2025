using UnityEngine;
using System.Collections;
using System.Drawing;
using Color = UnityEngine.Color;

public class BomExplode : MonoBehaviour
{
    public float[] countdown;
    public SpriteRenderer spriteRenderer;
    public GameObject Explosion;
    [HideInInspector] public GameObject Player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Explode());
        GameObject.Find("Dwalls").GetComponent<DWallManager>().ADDToList(transform.position.x-0.5f, transform.position.y-0.5f);
    }

    public IEnumerator Explode()
    {
       for (int i = 0; i < countdown.Length; i++)
        {

            yield return new WaitForSeconds(countdown[i]);
            if (spriteRenderer.color == Color.black)
            {
                spriteRenderer.color = Color.red;
            }
            else
            {
                spriteRenderer.color = Color.black;
            }
        }
        Player.GetComponent<PlayerControls>().isAttacking = false;
        Explosion.SetActive(true);
        
    }
}
