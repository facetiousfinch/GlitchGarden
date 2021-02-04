using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int starCost = 100;

    //cached reference
    StarDisplay starDisplay;

    private void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int stars)
    {
        starDisplay.AddStars(stars);
    }

    public int GetStarCost()
    {
        return starCost;
    }
}
