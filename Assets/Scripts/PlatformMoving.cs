using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    public Vector3 target; // Can modify destination to refine a level design
    private Vector3 start;
    public float speed;
    private bool atStart = true;
    // Start is called before the first frame update
    void Start()
    {
        start = transform.position; // Start Position
    }

    // Update is called once per frame
    void Update()
    {
        float step = speed * Time.deltaTime * 0.1f; // Final Movement Speed
        // Check if the object is at start location
        if(atStart){
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if(transform.position == target){
                atStart = false;
            }
        }
        else{
            transform.position = Vector3.MoveTowards(transform.position, start, step);
            if(transform.position == start){
                atStart = true;
            }
        }
    }
}
