using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonScirpt : MonoBehaviour
{
    public UnityEvent onButtonDown;
    public UnityEvent onButtonUp;
    public float yThreshold;
    [SerializeField] private bool isButtonPressed;

    // Update is called once per frame
    void Update()
    {
        if (isButtonPressed && transform.localPosition.y > yThreshold)
        {
            isButtonPressed = false;
            onButtonUp.Invoke();
        }
        else if(!isButtonPressed && transform.localPosition.y < yThreshold)
        {

            isButtonPressed = true;
            onButtonDown.Invoke();
        }
    }
}
