using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public PlayerControl player1;
    public PlayerControl player2;
    public Rigidbody2D rigidBody2D;
    public float xInitialForce;
    public float yInitialForce;
    private Vector2 trajectoryOrigin;
    public bool fireball;

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
        // tidak secara random
        float yRandomInitialForce = yInitialForce;

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
        fireball = false;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }
    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
    //Add fireball
    public void fireBall()
    {
        fireball = true;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (fireball)
        {
            if (collision.gameObject.tag == "Player 1")
            {
                player2.FireBallWin();
            }
            if (collision.gameObject.tag == "Player 2")
            {
                player1.FireBallWin();
            }
        }
    }
}
