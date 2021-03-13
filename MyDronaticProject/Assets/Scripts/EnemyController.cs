using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private int speed;
    public GameObject enemy; // TODO
    public GameObject coinPrefab; // TODO assign coin prefab to this
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onDeath() {

        GameObject coin = Instantiate(coinPrefab, enemy.transform);
        Destroy(enemy);
        // TODO set coin's value to speed 
    }

}
