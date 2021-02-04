using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;

    //cached references
    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public bool HasEnoughStars(int stars)
    {
        return this.stars >= stars;
    }

    public void AddStars(int stars)
    {
        this.stars += stars;
        UpdateDisplay();
    }

    public void SpendStars(int stars)
    {
        if (this.stars >= stars)
        {
            this.stars -= stars;
            UpdateDisplay();
        }
    }
}
