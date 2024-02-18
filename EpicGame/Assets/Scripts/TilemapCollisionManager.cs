using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapColliderSetup : MonoBehaviour
{
    public Tilemap tilemap;
    public string wallTileName = "8dae278b-c353-4a1a-81fe-142df13ba11f"; // Name of your wall tile

    void Start()
    {
        SetupColliders();
    }

    void SetupColliders()
    {
        BoundsInt bounds = tilemap.cellBounds;

        foreach (var pos in bounds.allPositionsWithin)
        {
            if (tilemap.HasTile(pos))
            {
                TileBase tile = tilemap.GetTile(pos);
                if (tile.name == wallTileName)
                {
                    tilemap.SetColliderType(pos, Tile.ColliderType.Sprite);
                }
                else
                {
                    tilemap.SetColliderType(pos, Tile.ColliderType.None);
                }
            }
        }
    }
}
