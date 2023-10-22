using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlState
{
    Player,
    Interface
}
public class GameManager : Singleton<GameManager>
{
    public CharacterController characterController;

    private ControlState _controlState;
    
    public void SwitchControlState(ControlState controlState)
    {
        _controlState = controlState;
        
        if(_controlState == ControlState.Player) OnPlayerControl();
        else if(_controlState == ControlState.Interface) OnInterfaceControl();
    }

    private void OnPlayerControl()
    {
        characterController.ToggleMovement(true);
        // Equipment and Inventory UI Stuff goes here!
    }

    private void OnInterfaceControl()
    {
        characterController.ToggleMovement(false);
    }
    
    
    
    
    
}
