using strange.extensions.context.api;
using strange.extensions.context.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 事件的帮订
/// </summary>
public class GameContext : MVCSContext
{
    public GameContext(MonoBehaviour view, bool autoMapping) : base(view, autoMapping)
		{


    }

    /// <summary>
    /// 绑定映射
    /// </summary>
    protected override void mapBindings()
    {   //------------------------------------------------------------------------
        //注册这个累，绑定这个累，让他和自身做绑定，让后给个单利，然后可以在所有的Controller访问
        injectionBinder.Bind<IntegrationModel>().To<IntegrationModel>().ToSingleton();
        injectionBinder.Bind<CardModel>().To<CardModel>().ToSingleton();
        injectionBinder.Bind<RoundModel>().To<RoundModel>().ToSingleton();
      
        //------------------------------------------------------------------------

        mediationBinder.Bind<InteractionView>().To<InteractionMediator>();
      mediationBinder.BindView<StartView>().ToMediator<StartMediator>();
        mediationBinder.Bind<CharacterView>().To<CharacterMediator>();
        mediationBinder.Bind<GameOverView>().To<GameOverMediator>();

        Debug.Log("启动框架");
        //------------------------------------------------------------------------
        //将开始命令映射到枚举ContextEvent.START上
        commandBinder.Bind(ContextEvent.START).To<StartCommand>().Once();
        commandBinder.Bind(CommandEvent.RequestDeal).To<RequestDealCommand>();
        //将发送的事件，于command绑定
        commandBinder.Bind(CommandEvent.ChangeMulitiple).To<ChangeMultipleCommand>();
        commandBinder.Bind(CommandEvent.GrabLandLord).To<GrabLandlordCommand>();//发这个CommandEvent.GrabLandLord创建命令执行命令里面的方法
        commandBinder.Bind(CommandEvent.PlayCard).To<PlayCardCommand>();
        commandBinder.Bind(CommandEvent.PassCard).To<PassCardCommand>();
        commandBinder.Bind(CommandEvent.GameOver).To<GameOverCommand>();
        commandBinder.Bind(CommandEvent.RequestUpdate).To<UpdateCommand>();

    }


}
