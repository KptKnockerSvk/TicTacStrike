using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControll : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float howClose;
    public Transform head, barrel;
    public GameObject _projectile;
    public int forcePower;
    public float fireRate, nextFire;
    [SerializeField] AudioSource shootin;


    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(_Player.position, transform.position);
        if (dist <= howClose)
        {
            head.LookAt(_Player);
            if(Time.time >= nextFire)
            {
                nextFire = Time.time + 1f / fireRate;
                shoot();
            }
            
        }
    }

    void shoot()
    {
        shootin.Play();
        GameObject clone = Instantiate(_projectile, barrel.position, head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(head.forward * forcePower);
        Destroy(clone, 10);
    }
}
