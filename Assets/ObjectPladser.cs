using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ObjectPladser : MonoBehaviour
{
    public GameObject[] Object; // The prefab to instantiate at each tile
    public Tilemap[] tilemap; // Reference to the Tilemap component

    void Start()
    {
        for (int i = 0; i < tilemap.Length; i++)
        {
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
                TileBase tile = tilemap[index].GetTile(new Vector3Int(x, y, 0));

                if (tile != null)
                {
                    Vector3 worldPosition = tilemap[index].GetCellCenterWorld(new Vector3Int(x, y, 0));
                    Instantiate(Object[index], worldPosition, Quaternion.identity, this.transform);
                    if (Object[index].name == "DWall")
                    {
                        tilemap[index].GetComponent<DWallManager>().ADDToList(new Vector2(x, y), Object[index]);
                    }

                 
                }
            }
        }
    }

}