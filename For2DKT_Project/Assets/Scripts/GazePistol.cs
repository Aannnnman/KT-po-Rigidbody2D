using UnityEngine;

public class GazePistol : IGun
{
    private GameObject _bulletPrefab;
    private Transform _shootPoint;
    private float _shootPower;

    public GazePistol(GameObject bulletPrefab, Transform shootPoint, float shootPower)
    {
        _bulletPrefab = bulletPrefab;
        _shootPoint = shootPoint;
        _shootPower = shootPower;
    }

    public void Shoot()
    {
        GameObject bullet = Object.Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();

        bulletRigidbody.AddForce(_shootPoint.right * _shootPower, ForceMode2D.Impulse);
    }
}
