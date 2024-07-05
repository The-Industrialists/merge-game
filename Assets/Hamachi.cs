using UnityEngine;
using System.Collections.Generic;

public class Hamachi : MonoBehaviour
{
    public GameObject UramakiPrefab; 
    private static List<Hamachi> hamachiList = new List<Hamachi>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        hamachiList.Add(this);
    }

    private void OnDisable()
    {
        hamachiList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hamachi otherhamachi = collision.gameObject.GetComponent<Hamachi>();
        if (otherhamachi != null && otherhamachi != this && !this.hasCombined && !otherhamachi.hasCombined)
        {
            CombineHamachi(this, otherhamachi);
        }
    }

    private void CombineHamachi(Hamachi hamachi1, Hamachi hamachi2)
    {
        if (hamachi1 != null && hamachi2 != null)
        {
            Vector2 midPoint = (hamachi1.transform.position + hamachi2.transform.position) / 2;


            Instantiate(UramakiPrefab, midPoint, Quaternion.identity);


            hamachi1.hasCombined = true;
            hamachi2.hasCombined = true;


            Destroy(hamachi1.gameObject);
            Destroy(hamachi2.gameObject);
        }
    }
}
