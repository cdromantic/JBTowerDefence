using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour {
    [SerializeField]
    Button[] towerButtons;
    
    bool isPlacing = false;
    public GameObject tower1;
    enum SelectState {
        WaitForSelection,
        Tower1Placement
    };
    SelectState currentState = SelectState.WaitForSelection;

    void Start() {
    }
    void Update() {
        switch (currentState) {
            default:
                WaitForSelection();
                break;
            case SelectState.WaitForSelection:
                WaitForSelection();
                break;
            case SelectState.Tower1Placement:
                TowerPlacement();
                break;
        }
    }
    void WaitForSelection() {
        for (int i = 0; i < towerButtons.Length; i++) {
            towerButtons[i].interactable = true;
            towerButtons[i].gameObject.SetActive(true);
        }
    }

    void TowerPlacement() {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.collider != null && isPlacing) {
            Debug.Log(hit.collider.gameObject);
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Instantiate(tower1, hit.collider.gameObject.transform.position, Quaternion.identity);
                currentState = SelectState.WaitForSelection;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isPlacing) {
            isPlacing = false;
            currentState = SelectState.WaitForSelection;
        }
    }
    public void SwitchToTowerPlacement(int towerType) {
        for (int i = 0; i < towerButtons.Length; i++) {
            towerButtons[i].interactable = false;
            towerButtons[i].gameObject.SetActive(false);
        }
        isPlacing = true;
        if (towerType == 1) {
        currentState = SelectState.Tower1Placement;
        }
    }
}
