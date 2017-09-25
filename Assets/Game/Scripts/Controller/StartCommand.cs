using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class StartCommand : EventCommand
{
    [Inject]
    public IntegrationModel intergrationModel { get; set; }
    [Inject]
    public CardModel cardModel { get; set; }
    [Inject]
    public RoundModel roundModel { get; set; }

    public override void Execute()
    {
        //创建面板
        Toos.CreateUIpanel(PanelType.StartPanel);
       

        //初始化数据
        intergrationModel.Initintergration();
        cardModel.InitCardLibary();
        roundModel.InitRound();

        //-----读取数据----------------
       
        GetDaTa();

        //dispatcher.Dispatch(ViewEvent.UPDATE_INTEGRATION, oldData);
    }


    /// <summary>
    /// 读取保存数据
    /// </summary>
    private void  GetDaTa()
    {
        string fileName = Consts.DataPath;
        FileInfo fileInfo = new FileInfo(fileName);
        if (fileInfo.Exists)
        {

         GameData   oldData = Toos.GeyDataWithOutBom();

            //保存数据
            intergrationModel.ComputerLeftIntergration=   oldData.computerLeftIntergration;
            intergrationModel.ComputerRightIntergration = oldData.computerRightIntergration;
            intergrationModel.PlayerIntergration = oldData.playerIntergration;





        }
       

    }


}
