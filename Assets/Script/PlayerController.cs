using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    //0.5초 안에 공격하면 콤보를 이어나갈 수 있다.
    public float comboTolerance = 0.5F;
    private const float GRAVITY_VALUE = -9.81f;

    private CharacterController charController;
    private Animator animator;

    private float currentComboAcc = 0.0F;
    private Vector3 playerVelocity;
    private bool isGround = false;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        checkIsGround();

        tryPlayAttackAnim();

        tryMove();

        tryJump();

        applyGravity();
    }

    private void tryPlayAttackAnim()
    {

        currentComboAcc += Time.deltaTime;


        if (Input.GetMouseButtonDown(0))
        {

            if (currentComboAcc < comboTolerance)
            {
                animator.SetTrigger("is_combo");
                currentComboAcc = 0F;
                return;
            }

            animator.SetTrigger("basic_combo");
            currentComboAcc = 0F;

        }

    }


    private void checkIsGround()
    {
        isGround = charController.isGrounded;
        if (isGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    private  void tryMove()
    {
        

        Transform camTransfrom = Camera.main.GetComponent<Transform>();

        Vector3 look = camTransfrom.forward.normalized;
        look.y = 0;
        look.Normalize();

        Vector3 right = new Vector3(look.z, 0, -look.x);

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        Vector3 move = (look * v * playerSpeed * Time.deltaTime) +
                        (right * h * playerSpeed * Time.deltaTime);

        float movement = Mathf.Abs(v) + Mathf.Abs(h);
        if (movement > 0)
        {

            charController.Move(move);
            gameObject.transform.forward = move.normalized;

        }

        animator.SetFloat("speed", movement);

    }

    private void tryJump()
    {
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * GRAVITY_VALUE);
        }
    }

    private void applyGravity()
    {
        playerVelocity.y += GRAVITY_VALUE * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);
    }

    private bool isCurrentAnimationCancelable() {
        AnimatorStateInfo currentAnimState = animator.GetCurrentAnimatorStateInfo(0);
        return !currentAnimState.IsName("jump"); }


}
