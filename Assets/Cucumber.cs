using UnityEngine;
using System.Collections.Generic;

public class Cucumber : MonoBehaviour
{
    public GameObject dragonPrefab; 
    private static List<Cucumber> cucumberList = new List<Cucumber>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        cucumberList.Add(this);
    }

    private void OnDisable()
    {
        cucumberList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Cucumber otherCucumber = collision.gameObject.GetComponent<Cucumber>();
        if (otherCucumber != null && otherCucumber != this && !this.hasCombined && !otherCucumber.hasCombined)
        {
            CombineCucumber(this, otherCucumber);
        }
    }

    private void CombineCucumber(Cucumber cucumber1, Cucumber cucumber2)
    {
        if (cucumber1 != null && cucumber2 != null)
        {
            Vector2 midPoint = (cucumber1.transform.position + cucumber2.transform.position) / 2;


            Instantiate(dragonPrefab, midPoint, Quaternion.identity);


            cucumber1.hasCombined = true;
            cucumber2.hasCombined = true;


            Destroy(cucumber1.gameObject);
            Destroy(cucumber2.gameObject);
        }
    }
}
