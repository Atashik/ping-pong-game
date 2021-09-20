using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform MyTramsform;
    public Transform ballTr;
    void Start()
    {
        MyTramsform.position = new Vector3(0, MyTramsform.position.y, 0);
    }

    void FixedUpdate()
    {
        MyTramsform.position = new Vector3(ballTr.position.x, MyTramsform.position.y, 0);
    }
}
