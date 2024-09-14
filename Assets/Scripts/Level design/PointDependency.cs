using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointDependency : UI_Points
{
    public int requirement;
    public GameObject activated;
    void Update()
    {
        if (requirement <= 0)
        {
            activated.SetActive(true);
        }
    }
}
