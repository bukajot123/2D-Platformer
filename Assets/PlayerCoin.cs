using UnityEngine;

public class PlayerCoin : MonoBehaviour
{
    public float coin;

    public delegate void CoinChangedHandler(float newCoin, float ammountChanged);
    public event CoinChangedHandler OncoinChanged;

    public delegate void CoinInitialisedHandler(float newCoin);
    public event CoinInitialisedHandler OncoinInitialised;


    void Start()
    {
     
    }

    
    void Update()
    {
        
    }

    public void AddCoin(float coinToAdd)
    {
        coin += coinToAdd;
        OncoinChanged?.Invoke(coin, coinToAdd);
        Debug.Log(coin);
    }
}
