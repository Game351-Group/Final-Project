using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoving : MonoBehaviour
{
    public Vector3 target; // Can modify destination to refine a level design
    private Vector3 start;
    public float speed;
    private bool atStart = true;
    
    void Start(){
        start = transform.position; // Start Position
    }
    
    void Update()
    {
        float step = speed * Time.deltaTime * 0.1f; // Final Movement Speed
        // Check if the object is at start location
        if(atStart){
            transform.Rotate(Vector3.forward * 100 * Time.deltaTime); // Make a saw spins
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if(transform.position == target){
                atStart = false;
            }
        }else{
            transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, start, step);
            if(transform.position == start){
                atStart = true;
            }
        }
    }
}