using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject ShootPrefab;
    public int AmmoAmount = 50;
    public int CurrentAmmo = 0;
    public float speed = 10f;
    private Vector3 shootDirection;
    private bool round = false;
    
    // Start is called before the first frame update
    void Start()
    {
        round = true;
        CurrentAmmo = AmmoAmount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && round)
        {
            round = false;
            StartCoroutine(Shoot());
        }
        if (round)
        {
            Debug.DrawLine(shootDirection + transform.position, transform.position);
            shootDirection = Input.mousePosition;
            shootDirection.z = 0;
            shootDirection = Camera.main.ScreenToWorldPoint(shootDirection);
            shootDirection -= transform.position;
        }
        if (transform.childCount <= 0 && !round)
        {
            round = true;
            CurrentAmmo = AmmoAmount;
        }
    }
    IEnumerator Shoot()
    {
        for (int i = 0; i < AmmoAmount; i++)
        {
            var bullet = Instantiate(ShootPrefab, transform.position, Quaternion.identity, transform);
            Vector2 force = new Vector2(shootDirection.x, shootDirection.y).normalized * 3 * speed;
            bullet.GetComponent<Rigidbody2D>().velocity = force;
            CurrentAmmo--;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
