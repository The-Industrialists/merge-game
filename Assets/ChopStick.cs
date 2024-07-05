using UnityEngine;
using System.Collections.Generic;

public class ChopStick : MonoBehaviour
{
    public GameObject CucumberPrefab; 
    private static List<ChopStick> chopstickList = new List<ChopStick>();
    private bool hasCombined = false; 

    private void OnEnable()
    {
        chopstickList.Add(this);
    }

    private void OnDisable()
    {
        chopstickList.Remove(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ChopStick otherChopStick = collision.gameObject.GetComponent<ChopStick>();
        if (otherChopStick != null && otherChopStick != this && !this.hasCombined && !otherChopStick.hasCombined)
        {
            CombineChopStick(this, otherChopStick);
        }
    }

    private void CombineChopStick(ChopStick chopstick1, ChopStick chopstick2)
    {
        if (chopstick1 != null && chopstick2 != null)
        {
            Vector2 midPoint = (chopstick1.transform.position + chopstick2.transform.position) / 2;


            Instantiate(CucumberPrefab, midPoint, Quaternion.identity);


            chopstick1.hasCombined = true;
            chopstick2.hasCombined = true;


            Destroy(chopstick1.gameObject);
            Destroy(chopstick2.gameObject);
        }
    }
}
