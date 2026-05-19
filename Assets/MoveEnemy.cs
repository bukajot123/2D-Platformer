using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [Header("Ustawienia ruchu")]
    public Transform punktA;
    public Transform punktB;
    public float predkosc = 2f;

    void Update()
    {
       
        float dlugoscTrasy = Vector2.Distance(punktA.position, punktB.position);

        if (dlugoscTrasy > 0)
        {
            
            float czas = Time.time * predkosc;
            float odleglosc = Mathf.PingPong(czas, dlugoscTrasy);

           
            transform.position = Vector2.MoveTowards(punktA.position, punktB.position, odleglosc);
        }
    }
}