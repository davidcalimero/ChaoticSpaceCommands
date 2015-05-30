using UnityEngine;
using System.Collections;

public class PlayerAttackButton : RandomButton {

    public float fallBackForce = 10;
    public float reloadTime = 100;
	public float bulletTime = 0.1f;
    public GameObject bullet;
    private Transform shootPoint;
    private Rigidbody2D physics;
    private float reloadTimeTemp;
	private bool canStarFire = true;


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

	void StarFire(){
		shootPoint = transform.FindChild("ShootPoint");
		physics = GetComponent<Rigidbody2D>();

		int shotsFired = 0;

		while (shotsFired < 11) {
			//Instantiate bullet
			if(canStarFire){
				Vector3 misdirection = Quaternion.Euler(0, 0, -36 * shotsFired) * transform.up;
				Debug.Log ("teste");
				GameObject bulletFired = Instantiate (bullet, transform.position + misdirection * 3, Quaternion.Euler(0, 0, -36 * shotsFired)) as GameObject;
				bulletFired.SendMessage ("SetOwner", transform.name);
				StartCoroutine("waitBulletTime");
				shotsFired++;
			}
		}
	}

	IEnumerator waitBulletTime(){
		canStarFire = false;
		yield return new WaitForSeconds (bulletTime);
		canStarFire = true;
	}
}
