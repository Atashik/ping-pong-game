using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControls : MonoBehaviour
{
    public Transform ballTr;
    public Rigidbody2D ballRB;
    public GameLogic gameLogic;


    public void StartGame()
    {
        var scaleAndMass = Random.Range(.3f, 1.2f);
        ballRB.mass = scaleAndMass;
        ballTr.localScale = new Vector3(scaleAndMass, scaleAndMass, 1);
        ballRB.velocity = Vector2.zero;
        ballRB.AddForce(new Vector2(Random.Range(-2.5f, 2.5f), Random.Range(-3.5f, 3.5f)), ForceMode2D.Impulse);
        //ball
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "win")
            gameLogic.PlayerWins();
        else if (other.tag == "loose")
            gameLogic.PlayerLoose();
        
    }
}
