using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMain : MonoBehaviour
{
    [SerializeField] private InputSubscription inputSub;
    [SerializeField] private GameObject MenuUIObj;
    private bool menuOpen;
    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (inputSub.MenuInput)
        {
            menuOpen=!menuOpen;
            
            if (!menuOpen) {
                MenuUI.instance.ResumeGame();
            }
            else
            {
                MenuUIObj.SetActive(true);
            }
        }
    }
}
