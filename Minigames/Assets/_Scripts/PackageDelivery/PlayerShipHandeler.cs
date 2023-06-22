using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShipHandeler : MonoBehaviour
{
    [SerializeField] public Rigidbody2D PlayerActorRB;
    [SerializeField] public GameObject PackageOnPlayer;
    [SerializeField] public GameObject Base;
    [SerializeField] public float MovmentSpeed;
    

    [SerializeField] TMP_Text PlayerScoreCount;
    [SerializeField] private int Score;
    
    private bool _isPackageOnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerActorRB.AddRelativeForce(new Vector2(0, 1 * MovmentSpeed * Time.deltaTime));
        PlayerScoreCount.SetText(Score.ToString());
        KeepPlayerOnScreen();
    }
    private void KeepPlayerOnScreen()
    {
        Vector3 newPosition = PlayerActorRB.transform.position;
        Vector3 viewportPosition = Camera.main.WorldToViewportPoint(PlayerActorRB.transform.position);
        if (viewportPosition.x > 1)
        {
            newPosition.x = -newPosition.x + 0.1f;
        }
        else if (viewportPosition.x < 0)
        {
            newPosition.x = -newPosition.x - 0.1f;

        }
        if (viewportPosition.y > 1)
        {
            newPosition.y = -newPosition.y + 0.1f;
        }
        else if (viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y - 0.1f;

        }
        PlayerActorRB.transform.position = newPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package" && !_isPackageOnPlayer)
        {
            Debug.Log("Picked Up Package");
            _isPackageOnPlayer = true;
            PackageOnPlayer.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject == Base && _isPackageOnPlayer)
        {
            Debug.Log("Reached The Base");
            _isPackageOnPlayer = false;
            Score++;
            PackageOnPlayer.SetActive(false);


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Bonk");
        }
    }
}
