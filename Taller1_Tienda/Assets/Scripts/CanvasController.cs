using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

    [SerializeField] GameObject canvasShop, canvasInventory;
    [SerializeField] GameObject InitialText;

    private void Start()
    {
        canvasShop.SetActive(false);
        canvasInventory.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.T)) {
            canvasShop.SetActive(true);
            canvasInventory.SetActive(false);
            InitialText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I)) {
            canvasInventory.SetActive(true);
            canvasShop.SetActive(false);
            InitialText.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (canvasShop.activeInHierarchy || canvasInventory.activeInHierarchy) {
                canvasShop.SetActive(false);
                canvasInventory.SetActive(false);
                InitialText.SetActive(true);
            }
        }
	}
}
