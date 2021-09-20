using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    public GameLogic gameLogic;
    public bool winOrLoose;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            if(winOrLoose)
            gameLogic.PlayerWins();
            else
            gameLogic.PlayerLoose();

        }
    }
}
