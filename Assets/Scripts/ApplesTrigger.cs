using UnityEngine;
using UnityEngine.Tilemaps;

public class ApplesTrigger : MonoBehaviour
{
    private Tilemap tilemap;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Vector3Int cellPosition = tilemap.WorldToCell(collision.transform.position);

            tilemap.SetTile(cellPosition, null);
            tilemap.SetTile(cellPosition + Vector3Int.up, null);
            tilemap.SetTile(cellPosition + Vector3Int.down, null);
            tilemap.SetTile(cellPosition + Vector3Int.left, null);
            tilemap.SetTile(cellPosition + Vector3Int.right, null);
        }
    }
}