using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DWallManager : MonoBehaviour
{ 
    public bool[,]  DWallList = new bool[1000, 1000]; 

    public bool Contains(int X, int Y)
    {

        if (DWallList[X+20, Y+20] == true)
            return true;
        return false;
    }


    public void ADDToList(int X, int Y)
    {

        DWallList[X+20, Y+20] = true;
    }
    public void ADDToList(float X, float Y)
    {

        DWallList[(int)X+20, (int)Y+20] = true;
    }

    public void RemoveFromList(float X, float Y)
    {

        DWallList[(int)X+20, (int)Y+20] = false;
    }


}
