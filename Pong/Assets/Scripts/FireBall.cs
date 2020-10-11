using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public ItemSpawner spawner;
    public BallControl ball;

    void OnTriggerEnter2D(Collider2D collision)
    {
        BallControl ball = collision.gameObject.GetComponent<BallControl>();
        if (ball)
        {
            ball.fireBall();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(gameObject);
        spawner.RandomTime();
    }
}
