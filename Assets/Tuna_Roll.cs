using UnityEngine;
using System.Collections.Generic;

public class Tuna_Roll : MonoBehaviour
{
    public GameObject inarizushiPrefab; 
    private static List<Tuna_Roll> tune_rollList = new List<Tuna_Roll>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        tune_rollList.Add(this);
    }

    private void OnDisable()
    {
        tune_rollList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tuna_Roll otherTuna_Roll = collision.gameObject.GetComponent<Tuna_Roll>();
        if (otherTuna_Roll != null && otherTuna_Roll != this && !this.hasCombined && !otherTuna_Roll.hasCombined)
        {
            CombineTuna_Roll(this, otherTuna_Roll);
        }
    }

    private void CombineTuna_Roll(Tuna_Roll tuna_roll1, Tuna_Roll tuna_roll2)
    {
        if (tuna_roll1 != null && tuna_roll2 != null)
        {
            Vector2 midPoint = (tuna_roll1.transform.position + tuna_roll2.transform.position) / 2;


            Instantiate(inarizushiPrefab, midPoint, Quaternion.identity);


            tuna_roll1.hasCombined = true;
            tuna_roll2.hasCombined = true;


            Destroy(tuna_roll1.gameObject);
            Destroy(tuna_roll2.gameObject);
        }
    }
}
