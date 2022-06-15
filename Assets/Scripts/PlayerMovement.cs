using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField]
  private float speed = 0.1f;

  [SerializeField]
  private float jumpForce = 5f;

  [SerializeField]
  private LayerMask groundLayer = default;

  [SerializeField]
  private Transform groundCheck = default;

  private Rigidbody2D rgbd = null;
  private Animator animator = null;
  private CapsuleCollider2D bodyCollider = null;
  private PlayerSound playerSound = null;
  private GameInputAction gameInputAction = null;
  private float horizontal = 0f;
  private float restartTime = 0f;
  private bool isGround = false;
  private bool isJump = false;
  private bool canPlayFallOnGround = false;
  private bool isAttack = false;
  private bool isDeath = false;

  // Start is called before the first frame update
  private void Start()
  {
    rgbd = GetComponent<Rigidbody2D>();
    animator = GetComponent<Animator>();
    bodyCollider = GetComponent<CapsuleCollider2D>();
    playerSound = GetComponent<PlayerSound>();
    gameInputAction = new GameInputAction();
    gameInputAction.Player.Enable();
    gameInputAction.Player.Jump.performed += JumpPerformed;
    gameInputAction.Player.Attack.performed += AttackPerformed;
  }

  private void AttackPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    if (obj.performed == true && isGround == true && Mathf.Approximately(horizontal, 0f))
    {
      isAttack = true;
    }
  }

  private void JumpPerformed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
  {
    if (obj.performed == true && isGround == true)
    {
      isJump = true;
    }
  }

  private void OnDestroy()
  {
    gameInputAction.Player.Jump.performed -= JumpPerformed;
    gameInputAction.Player.Attack.performed -= AttackPerformed;
  }

  // Update is called once per frame
  private void Update()
  {
    if (isDeath == true)
    {
      if (restartTime < 2f)
      {
        restartTime += Time.deltaTime;
      }
      else
      {
        SceneManager.LoadScene("Game");
      }

      return;
    }

    Vector2 movement = gameInputAction.Player.Movement.ReadValue<Vector2>();
    horizontal = Mathf.Round(movement.x);

    //horizontal = Input.GetAxisRaw("Horizontal");

    //if (Input.GetKeyDown(KeyCode.Z) && isGround == true)
    //{
    //  isJump = true;
    //}
    //if (Input.GetKeyDown(KeyCode.X) && isGround == true && Mathf.Approximately(horizontal, 0f))
    //{
    //  isAttack = true;
    //}

    Flip();
    Attack();
  }

  private void FixedUpdate()
  {
    if (isDeath == true)
    {
      return;
    }

    CheckIsGround();
    Run();
    Jump();
    Fall();
    FallOnGround();
  }

  private void CheckIsGround()
  {
    if (groundCheck.gameObject.activeSelf)
    {
      RaycastHit2D raycast = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.3f, groundLayer.value);
      Debug.DrawRay(groundCheck.position, Vector2.down * 0.3f, Color.red);

      if (raycast.collider != null)
      {
        isGround = true;
      }
      else
      {
        isGround = false;
      }
    }
    else
    {
      isGround = false;
    }
  }

  private void Run()
  {
    transform.position += new Vector3(horizontal * speed * Time.deltaTime, 0f, 0f);
    if (isGround)
    {
      animator.SetInteger("Run", (int)Mathf.Abs(horizontal));
    }
  }

  private void Jump()
  {
    if (isJump && isGround)
    {
      rgbd.velocity = new Vector2(rgbd.velocity.x, jumpForce);
      animator.Play("Jump");
      playerSound.Play(PlayerSound.Clips.Jump);
      isJump = false;
    }
  }

  private void Fall()
  {
    if (rgbd.velocity.y <= 0 && isGround == false)
    {
      if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fall") == false)
      {
        animator.SetTrigger("Fall");
      }

      canPlayFallOnGround = true;
    }
  }

  private void FallOnGround()
  {
    if (canPlayFallOnGround == true && isGround == true)
    {
      animator.Play("FallOnGround");
      playerSound.Play(PlayerSound.Clips.Land);
      canPlayFallOnGround = false;
    }
  }

  private void Attack()
  {
    if (isAttack == true && isGround == true)
    {
      animator.SetTrigger("Attack");
      isAttack = false;
    }
  }

  private void Flip()
  {
    if (horizontal != 0)
    {
      transform.localScale = new Vector2(horizontal, transform.localScale.y);
    }
  }

  public void Death()
  {
    if (isDeath == false)
    {
      isDeath = true;
      rgbd.gravityScale = 0f;
      bodyCollider.enabled = false;
      animator.SetTrigger("Death");
      playerSound.Play(PlayerSound.Clips.Death);
    }
  }

  public bool CheckPlayerDeath()
  {
    return isDeath;
  }
}
