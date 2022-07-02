using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warnings : MonoBehaviour
{

    public GameObject warning1;
    public GameObject warning2;
    public GameObject warning3;

    List<GameObject> warnings = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        warnings.Add(warning1);
        warnings.Add(warning2);
        warnings.Add(warning3);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void closeAll()
    {
        foreach(GameObject w in warnings)
        {
            w.SetActive(false);
        }
    }

    public void showWarning(int idx)
    {
        closeAll();

        warnings[idx-1].SetActive(true);

        //switch(idx)
        //{
        //    case 1:
        //        warning1.SetActive(true);
        //        break;

        //    case 2:
        //        warning2.SetActive(true);
        //        break;

        //    case 3:
        //        warning3.SetActive(true);
        //        break;
        //}
    }

    public void startClicked()
    {
        //remove entire warnings panel
        Destroy(gameObject);
    }
}
