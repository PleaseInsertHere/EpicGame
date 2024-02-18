using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReferenceToMap : MonoBehaviour
{
    // Reference to the MapManager script
    public MapManager mapManager;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get collision status from MapManager
            bool collisionStatus = mapManager.GetTileCollision(transform.position);

            // Print collision status
            Debug.Log("Collision status at player position is " + collisionStatus);
        }
    }
}
