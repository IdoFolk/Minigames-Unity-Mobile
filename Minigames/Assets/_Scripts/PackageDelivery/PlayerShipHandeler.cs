using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShipHandeler : MonoBehaviour
{
    [SerializeField] Rigidbody2D PlayerActorRB;
    [SerializeField] GameObject PackageOnPlayer;
    [SerializeField] GameObject Base;
    [SerializeField] float MovmentSpeed;
    [SerializeField] float KnockbackForce;
    [SerializeField] TMP_Text PlayerScoreCount;
    [SerializeField] GameObject[] PackagesOnBase = new GameObject[4];

    public int Score;
    public bool isPackageOnPlayer;

    private int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (MiniGameManager.IsPaused) return;
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
        if (collision.tag == "Package" && !isPackageOnPlayer)
        {
            Debug.Log("Picked Up Package");
            isPackageOnPlayer = true;
            PackageOnPlayer.SetActive(true);
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject == Base && isPackageOnPlayer)
        {

            Debug.Log("Reached The Base");
            isPackageOnPlayer = false;
            Score++;
            PackagesOnBase[index].SetActive(true);
            index++;
            if (index > Score)
            {
                index = Score;
            }
            PackageOnPlayer.SetActive(false);


        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Bruh");
            Vector2 direction = (collision.rigidbody.velocity - PlayerActorRB.velocity);
            Vector2 knockBack = direction * KnockbackForce * Time.deltaTime;
            collision.rigidbody.AddForce(knockBack,ForceMode2D.Impulse);
            if (!collision.gameObject.GetComponent<PlayerShipHandeler>().isPackageOnPlayer) return;
            if (isPackageOnPlayer) return;
            PackageOnPlayer.SetActive(true);
            isPackageOnPlayer = true;
            collision.gameObject.GetComponent<PlayerShipHandeler>().isPackageOnPlayer = false;
            collision.gameObject.GetComponent<PlayerShipHandeler>().PackageOnPlayer.SetActive(false);
        }
    }
}
