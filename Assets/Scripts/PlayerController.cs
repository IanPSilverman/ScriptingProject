using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private Collider2D _cldr;
    private float _groundCheckDistance = 0.1f;
    private bool _isGrounded = false;
    private bool _canPlayLandSound = false;
    private int _dynamicJumpCount;
    
    public float speed = 5.0f;
    public int initalJumpCount = 2;
    public float jumpForce = 5f;
    public int collectablesGet = 0;

    public PlayerSoundScript playerSoundSystem;
    public CoinGetter coinGetter;
    public SceneLoader sceneLoader;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _cldr = GetComponent<Collider2D>();
        _dynamicJumpCount = initalJumpCount;
    }

    private void FixedUpdate() 
    {
        checkGrounded();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collectablesGet++;
            playerSoundSystem.PlayerCollectSound();
            coinGetter.ChangeCoins(collectablesGet.ToString());

            if(collectablesGet ==  4)
            {
                sceneLoader.SwitchScene(2);
            }
        }

        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerSoundSystem.PlayerRandomHurtSound();
        }

        if(collision.gameObject.CompareTag("Projectile"))
        {
            playerSoundSystem.PlayerProjectileHitSound();
        }
    }

    private void checkGrounded() 
    {
        Bounds bounds = _cldr.bounds;
        Vector2 leftRayOrigin = new Vector2(bounds.min.x, bounds.min.y);
        Vector2 rightRayOrigin = new Vector2(bounds.max.x, bounds.max.y);

        RaycastHit2D hitLeft = Physics2D.Raycast(leftRayOrigin, Vector2.down, _groundCheckDistance, LayerMask.GetMask("Ground"));
        RaycastHit2D hitRight = Physics2D.Raycast(rightRayOrigin, Vector2.down, _groundCheckDistance, LayerMask.GetMask("Ground"));

        _isGrounded = hitLeft.collider != null || hitRight.collider != null;

        _animator.SetBool("_isJumping", !_isGrounded);

        /*
        if(_isGrounded && _canPlayLandSound)
        {
            playerSoundSystem.PlayerRandomLandSound();
            _canPlayLandSound = false;
        }

        if(!_isGrounded) 
        {
            _canPlayLandSound = true;
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        bool moveVertical = Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown("w");

        _rb.velocity = new Vector2(moveHorizontal * speed, _rb.velocity.y);

        flipCharacter(moveHorizontal);

        //Player jumping function
        if(moveVertical == true && _dynamicJumpCount > 0) {
            charJump();
        }
        else if(_dynamicJumpCount >= 0 && _isGrounded == true) {
            _dynamicJumpCount = initalJumpCount;
        }

        //Sets falling animation
        if (_rb.velocityY < 0)
        {
            _animator.SetBool("_isFalling", true);
            _animator.SetBool("_isJumping", false);
        }
        else
        {
            _animator.SetBool("_isFalling", false);
        }

        //Sets walking animation
        if (moveHorizontal != 0) {
            _animator.SetBool("_isWalking", true);
        }
        else {
            _animator.SetBool("_isWalking", false);
        }
    }

   /*  
    *  Alternative Sprite flip function
    *  
    *  void FlipSprite(float horizontalInput)
    {
        Vector3 scale = transform.localScale;
        scale.x = (horizontalInput > 0) ? 1 : -1;
        transform.localScale = scale;
    }
   */
    void charJump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, jumpForce);
        playerSoundSystem.playerJumpSound();
        _dynamicJumpCount--;  
    }


    void flipCharacter(float charVelocity)
    {
        if (charVelocity < 0)
        {
            _spriteRenderer.flipX = true;
        }
        else if(charVelocity > 0)
        {
            _spriteRenderer.flipX = false;
        }
    }
}