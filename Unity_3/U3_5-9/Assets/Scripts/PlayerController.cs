using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float PlayerMovement = 20f;
    public float JumpForce = 400f;
    public float HorizontalMove; // !!
    private bool jump = false;
    private Rigidbody2D rb;

    // private string _className = "Player";
    // private int _health;
    // private int _strength;
    // private int _agility;
    // private int _intelligence;
    // private int _damage;
    // private bool _shoot;

    private IClass _class;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        SetupClass<BaseWarrior>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMove = Input.GetAxis("Horizontal") * PlayerMovement;

        if(HorizontalMove < 0){
            transform.localEulerAngles = new Vector3(0, 180, 0); 
        }

        if(HorizontalMove > 0) {
            transform.localEulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetButtonDown("Jump")) jump = true;
    }

    private void Moving(float movement, bool canJump)
    {
        rb.velocity = new Vector2(movement * PlayerMovement * Time.deltaTime, rb.velocity.y);

        if (canJump && GetComponent<CircleCollider2D>().IsTouchingLayers())
        {
            rb.AddForce(new Vector2(0, JumpForce));
            jump = false;
        }
    }

    private void FixedUpdate()
    {
        Moving(HorizontalMove, jump);
    }

    void SetupClass<T>()
    {
        if (!GetComponent<T>())
        {
            _class = gameObject.AddComponent<T>();
            // _className = _class.ClassName;
            // _health = _class.Health;
            // _strength = _class.Strength;
            // _intelligence = _class.Intelligence;
            // _agility = _class.Agility;
            // _damage = _class.Damage;
        }
    }
}
