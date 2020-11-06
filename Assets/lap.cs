using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class lap : MonoBehaviour
{
    public sphere car;
    public int Nlap=0;
    public Text text;
    public Text text2;
    float ti;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Track");
        }
        ti = (ti+ Time.deltaTime);
        text2.text = ti.ToString("F2");

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            print(Nlap);
            if (car.checkpoint == 6)
            {
                car.checkpoint = 0;
                Nlap = Nlap + 1;
                text.text = "Laps: " + Nlap.ToString() + " | 2";
                print("reset");

            }
            if (Nlap == 2)
            {
                if (ti < PlayerPrefs.GetFloat("Time"))
                {
                    PlayerPrefs.SetFloat("Time", ti);

                }
              
                SceneManager.LoadScene("Win");

            }
        }
    }


}
