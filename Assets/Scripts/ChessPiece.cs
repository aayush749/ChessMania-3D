using System;
using System.Collections;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
    protected Color initialColor;
    protected string color;
    public ChessDotNet.File col { get; protected set; }
    public int row { get; protected set; }

    protected bool isHighlighting = false;

    protected Coroutine highlightingCoroutine;
    public void StartHighlighting(float timeDelay = 5e-1f)
    {
        Color col = GetComponent<Renderer>().material.color;
        initialColor = new Color(
                                    col.r, col.g, col.b, col.a
                                );
        Debug.Log($"Obtained color of : {this.name}");   
        
        isHighlighting = true;
        highlightingCoroutine = StartCoroutine(Flash(timeDelay));
        Debug.Log($"Started Highlighting {this.name}");
    }

    public void StopHighlighting()
    {
        isHighlighting = false;
        StopCoroutine(highlightingCoroutine);
        GetComponent<Renderer>().material.color = initialColor;
        Debug.Log($"Stopped Highlighting {this.name}");

    }

    private IEnumerator Flash(float timeDelay)
    {
        Material mat = GetComponent<Renderer>().material;
        while(isHighlighting)
        {
            Debug.Log($"Time Delay: {timeDelay}");
            if (mat.color == initialColor)
                mat.color = Color.magenta;
            else
                mat.color = initialColor;
            yield return new WaitForSeconds(timeDelay);
            Debug.Log("After yield");
        }
    }
}