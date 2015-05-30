using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float damage = 10f;
    public float timeToLive = 5f;
    public float velocity = 500;
    public GameObject explosion;

    private SpriteRenderer sprite;
    private TrailRenderer trail;
    private float startTime;

	void Start ()
    {
        startTime = Time.time;
        sprite = GetComponent<SpriteRenderer>();
        trail = GetComponent<TrailRenderer>();
        
        //Add Force
        Vector2 direction = Quaternion.Euler(0, 0, transform.eulerAngles.z) * Vector2.up;
        GetComponent<Rigidbody2D>().AddForce(direction * velocity);
	}
	
	void FixedUpdate()
    {
        FadeOut();

        if (sprite.color.a <= 0)
            Destroy(gameObject);
    }

    void FadeOut()
    {
        float t = (Time.time - startTime) / timeToLive;
        Color color = sprite.color;
        color.a = Mathf.SmoothStep(1.0f, 0.0f, t);
        sprite.color = color;
        trail.material.color = color;
    }

    void Destroy()
    {
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") /*&& collision.transform.parent.name != transform.name*/)
        {
            collision.gameObject.SendMessage("affectLife", -damage);
            Destroy();
        }
    }
}
