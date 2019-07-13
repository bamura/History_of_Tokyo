using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// GameビューにてSceneビューのようなカメラの動きをマウス操作によって実現する
/// </summary>
[RequireComponent(typeof(Camera))]
public class MiniMapCameraScript : MonoBehaviour
{
    [SerializeField, Range(0.1f, 80f)]
    private float wheelSpeed = 80f; //ホイール回して拡大のスピード

    [SerializeField, Range(0.1f, 30f)]
    private float moveSpeed = 20f; //ホイール押して移動するスピード

    //[SerializeField, Range(0.1f, 5f)]
    //private float rotateSpeed = 0.5f; //右クリックで回すスピード

    private Vector3 preMousePos;
    private Vector3 camera_pos;

    private void Start()
    {
    }

    private void Update()
    {
        MouseUpdate();
        return;
    }

    private void MouseUpdate()
    {
        //カメラの移動範囲を制限する
        camera_pos = transform.position;
        camera_pos.y = Mathf.Clamp(camera_pos.y, 300f, 600f); //y座標を制限
        transform.position = camera_pos;

        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        if (scrollWheel != 0.0f)
            MouseWheel(scrollWheel);

        if (Input.GetMouseButtonDown(0) ||
           Input.GetMouseButtonDown(1) ||
           Input.GetMouseButtonDown(2))
            preMousePos = Input.mousePosition;

        MouseDrag(Input.mousePosition);
    }

    private void MouseWheel(float delta)
    {
        transform.position += transform.forward * delta * wheelSpeed;
        return;
    }

    private void MouseDrag(Vector3 mousePos)
    {
        Vector3 diff = mousePos - preMousePos;

        if (diff.magnitude < Vector3.kEpsilon)
            return;

        if (Input.GetMouseButton(2))
            transform.Translate(-diff * Time.deltaTime * moveSpeed);
        //else if (Input.GetMouseButton(1))
        //    CameraRotate(new Vector2(-diff.y, diff.x) * rotateSpeed);

        preMousePos = mousePos;
    }

    /*public void CameraRotate(Vector2 angle)
    {
        transform.RotateAround(transform.position, transform.right, angle.x);
        transform.RotateAround(transform.position, Vector3.up, angle.y);
    }*/

    public void MiniCameraButton()
    {
        Vector3 OriginalCamera_pos;

        OriginalCamera_pos = new Vector3(0f, 400f, 0f);

        transform.position = OriginalCamera_pos;
    }
}