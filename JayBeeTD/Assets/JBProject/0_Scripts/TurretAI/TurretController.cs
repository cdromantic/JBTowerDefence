using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour {
    int goldMinus;
    [SerializeField]
    GoldCounter myGold;
    [SerializeField]
    Button[] towerButtons;
    GameObject selectedTower;

    public int goldCount;
    public int premCount;
    bool isPlacing = false;
    public GameObject tower1;
    public GameObject tower2;
    enum SelectState {
        WaitForSelection,
        TowerPlacement
    };
    SelectState currentState = SelectState.WaitForSelection;

    void Start() {
        goldCount = 0;
    }

    void Update() {
        switch (currentState) {
            default:
                WaitForSelection();
                break;
            case SelectState.WaitForSelection:
                WaitForSelection();
                break;
            case SelectState.TowerPlacement:
                TowerPlacement();
                break;
        }
    }

    void WaitForSelection() {
        for (int i = 0; i < towerButtons.Length; i++) {
            towerButtons[i].interactable = true;
            towerButtons[i].gameObject.SetActive(true);
        }
        if (goldCount < 8) {
            towerButtons[1].interactable = false;
        }
        if (goldCount < 5) {
            towerButtons[0].interactable = false;
        }
    }

    void TowerPlacement() {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out hit, Mathf.Infinity);
        if (hit.collider != null && isPlacing) {
            if (Input.GetKeyDown(KeyCode.Mouse0)) {
                Instantiate(selectedTower, hit.collider.gameObject.transform.position, Quaternion.identity);
                currentState = SelectState.WaitForSelection;
                Destroy(hit.collider.gameObject);
                myGold.AddGold(goldMinus);
                goldMinus = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && isPlacing) {
            isPlacing = false;
            currentState = SelectState.WaitForSelection;
            goldMinus = 0;
        }
    }

    public void ParseGoldAmount(int goldAmount) {
        goldCount = goldAmount;
    }
    public void ParsePremAmount(int premAmount)
    {
        premCount = premAmount;
    }

    public void SwitchToTowerPlacement(int towerType) {
        for (int i = 0; i < towerButtons.Length; i++) {
            towerButtons[i].interactable = false;
            towerButtons[i].gameObject.SetActive(false);
        }
        isPlacing = true;
        if (towerType == 1) {
            selectedTower = tower1;
            goldMinus = -5;
        currentState = SelectState.TowerPlacement;
        }
        if (towerType == 2) {
            selectedTower = tower2;
            goldMinus = -8;
            currentState = SelectState.TowerPlacement;
        }
    }
}