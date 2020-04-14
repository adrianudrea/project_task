using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [Header("Menus")]
    public GameObject containerA;
    public GameObject containerB;
    public GameObject containerC;
    [Header("Buttons")]
    public Button containerAButton;
    public Button containerBButton;
    public Button containerCButton;
    [Header("Bools")]
    private bool isContainerAOpen;
    private bool isContainerBOpen;
    private bool isContainerCOpen;

    private void Start()
    {
        OpenContainerA();
        ButtonFunctionality();
    }

    private void OpenContainerA() { isContainerAOpen = true; isContainerBOpen = false; isContainerCOpen = false; ToggleUI(); }
    private void OpenContainerB() { isContainerAOpen = false; isContainerBOpen = true; isContainerCOpen = false; ToggleUI(); }
    private void OpenContainerC() { isContainerAOpen = false; isContainerBOpen = false; isContainerCOpen = true; ToggleUI(); }

    private void ButtonFunctionality()
    {
        containerAButton.onClick.AddListener(OpenContainerA);
        containerBButton.onClick.AddListener(OpenContainerB);
        containerCButton.onClick.AddListener(OpenContainerC);
    }

    private void ToggleUI()
    {
        if (isContainerAOpen)
        {
            containerA.GetComponent<CanvasGroup>().alpha = 1;
            containerA.GetComponent<CanvasGroup>().interactable = true;
            containerA.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            containerA.GetComponent<CanvasGroup>().alpha = 0;
            containerA.GetComponent<CanvasGroup>().interactable = false;
            containerA.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (isContainerBOpen)
        {
            containerB.GetComponent<CanvasGroup>().alpha = 1;
            containerB.GetComponent<CanvasGroup>().interactable = true;
            containerB.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            containerB.GetComponent<CanvasGroup>().alpha = 0;
            containerB.GetComponent<CanvasGroup>().interactable = false;
            containerB.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if (isContainerCOpen)
        {
            containerC.GetComponent<CanvasGroup>().alpha = 1;
            containerC.GetComponent<CanvasGroup>().interactable = true;
            containerC.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            containerC.GetComponent<CanvasGroup>().alpha = 0;
            containerC.GetComponent<CanvasGroup>().interactable = false;
            containerC.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
}
