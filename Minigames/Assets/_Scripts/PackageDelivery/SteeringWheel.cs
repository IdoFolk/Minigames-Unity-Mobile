using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class SteeringWheel : MonoBehaviour
{

    public float movingSpeed = 0.001f;
    public float RotateSpeed;

    [SerializeField] Rigidbody2D PlayerRigidBody;
    [SerializeField] Rigidbody2D PlayerWheelRigidBody;

    private float startAngle = 360f;

    void Update()
    {

        if (PackageGameManager.Instance.isGamePaused) return;
        // PlayerRigidBody.transform.Translate(0,movingSpeed * Time.deltaTime,0);
        PlayerRigidBody.rotation = PlayerWheelRigidBody.rotation;
        RotateSteeringWheel();
    }



    private void CalculateRotationForSteeringWheel(int i)
    {
        Vector2 direction = (Vector2)GetPositionOfInput(i) - (Vector2)PlayerWheelRigidBody.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startAngle;
        //Debug.Log($"Angle BullShit {angle}");
        if (angle < PlayerWheelRigidBody.transform.eulerAngles.z)
        {
            //Debug.Log(rotationAmount);
            //PlayerWheelRigidBody.transform.eulerAngles = new Vector3(0, 0, rotationAmount);
            Quaternion TargetRot = Quaternion.Euler(PlayerWheelRigidBody.transform.eulerAngles = new Vector3(0, 0, angle));
            Quaternion.Lerp(PlayerWheelRigidBody.transform.rotation, TargetRot, RotateSpeed * Time.deltaTime);
        }
    }
    private Vector3 GetPositionOfInput(int i)
    {
        Vector2 touchPosition = Input.GetTouch(i).position;
        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        touchWorldPosition.z = 0;
        return touchWorldPosition;

    }
    private void RotateSteeringWheel()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Moved)
            {
                //Debug.Log($"Touch Position = {touchWorldPosition}");
                Ray ray = Camera.main.ScreenPointToRay(GetPositionOfInput(i));
                RaycastHit hit;
                Collider2D[] colliders = Physics2D.OverlapPointAll(GetPositionOfInput(i));
                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Circle"))
                    {
                        collider.GetComponent<SteeringWheel>().CalculateRotationForSteeringWheel(i);
                        //Debug.Log("This is indeed a circle");
                        break;
                    }
                }
            }
        }
    }



}

