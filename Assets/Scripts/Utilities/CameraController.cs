using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Camera Initialization")]
    [SerializeField] private Camera camera;
    [SerializeField] private Vector3 initialOffsetFromPivot;

    [Header("Camera Zoom")]
    [SerializeField] private float minZoomValue;
    [SerializeField] private float maxZoomValue;
    [SerializeField] private float zoomingSpeed;
    [SerializeField] private float minZoomAngle;
    [SerializeField] private float maxZoomAngle;
    [SerializeField] private float minZoomPosY;
    [SerializeField] private float maxZoomPosY;

    [Header("Camera Rotation")]
    [SerializeField] private Vector3 rotationPivot;
    [SerializeField] private float rotationSeed;

    private PgkControlls controlls = null;
    private void Awake()
    {
        controlls = new PgkControlls();
        camera.transform.position = rotationPivot + initialOffsetFromPivot;
        camera.transform.localPosition += new Vector3(0, maxZoomPosY, 0);
        camera.transform.localEulerAngles = new Vector3(maxZoomAngle, 0, 0);
        camera.orthographicSize = maxZoomValue;
    }

    private void OnEnable()
    {
        controlls.Camera.Enable();
    }

    private void Update()
    {
        handleCameraZoom();
        handleCameraRotation();
    }

    private void OnDisable()
    {
        controlls.Camera.Disable();
    }


    private void handleCameraZoom()
    {
        var zoomDirection = controlls.Camera.Zoom.ReadValue<float>();
        camera.orthographicSize += zoomingSpeed * Time.deltaTime * zoomDirection;
        camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, minZoomValue, maxZoomValue);

        var zoomAngleX = (camera.orthographicSize - minZoomValue) / (maxZoomValue - minZoomValue) * (maxZoomAngle - minZoomAngle) + minZoomAngle;
        camera.gameObject.transform.localEulerAngles = new Vector3(zoomAngleX, camera.gameObject.transform.localEulerAngles.y, 0);

        var zoomPosY = (camera.orthographicSize - minZoomValue) / (maxZoomValue - minZoomValue) * (maxZoomPosY - minZoomPosY) + minZoomPosY;
        camera.gameObject.transform.localPosition = new Vector3(camera.gameObject.transform.localPosition.x, zoomPosY, camera.gameObject.transform.localPosition.z);
    }

    private void handleCameraRotation()
    {
        var rotationDirection = controlls.Camera.Rotation.ReadValue<float>();
        var angle = rotationSeed * Time.deltaTime * rotationDirection;
        camera.transform.RotateAround(rotationPivot, Vector3.up, angle);
    }

}
