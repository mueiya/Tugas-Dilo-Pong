using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;

    void Start ()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        // Mulai game
        RestartGame();
        trajectoryOrigin = transform.position;
    }
    void ResetBall()
    {
        transform.position = Vector2.zero;
        rigidBody2D.velocity = Vector2.zero;
    }
    void PushBall()
    {
        // Tentukan nilai komponen y dari gaya dorong antara -yInitialForce dan yInitialForce
        float yRandom = Random.Range(0, 2);
        float yRandomInitialForce = 0.0f;
        if (yRandom < 1.0f)
        {
            yRandomInitialForce = yInitialForce;
        }
        else
        {
            yRandomInitialForce = -yInitialForce;
        }

        // Tentukan nilai acak antara 0 (inklusif) dan 2 (eksklusif)
        float randomDirection = Random.Range(0, 2);

        // Jika nilainya di bawah 1, bola bergerak ke kiri. 
        // Jika tidak, bola bergerak ke kanan.
        if (randomDirection < 1.0f)
        {
            // Gunakan gaya untuk menggerakkan bola ini.
            rigidBody2D.AddForce(new Vector2(-xInitialForce, yRandomInitialForce));
        }
        else
        {
            rigidBody2D.AddForce(new Vector2(xInitialForce, yRandomInitialForce));
        }
    }
    void RestartGame()
    {
        // Kembalikan bola ke posisi semula
        ResetBall();

        // Setelah 2 detik, berikan gaya ke bola
        Invoke("PushBall", 2);
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
