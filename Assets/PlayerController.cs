using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    public float mComboTolerance = 0.5F;

    private const float GRAVITY_VALUE = -9.81f;

    private float mCurrentComboAcc = 0.0F;
    private CharacterController mCharController;
    private Animator mAnimator;
    private Vector3 mPlayerVelocity;
    private bool mIsGround;
    private float mPlayerSpeed = 2.0f;
    private float mJumpHeight = 1.0f;

    private Queue<string> mCommendQ = new Queue<string>();

    // Start is called before the first frame update
    void Start()
    {
        mCharController = GetComponent<CharacterController>();
        mAnimator = GetComponent<Animator>();
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

        mCurrentComboAcc += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Q))
        {

            if (mCurrentComboAcc < mComboTolerance)
            {
                mAnimator.SetTrigger("is_combo");
                mCurrentComboAcc = 0F;
                return;
            }

            mAnimator.SetTrigger("basic_combo");
            mCurrentComboAcc = 0F;

        }
    }


    void checkIsGround()
    {
        mIsGround = mCharController.isGrounded;
        if (mIsGround && mPlayerVelocity.y < 0)
        {
            mPlayerVelocity.y = 0f;
        }
    }

    void tryMove()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        mCharController.Move(move * Time.deltaTime * mPlayerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

    }

    void tryJump()
    {
        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && mIsGround)
        {
            mPlayerVelocity.y += Mathf.Sqrt(mJumpHeight * -3.0f * GRAVITY_VALUE);
        }
    }

    void updateValue()
    {
        mPlayerVelocity.y += GRAVITY_VALUE * Time.deltaTime;
        mCharController.Move(mPlayerVelocity * Time.deltaTime);
    }
}
