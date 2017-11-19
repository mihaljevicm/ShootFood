using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
	public Transform ProjectileParent;
	public GameObject[] Projectile;
    private int _currentProjectile = 0;
    private int _numberOfProj = 0;

	public List<Transform> FirePoints;

	public float Force = 10.0f;



	void Update()
	{
        ChangeProjectile();

		if (Input.GetButtonDown ("Fire1")) 
		{
			foreach (Transform firePoint in FirePoints) 
			{
				ShootProjectile (firePoint);
			}
		}
	}

    private void ChangeProjectile()
    {
        _numberOfProj = Projectile.Length;
        if(Input.GetAxis("Mouse ScrollWheel")>0)
        {
            if (_currentProjectile == (_numberOfProj-1))
                _currentProjectile = 0;
            else
                _currentProjectile += 1;

        }
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            if (_currentProjectile == 0)
                _currentProjectile = _numberOfProj - 1;
            else
                _currentProjectile -= 1;
        }
        if ((_currentProjectile > _numberOfProj) || (_currentProjectile < 0))
            _currentProjectile = 0;
        Debug.Log("current wepon: "+_currentProjectile);
    }

	private void ShootProjectile(Transform firePoint)
	{
		GameObject projectileClone = Instantiate (Projectile[_currentProjectile], firePoint.position, Quaternion.identity);
		projectileClone.transform.SetParent (ProjectileParent);

		Rigidbody projectileRigidbody = projectileClone.GetComponent<Rigidbody> ();
		projectileRigidbody.AddForce (transform.forward * Force, ForceMode.VelocityChange);
	}
}
