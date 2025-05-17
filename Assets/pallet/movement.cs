using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;
using Mirror;
public class movement : NetworkBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    public DWallManager groundTilemapObject;
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
        if (!groundTilemap.HasTile(gridPosition) || collisionTilemap.HasTile(gridPosition) || groundTilemapObject.Contains(gridPosition.x, gridPosition.y))
            return false;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;

        if (collisionTilemap == null)
            collisionTilemap = GameObject.Find("Col").GetComponent<Tilemap>();

        if (groundTilemap == null)
            groundTilemap = GameObject.Find("ground").GetComponent<Tilemap>();

        if (groundTilemapObject == null)
            groundTilemapObject = GameObject.Find("Dwalls").GetComponent<DWallManager>();


        if (controls.actions.FindAction("movement").triggered)
        {
            Move(controls.actions.FindAction("movement").ReadValue<Vector2>());

        }
    }

    void Awake()
    {
        if (controls == null)
            controls = GetComponent<PlayerInput>();

        // Disable input for non-local players
        if (!isLocalPlayer && controls != null)
            controls.enabled = false;
    }

    public override void OnStartLocalPlayer()
    {
        if (controls == null)
            controls = GetComponent<PlayerInput>();
        controls.enabled = true;
    }


  
}
