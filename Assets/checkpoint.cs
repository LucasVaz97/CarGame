using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public sphere car;
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
        
            if (car.checkpoint == id)
            {
                print("somei");
                print(car.checkpoint);
                car.checkpoint += 1;
    
            }

        }
    }
}
