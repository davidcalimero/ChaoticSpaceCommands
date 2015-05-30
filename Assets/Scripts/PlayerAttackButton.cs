using UnityEngine;
using System.Collections;

public class PlayerAttackButton : RandomButton {

    public float fallBackForce = 10;
    public GameObject bullet;
    private Transform shootPoint;
    private Rigidbody2D physics;


	void Update ()
    {
        if (Input.GetKeyUp(_key))
        {
            fire();
        }
	}

    void fire()
    {
        shootPoint = transform.FindChild("ShootPoint");
        physics = GetComponent<Rigidbody2D>();
        //Add back force
        Vector2 direction = Quaternion.Euler(0, 0, transform.eulerAngles.z) * -Vector2.up;
        physics.AddForce(direction * fallBackForce);

        //Instantiate bullet
        Instantiate(bullet, shootPoint.position, transform.rotation);
    }
}
