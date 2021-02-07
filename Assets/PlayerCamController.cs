using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamController : MonoBehaviour
{
    public Transform mTarget;

    public Vector3 mOffset;
    public float mZoomSpeed = 400f;
    public float mMinZoom = 5f;
    public float mMaxZoom = 15f;
    public float mYawSpeed = 100f;

    public float mCurrentZoom = 8f;
    public float mCurrentYaw = 0f;
    public float mPitch = 2f;


    private void Update()
    {
        mCurrentZoom -= Input.GetAxis("Mouse ScrollWheel") * mZoomSpeed * Time.deltaTime;
        mCurrentZoom = Mathf.Clamp(mCurrentZoom, mMinZoom, mMaxZoom);
        mCurrentYaw -= Input.GetAxis("Mouse X") * mYawSpeed * Time.deltaTime;
    }


    void LateUpdate()
    {
        transform.position = mTarget.position + mOffset * mCurrentZoom;
        transform.LookAt(mTarget.position + Vector3.up * mPitch);
        transform.RotateAround(mTarget.position, Vector3.up, mCurrentYaw);
    }
}
