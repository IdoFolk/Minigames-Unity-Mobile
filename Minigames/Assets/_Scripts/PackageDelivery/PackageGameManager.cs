using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageGameManager : MiniGameManager
{
    public static PackageGameManager Instance;
   

    // Start is called before the first frame update
    void Start()
    {
        Instance = new();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private const float startAngle = 360;

    public override void YellowButtonPressed()
    {
        
            Vector2 mp = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);

            Vector2 dir = mp - (Vector2)transform.position;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - startAngle;

            if (angle < transform.eulerAngles.z)
            {
                transform.eulerAngles = new Vector3(0, 0, angle);
            }

        
    }
}
