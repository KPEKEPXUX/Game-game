using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class En_random : MonoBehaviour
{
    private float numb;
    public NavMeshAgent spod;
    void Start()
    {
        numb = Random.Range(20, 30);
        numb = numb/10;
        spod.speed = numb;
    }
}
