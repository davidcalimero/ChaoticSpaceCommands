using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

	public string fireButton = "b";
    public float fallBackForce = 25;
    public GameObject bullet;
    private Transform shootPoint;
    private Rigidbody2D physics;
	
	void Start ()
    {
        shootPoint = transform.FindChild("ShootPoint");
        physics = GetComponent<Rigidbody2D>();
    }

	void Update ()
    {
        if (Input.GetKeyUp(fireButton))
        {
            fire();
        }
	}

    void fire()
    {
        //Add back force
        Vector2 direction = Quaternion.Euler(0, 0, transform.eulerAngles.z) * -Vector2.up;
        physics.AddForce(direction * fallBackForce);

        //Instantiate bullet
        Instantiate(bullet, shootPoint.position, transform.rotation);
    }
}
