using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMoving : MonoBehaviour
{
    public Vector3 target;
    Vector3 start;
    public float speed;
    bool atStart = true;
    
    void Start(){
        start = transform.position;
    }
    
    void Update()
    {
        float step = speed * Time.deltaTime * 0.1f;
        
        if(atStart){
            transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if(transform.position == target){
                atStart = false;
            }
        }
        else{
            transform.Rotate(Vector3.back * 100 * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, start, step);
            if(transform.position == start){
                atStart = true;
            }
        }
    }
}