using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject RedButton_1;
    [SerializeField] private GameObject RedButton_2;
    [SerializeField] private GameObject BlueButton_1;
    [SerializeField] private GameObject BlueButton_2;

    [Header("")]
    [SerializeField] private LayerMask Players;

    [Header("Walls")]
    [SerializeField] private GameObject LeftMagicWalls;
    [SerializeField] private GameObject RightMagicWalls;

    [Header("")]
    [SerializeField] private GameObject Spikes;
    [SerializeField] private GameObject ExitDoor;
    [SerializeField] private GameObject WinScreen;

    bool RB_1;
    bool RB_2;
    bool BB_1;
    bool BB_2;

    public int winCount = 0;

    private void FixedUpdate() {
        RB_1 = Physics2D.OverlapCircle(RedButton_1.transform.position, 0.1f, Players);
        RB_2 = Physics2D.OverlapCircle(RedButton_2.transform.position, 0.1f, Players);
        if(BlueButton_1.activeSelf){
            BB_1 = Physics2D.OverlapCircle(BlueButton_1.transform.position, 0.1f, Players);
            BB_2 = Physics2D.OverlapCircle(BlueButton_2.transform.position, 0.1f, Players);
        }else{
            BB_1 = false; BB_2 = false;
        }

        //Make Blue Buttons Appear
        if(RB_1 && RB_2){
            BlueButton_1.SetActive(true);
            BlueButton_2.SetActive(true);
        }

        //Magic Walls
        if(RB_1){
            Spikes.SetActive(false);
        }
        if(BB_1){
            LeftMagicWalls.SetActive(true);
        }

        //Exit door
        if(BB_1 && BB_2){
            ExitDoor.SetActive(true);
            RightMagicWalls.SetActive(true);
        }

        //Win
        if(winCount >= 2){
            Debug.Log("Won!");
            WinScreen.SetActive(true);
        }
    }
}
