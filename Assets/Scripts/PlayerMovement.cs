using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public float speed = 5.5f;
    public float jumpForce = 5.5f;

    private float horizontal;

    private Transform playerTransform;
    private Rigidbody2D rb;
    private Animator animator;

    public PlayableDirector director;

    //Detector del suelo
    public static bool isGrounded;
    public Transform groundSensor;
    public LayerMask ground;
    public float sensorRadius = 0.1f;
    public int saltoDoble = 1;
    
    

    void Awake()
    {

        playerTransform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    //
    void FixedUpdate()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        //El GetAxis hace que el movimiento sea un poco Smooth, para quitarlo deberiamos hacer GetAxisRaw, entonces es mas seco
        playerTransform.position += new Vector3(horizontal * speed * Time.deltaTime, 0, 0);
        

        if(horizontal == 0)
        {
            animator.SetBool("Correr", false);
        }
        else if (horizontal == 1)
        {
            animator.SetBool("Correr", true);
            playerTransform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if(horizontal == -1)
        {
            animator.SetBool("Correr", true);
            playerTransform.rotation = Quaternion.Euler(0, -180, 0);
        }
    }

    void Update ()
    {
        
       
        Jump();

        Global.nivel = 1;
        

    }
    
    
    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundSensor.position, sensorRadius, ground);
        if(Input.GetButtonDown("Jump") && isGrounded && saltoDoble == 1)
        {
            rb.AddForce(playerTransform.up * jumpForce);
            saltoDoble = 0;
            
        }
        else if (Input.GetButtonDown("Jump") && saltoDoble == 0)
        {
            rb.AddForce(playerTransform.up * jumpForce);
            saltoDoble = 1;
            
        }
    
        if(isGrounded)
        {
            animator.SetBool("Jump", false);
        }
        else{
            animator.SetBool("Jump", true);
        }

    }

    /*void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Cinematica")
        {
            director.Play();
        }
    }
    */
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "estrella")
        {
            Destroy(other.gameObject);
            GameManager.Instance.Estrella();
        }
    }
    

    public void Destroy()
    {
        Destroy(this);
    }
}
