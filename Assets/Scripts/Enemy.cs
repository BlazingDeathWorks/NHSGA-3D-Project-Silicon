using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform destination;
    [SerializeField] private NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(destination.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
