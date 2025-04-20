using UnityEngine;

public class FireDisapere : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Disapere", 0.5f);
    }

    void Disapere()
    {
        Destroy(gameObject);
    }

}
