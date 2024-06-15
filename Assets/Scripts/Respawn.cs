using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{
    Vector3 resetPos;
    [SerializeField]
    GameObject finishText, finishFx;
    

    // Start is called before the first frame update
    void Start()
    {
        resetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Water"))
        {
            StartCoroutine(WaitTime());   
        }
        else if(collision.gameObject.CompareTag("Enemy"))
        {
            StartCoroutine(WaitTime());
        }
        else if(collision.gameObject.CompareTag("Finish"))
        {
            finishFx.SetActive(true);
            finishText.SetActive(true);
            StartCoroutine(CompleteTime());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Respawning"))
        {
            resetPos = transform.position;
        }
    }



    IEnumerator WaitTime()
    {
        Time.timeScale = 0f;
        
        yield return new WaitForSecondsRealtime(0.5f);
        transform.position = resetPos;
        Time.timeScale = 1f;
    }
    
    IEnumerator CompleteTime()
    {
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene("Start");
    }


}
