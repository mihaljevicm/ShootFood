using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public Transform ProjectileParent;
	public GameObject Projectile;

	public List<Transform> FirePoints;

	public float Force = 10.0f;



	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			foreach (Transform firePoint in FirePoints) 
			{
				ShootProjectile (firePoint);
			}
		}
	}

	private void ShootProjectile(Transform firePoint)
	{
		GameObject projectileClone = Instantiate (Projectile, firePoint.position, Quaternion.identity);
		projectileClone.transform.SetParent (ProjectileParent);

		Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody> ();
		projectileRigidbody.AddForce (transform.forward * Force, ForceMode.VelocityChange);

	}
}
