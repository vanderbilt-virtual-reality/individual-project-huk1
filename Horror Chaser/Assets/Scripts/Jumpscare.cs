using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscare : MonoBehaviour
{
    public bool Activated;
    public GameObject jumpScareObj;
    public Animation jumpScareAnim;
    public AudioSource jumpScareAudio;
    public BoxCollider Trigger;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(WaitJumpscare());
    }
    IEnumerator WaitJumpscare()
    {
        jumpScareAnim.Play();
        jumpScareAudio.Play();
        yield return new WaitForSeconds(0.5f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(10.67f, 10, 6.38f);
        GameObject chaser = GameObject.FindGameObjectWithTag("Monster");
        chaser.transform.position = new Vector3(76.6f, 0.85f, 7.6f);
        print("Success!");
    }
}
