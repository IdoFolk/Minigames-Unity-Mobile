using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerActorHandeler : MonoBehaviour
{
    [SerializeField] TMP_Text PlayerScoreCount;
    [SerializeField] private int Score;
    [SerializeField] public GameObject PackageOnPlayer;

    
    
    private bool _isPackageOnPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
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
}
