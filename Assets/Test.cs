using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : ProcessingLite.GP21
{

    // Start is called before the first frame update
    void Start()
    {
        DanRed2 dr = new DanRed2();
        dr.Setup(3, 5);
    }

    void Update()
    {

    }
}
