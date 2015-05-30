using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public float timeToLive = 1.5f;
    public float velocity = 400;

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
}
