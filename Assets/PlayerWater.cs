using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerWater : MonoBehaviour
{
    public int maxWater = 5;
    public int currentWater;

    private SpriteRenderer spriteRenderer;

  //  public WaterUI waterUI;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentWater = maxWater;
        //waterUI.SetMaxWater(maxWater);

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemy)
        {
            TakeDamage(1);
        }
    }

        private void TakeDamage(int damage)
        {
            currentWater -= damage;
            //waterUI.UpdateWaters(currentWater);
            StartCoroutine(FlashRed());

            if(currentWater <= 0)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        private IEnumerator FlashRed()
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.color = Color.white;
        }
}