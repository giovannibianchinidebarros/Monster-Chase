using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private Rigidbody2D myBody;
    private Animator anim;
    private SpriteRenderer sr;

    private string walk_animation = "Walk";

    private float movementX;
    private bool isGrounded = true;
    private string ground_tag = "Ground";
    private string enemy_tag = "Enemy";

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
        PlayerJump();
    }

    void FixedUpdate()
    {

    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(walk_animation, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(walk_animation, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(walk_animation, false);
        }

    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(ground_tag))
        {
            isGrounded = true;
        }
        if (collision.gameObject.CompareTag(enemy_tag))
        {
            Destroy(gameObject);
        }
    }


} // class Player
