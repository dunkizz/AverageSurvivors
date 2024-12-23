﻿using UnityEngine;
using System.Collections;

namespace GrassFlow.Examples {
    [AddComponentMenu("Camera-Control/Mouse Orbit with zoom")]
    public class MouseOrbitImproved : MonoBehaviour {

        public Transform target;
        public float zoomSpeed = 15f;
        public float distance = 5.0f;
        public float hSpeed = 1.0f;
        public float vSpeed = 1.0f;

        public float yMinLimit = -20f;
        public float yMaxLimit = 80f;

        public float distanceMin = .5f;
        public float distanceMax = 15f;

        float x = 0.0f;
        float y = 0.0f;

        // Use this for initialization
        void Start() {
            Vector3 angles = transform.eulerAngles;
            x = angles.y;
            y = angles.x;

            // Make the rigid body not change rotation
            if (GetComponent<Rigidbody>())
                GetComponent<Rigidbody>().freezeRotation = true;
        }

        void LateUpdate() {
            if (target) {

                if (Input.GetMouseButton(1)) {

                    x += Input.GetAxis("Mouse X") * hSpeed * Time.deltaTime * 1000;
                    y -= Input.GetAxis("Mouse Y") * vSpeed * Time.deltaTime * 1000;

                    y = ClampAngle(y, yMinLimit, yMaxLimit);

                }

                Quaternion rotation = Quaternion.Euler(y, x, 0);

                distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * zoomSpeed, distanceMin, distanceMax);

                /*if (Physics.Linecast (target.position, transform.position, out hit)) {
                RaycastHit hit;
                    distance -=  hit.distance;
                }*/
                Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
                Vector3 position = rotation * negDistance + target.position;

                transform.rotation = rotation;
                transform.position = position;

            }

        }

        public static float ClampAngle(float angle, float min, float max) {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }


    }
}