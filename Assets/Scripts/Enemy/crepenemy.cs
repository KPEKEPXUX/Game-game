using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class crepenemy : MonoBehaviour
{
    public NavMeshAgent agent007;
    public GameObject plr;
    private void Awake()
    {
        agent007 = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        plr= GameObject.Find("Bottom_hat");
        agent007.destination = plr.transform.position;
    }
}