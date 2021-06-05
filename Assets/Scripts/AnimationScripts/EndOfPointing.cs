using System;
using System.Collections.Generic;
using Game;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndOfPointing : MonoBehaviour
{
    public Player player;
   
    public void NewEvent(string s) 
    { 
        GetComponent<Animator>().SetBool("isPointing",false);
        player._disableMove = false;
    }
    
}
