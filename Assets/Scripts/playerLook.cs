using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLook : MonoBehaviour  {

    public enum RotationAxes {
        MouseXandY = 0,
        MouseX = 1,
        MouseY = 2
    }

    public RotationAxes axes = RotationAxes.MouseXandY;

    public float sensiHori = 9.0f;
    public float sensiVert = 9.0f;

    public float minVert = -45.0f;
    public float maxVert = 45.0f;

    private float rotX = 0;

    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) {
            body.freezeRotation = true;
        }
    }
    
    void Update() {
        if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensiHori, 0);
        } else if (axes == RotationAxes.MouseY) {
            rotX -= Input.GetAxis("Mouse Y") * sensiVert;
            rotX = Mathf.Clamp(rotX, minVert, maxVert);

            float rotY = transform.localEulerAngles.y;

            transform.localEulerAngles = new Vector3(rotX, rotY, 0);
        } else {
            rotX -= Input.GetAxis("Mouse Y") * sensiVert;
            rotX = Mathf.Clamp(rotX, minVert, maxVert);

            float delta = Input.GetAxis("Mouse X") * sensiHori;
            float rotY = transform.localEulerAngles.y + delta;

            transform.localEulerAngles = new Vector3(rotX, rotY, 0);
        }
    }
}
