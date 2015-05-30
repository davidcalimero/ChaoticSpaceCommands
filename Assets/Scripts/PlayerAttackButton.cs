using UnityEngine;
using System.Collections;

public class PlayerAttackButton : RandomButton {

    public float fallBackForce = 10;
    public float reloadTime = 100;
    public GameObject bullet;
    private Transform shootPoint;
    private Rigidbody2D physics;
    private float reloadTimeTemp;


    void Awake()
    {
        reloadTimeTemp = reloadTime;
    }


	void Update ()
    {
        if (Input.GetKeyUp(_key) && reloadTimeTemp >= reloadTime)
        {
            Fire();
            reloadTimeTemp = 0;
        }
        reloadTimeTemp++;
	}

    void Fire()
    {
        shootPoint = transform.FindChild("ShootPoint");
        physics = GetComponent<Rigidbody2D>();
        //Add back force
        Vector2 direction = Quaternion.Euler(0, 0, transform.eulerAngles.z) * -Vector2.up;
        physics.AddForce(direction * fallBackForce);

        //Instantiate bullet
        GameObject bulletFired = Instantiate(bullet, shootPoint.position, transform.rotation) as GameObject;
        bulletFired.SendMessage("SetOwner", transform.name);
    }
}
