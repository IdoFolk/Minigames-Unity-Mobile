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

        if (MiniGameManager.IsPaused) return;
        PlayerRigidBody.rotation = PlayerWheelRigidBody.rotation;
        RotateSteeringWheel();
    }



    private void CalculateRotationForSteeringWheel(int indexOfTouch)
    {
        Vector2 direction = (Vector2)GetPositionOfInput(indexOfTouch) - PlayerWheelRigidBody.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - startAngle;//direction.y / direction.x
        if (angle < PlayerWheelRigidBody.transform.eulerAngles.z)
        {
            Quaternion TargetRot = Quaternion.Euler(PlayerWheelRigidBody.transform.eulerAngles = new Vector3(0, 0, angle - 90));
            Quaternion.Lerp(PlayerWheelRigidBody.transform.rotation, TargetRot, RotateSpeed * Time.deltaTime);
        }
    }
    private Vector3 GetPositionOfInput(int indexOfTouch)
    {
        Vector2 touchPosition = Input.GetTouch(indexOfTouch).position;
        Vector3 touchWorldPosition = Camera.main.ScreenToWorldPoint(touchPosition);
        touchWorldPosition.z = 0;
        return touchWorldPosition;

    }
    private void RotateSteeringWheel()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            if (Input.GetTouch(i).phase != TouchPhase.Moved) continue;

            Ray ray = Camera.main.ScreenPointToRay(GetPositionOfInput(i));
            RaycastHit hit;
            Collider2D[] colliders = Physics2D.OverlapPointAll(GetPositionOfInput(i));
            foreach (Collider2D collider in colliders)
            {
                if (!collider.CompareTag("Circle")) continue;
                collider.GetComponent<SteeringWheel>().CalculateRotationForSteeringWheel(i);
            }
        }
    }



}

