using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    public Collider2D standingCollider;
    public Transform groundCheckCollider;
    public Transform overheadCheckCollider;
    public LayerMask groundLayer;
    public Transform wallCheckCollider;
    public LayerMask wallLayer;
    private Vector3 respawnPosition;
    public GameObject blood;
    private bool allowRestart = false;
    PlayerControls controls;
    

    

    const float groundCheckRadius = 0.2f;
    const float overheadCheckRadius = 0.2f;
    const float wallCheckRadius = 0.2f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpPower =500;
    [SerializeField] float slideFactor = 0.2f;
    public int totalJumps;
    int availableJumps;
    float horizontalValue;
    float runSpeedModifier = 2f;
    
    bool isGrounded=true;    
    bool isRunning;
    bool facingRight = true;
    bool multipleJump;
    bool coyoteJump;
    bool isSliding;
    bool isDead = false;
    bool isFrozen = false;


    void Awake()
    {
        availableJumps = totalJumps;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

         controls = new PlayerControls();
        controls.Land.Move.performed += ctx => Move(ctx.ReadValue<float>());
        controls.Land.Jump.performed += ctx => Jump();
    }

    public void Run()
    {
        isRunning = true;
    }

    public void StopRun()
    {
        isRunning = false;
    }

    void Update()
    {
        

        if (CanMoveOrInteract()==false)
            return;

       
        horizontalValue = Input.GetAxisRaw("Horizontal");
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
            isRunning = true;
       
        if (Input.GetKeyUp(KeyCode.LeftShift))
            isRunning = false;

        
       
       if (isDead == true)
       {   
           allowRestart = GameManager.Instance.gameOverPanel.activeSelf;
            isFrozen = true;
            if (allowRestart == true)
            {
                if(Input.GetKeyDown(KeyCode.R))
                {
                 GameManager.Instance.PlayerDiedAndRespawn();
                    RespawnAndReset();
                    isDead = false;
                    isFrozen = false;
                }
            }
            else
            {
              isFrozen = false;
            }
           
       }

       

       
        WallCheck();
    }

    void FixedUpdate()
    {
        GroundCheck();
        Move(controls.Land.Move.ReadValue<float>());       
    }

    void OnEnable()
{
    controls.Enable();
}

void OnDisable()
{
    controls.Disable();
}


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheckCollider.position, groundCheckRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(overheadCheckCollider.position, overheadCheckRadius);
    }

    bool CanMoveOrInteract()
    {
        bool can = true;

        if (FindObjectOfType<InteractionSystem>().isExamining)
            can = false;
        if (FindObjectOfType<InventorySystem>().isOpen)
            can = false;
        if (isDead)
            can = false;

        return can;
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                multipleJump = false;

                //AudioManager.instance.PlaySFX("landing");
            }        
            
            foreach(var c in colliders)
            {
                if (c.tag == "MovingPlatform")
                    transform.parent = c.transform;
            }
        }    
        else
        {
            transform.parent = null;

            if (wasGrounded)
                StartCoroutine(CoyoteJumpDelay());
        }

        animator.SetBool("Jump", !isGrounded);
    }

    void WallCheck()
    {
        if (Physics2D.OverlapCircle(wallCheckCollider.position, wallCheckRadius, wallLayer)
            && Mathf.Abs(horizontalValue) > 0
            && rb.velocity.y < 0
            && !isGrounded)
        {
            if(!isSliding)
            {
                availableJumps = totalJumps;
                multipleJump = false;
            }

            Vector2 v = rb.velocity;
            v.y = -slideFactor;
            rb.velocity = v;
            isSliding = true;

            if(Input.GetButtonDown("Jump"))
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
            }
        }
        else
        {
            isSliding = false;
        }
    }

    #region Jump
    IEnumerator CoyoteJumpDelay()
    {
        coyoteJump = true;
        yield return new WaitForSeconds(0.2f);
        coyoteJump = false;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;

            rb.velocity = Vector2.up * jumpPower;
            animator.SetBool("Jump", true);
            AudioManager.Instance.PlaySFX("Jump");
        }
        else
        {
            if(coyoteJump)
            {
                multipleJump = true;
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
                AudioManager.Instance.PlaySFX("Jump");
            }

            if(multipleJump && availableJumps>0)
            {
                availableJumps--;

                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump", true);
                AudioManager.Instance.PlaySFX("Jump");
            }
        }
    }
    #endregion

    public void Move(float dir)
    {
        if (isFrozen)
        return;

        #region Move & Run
      
        float xVal = dir * speed * 100 * Time.fixedDeltaTime;
        
        if (isRunning)
            xVal *= runSpeedModifier;
      
        
        Vector2 targetVelocity = new Vector2(xVal, rb.velocity.y);
       
        rb.velocity = targetVelocity;
 
       
      if (facingRight && dir < 0)
    {
        transform.localScale = new Vector3(-1, 1, 1);
        facingRight = false;
    }
    else if (!facingRight && dir > 0)
    {
        transform.localScale = new Vector3(1, 1, 1);
        facingRight = true;
    }
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        #endregion
    }   
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            isDead = true;
            Instantiate (blood, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            GameManager.Instance.PlayerDiedAndRespawn();
            AudioManager.Instance.PlaySFX("Death");
        }


        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            isDead = true;
            Instantiate (blood, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            AudioManager.Instance.PlaySFX("Death");
            GameManager.Instance.PlayerDiedAndRespawn();
           
        }
    }

    

    public void RespawnAndReset()
    {
        Vector3 respawnPosition = GameManager.Instance.GetLastCheckpointPosition();
        rb.velocity = Vector2.zero;
        transform.position = respawnPosition;
        isDead = false;
        isFrozen = false;
        rb.isKinematic = false;
        isRunning = false;
    }

}





