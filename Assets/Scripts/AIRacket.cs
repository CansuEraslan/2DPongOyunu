using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : racket
{
    public Transform ball;
    protected override void HareketEt()
    {
        float mesafe = Mathf.Abs(ball.position.y - transform.position.y);
        if (mesafe > 3)
        {
            if (ball.position.y > transform.position.y)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, 1) * moveSpeed;
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1) * moveSpeed;
            }
        }
    }
}
