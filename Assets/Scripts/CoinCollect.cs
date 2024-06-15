using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCollect : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI text;
    int coinScore=0;
    [SerializeField]GameObject particle;
    GameObject particleLocation;
    AudioSource coinSound;
    [SerializeField]AudioClip coinClip;
    // Start is called before the first frame update
    void Start()
    {
        coinSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            particleLocation = collision.gameObject;
            Destroy(collision.gameObject);
            coinScore++;
            coinSound.PlayOneShot(coinClip);
            text.text = coinScore.ToString();

            
             GameObject particleFx=Instantiate(particle, particleLocation.transform.position,particleLocation.transform.rotation);
             Destroy(particleFx,2);            

        }
    }

}
