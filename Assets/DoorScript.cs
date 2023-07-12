using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Transform closedTransform;
    public Transform openedTransform;
    public bool isOpened;
    public void Open() { isOpened = true; }

    public void Close() { isOpened = false; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, (isOpened ? openedTransform : closedTransform).position, 0.04f);  
    }
}
