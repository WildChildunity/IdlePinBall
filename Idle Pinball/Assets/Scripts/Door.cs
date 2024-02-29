using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Animator[] DoorAnims;


    private bool animating = false;
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(animating == false)
        {
            StartCoroutine(Open());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (animating == false)
        {
            StartCoroutine(Close());
        }
    }

    private IEnumerator Open()
    {
        foreach(Animator door in DoorAnims)
        {
            door.SetBool("ShouldOpen", true);
        }

        yield return new WaitForSeconds(0.4f);

        foreach (Animator door in DoorAnims)
        {
            door.SetBool("Open", true);
        }
    }

    private IEnumerator Close()
    {
        foreach (Animator door in DoorAnims)
        {
            door.SetBool("ShouldOpen", false);
        }

        yield return new WaitForSeconds(0.4f);

        foreach (Animator door in DoorAnims)
        {
            door.SetBool("Open", false);
        }

    }
}
