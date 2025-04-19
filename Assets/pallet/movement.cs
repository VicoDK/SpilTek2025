using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
public class movement : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    public PlayerInput controls;

    private void Move(Vector2 direction)
    {
        if (CanMove(direction))
            transform.position += (Vector3)direction;
    }

    private bool CanMove(Vector2 direction)
    {
        Vector3Int gridPosition = groundTilemap.WorldToCell(transform.position + (Vector3)direction);
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition))
            return false;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (controls.actions.FindAction("movement").triggered)
        {
            Move(controls.actions.FindAction("movement").ReadValue<Vector2>());

        }
    }
}
