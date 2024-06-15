using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMaceMove : MonoBehaviour
{
    [SerializeField]float min = 1;
    [SerializeField] float max;
    [SerializeField]
    float speed;
    float scale;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        float sizeX = transform.localScale.x;
        if(sizeX<=min)
        {
            scale = 1;
        }
        else if(sizeX >= max )
        {
            scale = -1;
        }
        transform.localScale += new Vector3(scale, scale, 0) * speed * Time.deltaTime;
    }
}
