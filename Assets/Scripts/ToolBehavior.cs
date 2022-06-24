using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBehavior : MonoBehaviour
{
    public bool isEquipped;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EquipItem()
    {
        if (!isEquipped)
        {
            isEquipped = true;
        }
        else
        {
            isEquipped = false;
        }
    }
}
