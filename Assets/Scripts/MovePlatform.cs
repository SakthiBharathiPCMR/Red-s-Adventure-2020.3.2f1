using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    [SerializeField]
    float start;
    [SerializeField]
    float end;
    [SerializeField]
    float speed;
    float xPos=1;
    float yPos=1;
    [SerializeField]
    bool xAxis, yAxis;


    float currentX;
    float currentY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovingPlatform();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player")
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null);
        }
    }

    private void MovingPlatform()
    {
        currentX = transform.position.x;
        currentY = transform.position.y;

        if(xAxis)
        {
            transform.position += new Vector3(xPos, 0, 0) * speed * Time.deltaTime;

            if (currentX <= start)
            {
                xPos = 1f;
            }
            else if (currentX >= end)
            {
                xPos = -1f;
            }

            
        }
        else if(yAxis)
        {
            transform.position += new Vector3(0, yPos, 0) * speed * Time.deltaTime;

            if (currentY <= start)
            {
                yPos = 1f;
            }
            else if (currentY >= end)
            {
                yPos = -1f;
            }

            

        }

    }
}
