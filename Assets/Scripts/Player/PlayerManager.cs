using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Maintain player health 
/// Maintain player state (Stoped | Moving | sinking ) 
/// 
/// </summary>
public class PlayerManager : MonoBehaviour
{
    public GameObject playerGamObj;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.onGameStateChange += onGameStateChange;
        playerGamObj.SetActive(false);
    }

    void onGameStateChange(GameManager.GameState from , GameManager.GameState to)
    {
        if(from == GameManager.GameState.PreGame && to == GameManager.GameState.Playing)
        {
            activate();
        }
    }
    /// <summary>
    /// Activate player when starting the game 
    /// </summary>
    void activate()
    {
        Debug.Log("Activate the player at the start of the game with 3 health point");

        playerGamObj.SetActive(true);
    }

    private void OnDestroy()
    {
        GameManager.Instance.onGameStateChange -= onGameStateChange;

    }

    
}
