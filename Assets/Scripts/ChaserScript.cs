using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserScript : MonoBehaviour
{
    public Transform target;
    private bool withinRange= false;
    public AudioSource warningSound;
    private int warningCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
        if(warningCooldown > 0)
        {
            warningCooldown--;
        }
        if(target != null)
        {
            transform.LookAt(target);
        }
        float distToPlayer = Vector3.Distance(target.position, transform.position);

        if(distToPlayer <= 30.0)
        {
            if (!withinRange && warningCooldown == 0)
            {
                //means that player just encountered the monster, 
                warningSound.Play();
                withinRange = true;
                warningCooldown = 3000;

            }
            else
            {
                withinRange = false;
            }

        }

    }
}
