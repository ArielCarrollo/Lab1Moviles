using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSaver : MonoBehaviour
{
    Color color;
    void SaveColor()
    {
        color = this.GetComponent<Image>().color;
    }
}
