using Mirror;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class ObjectPladser : NetworkBehaviour
{
    public GameObject[] Object; // The prefab to instantiate at each tile
    public Tilemap[] tilemap; // Reference to the Tilemap component

    public void Start()
    {
        for (int i = 0; i < tilemap.Length; i++)
        {
            Debug.Log("Tilemap: " + tilemap[i].name);
            InstantiatePoints(i);
        }


    }

    
    void InstantiatePoints(int index)
    {

        BoundsInt bounds = tilemap[index].cellBounds;

        for (int x = bounds.x; x < bounds.xMax; x++)
        {

            for (int y = bounds.y; y < bounds.yMax; y++)
            {
                if (index == 0)
                {
                    tilemap[index].GetComponent<DWallManager>().RemoveFromList(x, y);
                }
                TileBase tile = tilemap[index].GetTile(new Vector3Int(x, y, 0));

                if (tile != null)
                {
                    Vector3 worldPosition = tilemap[index].GetCellCenterWorld(new Vector3Int(x, y, 0));
                    GameObject obj = Instantiate(Object[index], worldPosition, Quaternion.identity, this.transform);
                    NetworkServer.Spawn(obj);
                    if (obj.name.Contains("DWall"))
                    {
                        obj.GetComponent<DWallInfo>().AddNumber(x, y);
                        tilemap[index].GetComponent<DWallManager>().ADDToList(x, y);
                    }

                 
                }
            }
        }
    }

}