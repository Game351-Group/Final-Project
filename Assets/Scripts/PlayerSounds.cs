using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField]
    private GameObject splashVFX;
    [SerializeField]
    private AudioSource collect;
    [SerializeField]
    private AudioSource grassWalk;
    [SerializeField]
    private AudioSource snowWalk;
    [SerializeField]
    private AudioClip[] meows;
    [SerializeField]
    private AudioSource meowsSource;
    [SerializeField]
    private AudioSource savePoint;
    [SerializeField]
    private AudioSource hit;
    private bool grass = false;
    private bool snow = false;
    private bool ground = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (grass == true)
            {
                grassWalk.enabled = true;
                snowWalk.enabled = false;
            }
            if (snow == true)
            {
                grassWalk.enabled = false;
                snowWalk.enabled = true;
            }
            if (ground == true)
            {
                grassWalk.enabled = false;
                snowWalk.enabled = false;
            }
        }
        else
        {
            grassWalk.enabled = false;
            snowWalk.enabled = false;
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            AudioClip meow = meows[Random.Range(0, meows.Length)];
            meowsSource.PlayOneShot(meow, .7f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Water")
        {
            Instantiate(splashVFX, transform.position, splashVFX.transform.rotation);
        }
        else if (other.tag == "Collectable")
        {
            collect.PlayOneShot(collect.clip, .7f);
        }
        else if (other.tag == "CatHouse")
        {
            savePoint.PlayOneShot(savePoint.clip, .7f);
        }
        else if (other.tag == "Obstacle")
        {
            hit.PlayOneShot(hit.clip, .7f);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Grass")
        {
            grass = true;
            snow = false;
            ground = false;
        }
        else if (collision.gameObject.tag == "Snow")
        {
            grass = false;
            snow = true;
            ground = false;
        }
        else if (collision.gameObject.tag == "Ground")
        {
            grass = false;
            snow = false;
            ground = true;
        }
    }
}