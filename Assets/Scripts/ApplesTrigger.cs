using UnityEngine;
using UnityEngine.Tilemaps;

public class ApplesTrigger : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    private Tilemap tilemap;
    private AudioSource audioSource;

    private void Start()
    {
        tilemap = GetComponent<Tilemap>();
        audioSource = GetComponent<AudioSource>();

        if (player == null)
        {
            player = FindFirstObjectByType<PlayerMovement>();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player == null)
            {
                player = FindFirstObjectByType<PlayerMovement>();
            }

            if (player != null)
            {
                player.AddPoints(1);
            }
            Vector3Int cellPosition = tilemap.WorldToCell(collision.transform.position);

            audioSource.PlayOneShot(audioSource.clip);

            tilemap.SetTile(cellPosition, null);
            tilemap.SetTile(cellPosition + Vector3Int.up, null);
            tilemap.SetTile(cellPosition + Vector3Int.down, null);
            tilemap.SetTile(cellPosition + Vector3Int.left, null);
            tilemap.SetTile(cellPosition + Vector3Int.right, null);
        }
    }
}