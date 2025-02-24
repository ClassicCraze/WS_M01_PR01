using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 75f;
    public float jumpVelocity = 5f;
    public float distanceToGround = 0.1f;
    public LayerMask groundLayer;

    public bool doShoot;

    private bool doJump;

    // 1
    public GameObject bullet;
    public float bulletSpeed = 100f;

    private float vInput;
    private float hInput;
    private Rigidbody _rb;
    private CapsuleCollider _col;
    private GameBehavior _gameManager;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameBehavior>();
    }

    void Update()
    {
        vInput = Input.GetAxis("Vertical") * moveSpeed;
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        if (Input.GetMouseButtonDown(0))
            doShoot = true;
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)){
            doJump = true;
            /* do the if statement and a bool */
        }

    }

    void FixedUpdate()
    {
        // 5  // if the bool is true
        if (doJump)
        {
            _rb.AddForce(Vector3.up * jumpVelocity,
                ForceMode.Impulse);
            doJump = false;
        }
        Vector3 rotation = Vector3.up * hInput;

        Quaternion angleRot = Quaternion.Euler(rotation *
            Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position +
            this.transform.forward * vInput * Time.fixedDeltaTime);

        _rb.MoveRotation(_rb.rotation * angleRot);

        // 2
        if (doShoot)
        {
            // 3
            doShoot = false;
            GameObject newBullet = Instantiate(bullet,
               this.transform.position + this.transform.right,
                  this.transform.rotation) as GameObject;

            // 4
            Rigidbody bulletRB =
                newBullet.GetComponent<Rigidbody>();

            // 5
            bulletRB.velocity = this.transform.forward *
                                           bulletSpeed;
        }
    }

    // 6
    private bool IsGrounded()
    {
        // 7
        Vector3 capsuleBottom = new Vector3(_col.bounds.center.x,
            _col.bounds.min.y, _col.bounds.center.z);

        // 8
        bool grounded = Physics.CheckCapsule(_col.bounds.center,
           capsuleBottom, distanceToGround, groundLayer,
              QueryTriggerInteraction.Ignore);

        // 9
        return grounded;
    }
    void OnCollisionEnter(Collision collision)
     {
         // 4
         if(collision.gameObject.name == "Enemy")
         {
             // 5
             _gameManager.HP -= 1;
         }
     }


     private float speedMultiplier;

    public void BoostSpeed(float multiplier, float seconds)
    {
        speedMultiplier = multiplier;
        moveSpeed *= multiplier;
        Invoke("EndSpeedBoost", seconds);
    }

    private void EndSpeedBoost()
    {
        Debug.Log("Speed boost has ended.");
        moveSpeed /= speedMultiplier;
    }
}