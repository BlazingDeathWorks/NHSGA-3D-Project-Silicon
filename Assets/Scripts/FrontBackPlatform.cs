using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontBackPlatform : MonoBehaviour
{
    [SerializeField] [Range(0, 30)] private float speed = 1;
    private List<Vector3> positions = new List<Vector3>();
    private int index;
    private int indexIncrement = -1;

    private void Awake()
    {
        //Platform's current position is first element
        positions.Add(transform.position);
        while (transform.childCount > 0)
        {
            Transform child = transform.GetChild(0);
            positions.Add(child.position);
            child.parent = null;
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[index], speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, positions[index]) != 0) return;

        if (index >= positions.Count - 1 || index <= 0)
        {
            indexIncrement *= -1;
        }
        index += indexIncrement;
    }
}
