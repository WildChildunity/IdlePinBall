using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    private HingeJoint2D Hinge;
    private JointMotor2D Motor;

    [SerializeField]
    private bool left;

    private bool active;

    void Start()
    {
        Hinge = GetComponent<HingeJoint2D>();
        Motor = Hinge.motor;
    }

    // Update is called once per frame
    void Update()
    {
        Hinge.motor = Motor;
    }

    public void Push()
    {
        Motor.motorSpeed = Player.Instance.PaddlePower;
    }

    public void Pull()
    {
        Motor.motorSpeed = -Player.Instance.PaddlePower;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Player.Instance.Automated == true && active == false)
        {
            active = true;
            StartCoroutine(automaticPush());
        }
    }

    private IEnumerator automaticPush()
    {
        if (left == true)
        {
            Pull();
            yield return new WaitForSeconds(0.1f);
            Push();
            active = false;
        }
        else
        {
            Push();
            yield return new WaitForSeconds(0.1f);
            Pull();
            active = false;
        }

    }
}
