using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float delay;

    Image img;
    void Start()
    {
        img = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        img.color = new Color(1f, 1f, 1f, Mathf.Sin(delay + Time.time * speed));
    }
}
