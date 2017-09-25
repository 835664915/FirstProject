using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCommand : EventCommand
{

    [Inject]
    public IntegrationModel integrationModel { get; set; }

    [Inject]
    public RoundModel roundModel { get; set; }

    [Inject]
    public CardModel cardModel { get; set; }


    public override void Execute()
    {
        int result = integrationModel.Result;

        GameOverArgs e = evt.data as GameOverArgs;

        #region 更新积分
        if (e.PlayWin)
            integrationModel.PlayerIntergration += result;
        else
            integrationModel.PlayerIntergration -= result;
        if (e.ComputerLeftWin)
            integrationModel.ComputerLeftIntergration += result;
        else
            integrationModel.ComputerLeftIntergration -= result;
        if (e.ComputerRightWin)
            integrationModel.ComputerRightIntergration += result;
        else
            integrationModel.ComputerRightIntergration -= result;
        #endregion

        #region 保存数据
        GameData data = new GameData();
        data.playerIntergration = integrationModel.PlayerIntergration;
        data.computerLeftIntergration = integrationModel.ComputerLeftIntergration;
        data.computerRightIntergration = integrationModel.ComputerRightIntergration;
        Toos.SaveData(data);
        #endregion

        //更新积分UI
        dispatcher.Dispatch(ViewEvent.UPDATE_INTEGRATION, data);
      
        cardModel.InitCardLibary();
        roundModel.InitRound();
        PoolManager.Instance.HideAllObject("Card");

        //显示一个游戏结束的面板
        Toos.CreateUIpanel(PanelType.GameOverPanel);
        dispatcher.Dispatch(ViewEvent.SHOW_INTERGRATION, data);

    }



}
