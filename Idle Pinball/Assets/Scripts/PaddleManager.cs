using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleManager : MonoBehaviour
{
    public KeyCode Key;

    [SerializeField]
    private float Power;

    private HingeJoint2D Hinge;
    private JointMotor2D Motor;

    void Start()
    {
        Hinge = GetComponent<HingeJoint2D>();
        Motor = Hinge.motor;
        Power = Player.Instance.PaddlePower;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Key))
        {
            Motor.motorSpeed = Power;
        }
        else
        {
            Motor.motorSpeed = -Power;
        }

        Hinge.motor = Motor;
    }

    public void Hit()
    {
        
    }
}
