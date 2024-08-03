using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlatformScript : MonoBehaviour
{
    private SliderJoint2D sliderJoint;
    private float lowerTranslation;
    private float upperTranslation;
    private JointMotor2D jointMotor;
    [SerializeField] private int decimalPlaces = 1; //Количчество знаков после запятой , для округления

    private void Start()
    {
        sliderJoint = GetComponent<SliderJoint2D>();
        lowerTranslation = sliderJoint.limits.min;
        upperTranslation = sliderJoint.limits.max;
        jointMotor = sliderJoint.motor;
    }

    private void FixedUpdate()
    {
        double currentTranslation = System.Math.Round((double)sliderJoint.jointTranslation, decimalPlaces); // округляем currentTranslation , для корректной работы motorController();
        MotorController(currentTranslation);
    }

    private void MotorController(double currentTranslation) 
    { 
        if ((float) currentTranslation >= upperTranslation || (float) currentTranslation <= lowerTranslation)
        {
            jointMotor.motorSpeed *= -1;
            sliderJoint.motor = jointMotor;
        }
    }
}