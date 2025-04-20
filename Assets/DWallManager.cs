using System.Collections.Generic;
using UnityEngine;

public class DWallManager : MonoBehaviour
{


    public bool[,]  DWallList;

    public bool Contains(int x, int y)
    {
        if (DWallList[x, y] == false)
            return true;
        return false;
    }


    public void ADDToList(int x, int y)
    {
        DWallList[x, y] = true;
    }
}
