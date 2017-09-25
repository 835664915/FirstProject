using strange.extensions.command.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMultipleCommand : EventCommand
{
    /// <summary>
    /// 通过反射获取到了IntergrationModel,改变倍数的命令
    /// </summary>
    [Inject]
    public IntegrationModel intergrationModel { get; set; }

    
    /// <summary>
    /// 接受来自
    /// </summary>
    public override void Execute()
    {

        //将倍数传到数据模块
        int multiple = (int)evt.data;
        Debug.Log(intergrationModel.Multiples+"   "+intergrationModel.BasePoint+"   "+intergrationModel.Result);
      
        intergrationModel.Multiples = multiple;


        //------------------点击完双倍单倍之后就开始游戏了----------------------
        Toos.CreateUIpanel(PanelType.BackgroundPanel);
        Toos.CreateUIpanel(PanelType.CharacterPanel);
        Toos.CreateUIpanel(PanelType.InteractionPanel);
     



    }



}
