using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabLandlordCommand : EventCommand
{
    [Inject]
    public IntegrationModel integrationModel { get; set; }

    [Inject]
    public RoundModel roundModel { get; set; }
    public override void Execute()
    {
        GrabLandlorArgs e = this.evt.data as GrabLandlorArgs;
      

        //积分翻倍
        integrationModel.Multiples *= 2;

        //高数游戏该发底牌了
        dispatcher.Dispatch(ViewEvent.DEAL_THREECARD, e);


        //开始游戏
        roundModel.Start(e.cType);


    }
}
