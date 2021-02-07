using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float comboTolerance = 0.5F;
    private const float GRAVITY_VALUE = -9.81f;

    private CharacterController charController;
    private Animator animator;

    private float currentComboAcc = 0.0F;
    private Vector3 playerVelocity;
    private bool isGround;
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

        tryPlayAniamtion();

        tryMove();

        tryJump();

        updateValue();
    }

    void tryPlayAniamtion()
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

        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));

    }


    void checkIsGround()
    {
        isGround = charController.isGrounded;
        if (isGround && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
    }

    void tryMove()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charController.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            animator.SetFloat("speed", move.magnitude);
        }

    }

    void tryJump()
    {
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && isGround)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * GRAVITY_VALUE);
        }
    }

    void updateValue()
    {
        playerVelocity.y += GRAVITY_VALUE * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);
    }
}
