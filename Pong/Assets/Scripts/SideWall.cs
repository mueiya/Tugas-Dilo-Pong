using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    public PlayerControl player;
    [SerializeField]
    private GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D anotherCollider)
    {
        if (anotherCollider.name == "Ball")
        {
            // Tambahkan skor ke pemain
            player.IncrementScore();

            // Jika skor pemain belum mencapai skor maksimal...
            if (player.Score < gameManager.maxScore)
            {
                // ...restart game setelah bola mengenai dinding.
                anotherCollider.gameObject.SendMessage("RestartGame", 2.0f, SendMessageOptions.RequireReceiver);
            }
        }
    }
}
