using System.Collections;
using UnityEngine;

class PlayerInputManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject objSelecting = PieceSelector.GetObject();
            Debug.Log($"Selected: {objSelecting.name}");
        }
    }
}