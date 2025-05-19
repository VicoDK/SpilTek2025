using System.Collections.Generic;
using Mirror;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DWallManager : NetworkBehaviour
{
    // Define a SyncDictionary for Vector2 and bool
    public class SyncDWallDict : SyncDictionary<Vector2, bool> { }

    // Make it a SyncVar so Mirror can sync it
    public SyncDWallDict DWallData = new SyncDWallDict();

    public bool Contains(int X, int Y)
    {

        if (DWallData[new Vector2(X+20, Y+20)] == true)
            return true;
        return false;
    }


    public void ADDToList(int X, int Y)
    {

        DWallData[new Vector2(X+20, Y+20)] = true;
    }
    public void ADDToList(float X, float Y)
    {

        DWallData[new Vector2(X+20, Y+20)] = true;
    }

    public void RemoveFromList(float X, float Y)
    {

        DWallData[new Vector2(X+20, Y+20)] = false;
    }


}
