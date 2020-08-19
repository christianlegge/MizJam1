using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
	Light light;

    // Start is called before the first frame update
    void Start()
    {
		light = GetComponent<Light>();    
    }

    // Update is called once per frame
    void Update()
    {
		light.intensity = Mathf.Sin(Time.time * 5) * 3 + 12 ;
    }
}
