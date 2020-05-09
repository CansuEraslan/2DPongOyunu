using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2;
    public float moveSpeed = 10;
    public racket solRacket, sagRacket;
    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector2(1, 0) * moveSpeed;
    }

    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TagManager tagmanager = collision.gameObject.GetComponent<TagManager>();
        GetComponent<AudioSource>().Play();
        if (tagmanager == null) return ;
        Tag tag = tagmanager.mytag;
        if (tag.Equals(Tag.SAG_DUVAR))
        {
            //sol skor
            solRacket.SkorYap();
        }
        else if (tag.Equals(Tag.SOL_DUVAR))
        {
            //sag skor
            sagRacket.SkorYap();

        }
        if(tag.Equals(Tag.SAG_RAKET))
        {
            DonusYonHesapla(collision, -1);
        }
        else if(tag.Equals(Tag.SOL_RAKET))
        {
            DonusYonHesapla(collision, 1);
        }
    }
    private void DonusYonHesapla(Collision2D collision,int x)
    {
        float a = transform.position.y-collision.gameObject.transform.position.y;
        float b = collision.collider.bounds.size.y;
        float y = a / b;
        rb2.velocity = new Vector2(x, y) * moveSpeed;
    }
}
