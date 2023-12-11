using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Piece : MonoBehaviour
{
    public int x, y;
    public bool bomb;

    private void OnMouseDown()
    {
        if (bomb) GetComponent<SpriteRenderer>().material.color = Color.red;
        else
        {
            TextMeshProUGUI textComponent = GetComponentInChildren<TextMeshProUGUI>();
            if (textComponent != null)
                textComponent.text = Generator.gen.GetBombsAround(x, y).ToString();
            else Debug.LogError("Text component not found in the hierarchy of Piece.");
        }
    }
}
