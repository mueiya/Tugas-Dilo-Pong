using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public ItemSpawner spawner;
    public BallControl ball;

    void OnTriggerExit2D(Collider2D anotherCollider)
    {
        if (anotherCollider.name == "Ball")
        {
            spawner.RandomTime();
            ball.fireBall();
            Destroy(gameObject);
        }
    }
}
