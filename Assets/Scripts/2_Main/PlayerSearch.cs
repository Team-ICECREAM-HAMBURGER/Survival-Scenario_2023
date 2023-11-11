using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSearch : MonoBehaviour {
    [Header("Search")] 
    [SerializeField] private Button okButton;
    [Space(10f)] 
    [SerializeField] private GameObject searchingGameObject;
    
    
    public void Init() {
        Player.Instance.CanvasChange("Canvas Search");
        // TODO: Search Result Set; okButton Listener
        searchingGameObject.SetActive(true);
    }
}