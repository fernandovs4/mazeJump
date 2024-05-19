using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleTilemap : MonoBehaviour
{
    public Tilemap tilemap;
    private TileBase destroyedTile = null; // Tile to replace the destroyed tile (optional)

    void Start()
    {
        if (tilemap == null)
        {
            tilemap = GetComponent<Tilemap>();
        }
    }

void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.tag == "Player")
    {
        Vector3Int gridPosition = tilemap.WorldToCell(other.transform.position);
        if (tilemap.HasTile(gridPosition))
        {
            tilemap.SetTile(gridPosition, destroyedTile); // Replace with destroyed tile or use null to remove
        }
    }
}

}
