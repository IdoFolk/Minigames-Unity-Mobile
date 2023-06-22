using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerActorHandeler : MonoBehaviour
{
    [SerializeField] public Rigidbody2D PlayerActorRB;
    [SerializeField] public GameObject PackageOnPlayer;
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

        // PlayerRigidBody.transform.Translate(0,movingSpeed * Time.deltaTime,0);
        PlayerScoreCount.SetText(Score.ToString());
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
        if (collision.tag == "Base" && _isPackageOnPlayer)
        {
            Debug.Log("Reached The Base");
            _isPackageOnPlayer = false;
            Score++;
            PackageOnPlayer.SetActive(false);


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
