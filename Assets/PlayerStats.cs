using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public void Death()
    {
        Debug.Log("Player has died.");
        Destroy(gameObject); 
    }
}
