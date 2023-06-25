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

    [SerializeField] public Rigidbody2D PlayerRigidBody;
    [SerializeField] public Rigidbody2D PlayerWheelRigidBody;

    private float startAngle = 360f;

    void Update()
    {

        if(PackageGameManager.Instance.isGamePaused) return; 
        // PlayerRigidBody.transform.Translate(0,movingSpeed * Time.deltaTime,0);
        PlayerRigidBody.rotation = PlayerWheelRigidBody.rotation;
        RotateSteeringWheel();
    }

    

    private void CalculateRotationForSteeringWheel()
    {
        Vector2 direction = (Vector2)GetPositionOfInput() - (Vector2)PlayerWheelRigidBody.transform.position;
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
    private Vector3 GetPositionOfInput()
    {
        Vector2 touchPosition = Input.GetTouch(0).position;
        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        touchWorldPosition.z = 0;
        return touchWorldPosition;
    }
    private void RotateSteeringWheel()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log($"Touch Position = {touchWorldPosition}");
            Ray ray = Camera.main.ScreenPointToRay(GetPositionOfInput());
            RaycastHit hit;
            Collider2D[] colliders = Physics2D.OverlapPointAll(GetPositionOfInput());
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Circle"))
                {
                    collider.GetComponent<SteeringWheel>().CalculateRotationForSteeringWheel();
                    //Debug.Log("This is indeed a circle");
                    break;
                }
            }
        }
    }

    

}

