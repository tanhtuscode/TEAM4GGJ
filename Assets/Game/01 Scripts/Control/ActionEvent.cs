using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionEvent
{
    #region HOME

    #endregion

    #region GAME_PLAY
    public static Action OnWin;
    public static Action OnLose;
    public static Action OnResetGame;
    public static Action OnResetLose;
    public static Action OnGoalCompleted;
    #endregion

    public static Action OnChangeValue;

    #region NOTI
    #endregion

    #region MISSION NOTIFICATION

    #endregion

    #region COLLECT CAR
    #endregion

    #region  IAP
    #endregion

    #region SCENE
    #endregion

    #region GamePlay
    public static Action<int> OnDiceRoll;
    public static Action<int> OnChangeValueBubble;
    public static Action<int> OnChangeValueCapacity;
    #endregion
}
