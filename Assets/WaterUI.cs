using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterUI : MonoBehaviour
{
    public Image waterPrefab;
    public Sprite fullWaterSprite;
    public Sprite emptyWaterSprite;

    private List<Image> waters = new List<Image>();

    public void SetMaxWater(int maxWater)
    {
        foreach(Image water in waters)
    {
        Destroy(water.gameObject);
    }
    
        waters.Clear();

        for(int i = 0; i < maxWater; i++)
    {
        Image newWater = Instantiate(waterPrefab, transform);
        newWater.sprite = fullWaterSprite;
        newWater.color = Color.white;
        waters.Add(newWater);
    }
    }

    public void UpdateWaters(int currentWater)
    {
        for(int i = 0; i < waters.Count; i++)
        {
            if(i < currentWater)
            {
                waters[i].sprite = fullWaterSprite;
                waters[i].color = Color.white;
            }
            else
            {
                waters[i].sprite = emptyWaterSprite;
                waters[i].color = Color.black;
            }
        }
    }
}