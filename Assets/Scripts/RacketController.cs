using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public Transform racket;
    public Slider moveSlider;

    void Start()
    {
        racket.position = new Vector3(moveSlider.value, racket.position.y, 0.0f);
    }

    void Update()
    {
        
    }

    public void OnSliderMove()
    {
        racket.position = new Vector3(moveSlider.value, racket.position.y, 0.0f);
    }
}
