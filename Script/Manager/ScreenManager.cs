using Godot;
using System.Collections.Generic;

public partial class ScreenManager : Node
{
    #region Screen Exports
    [Export] PackedScene sceneSplashScreen;
    [Export] PackedScene sceneTitleScreen;
    [Export] PackedScene sceneCollectionScreen;
    [Export] PackedScene sceneHelpScreen;
    [Export] PackedScene sceneCreditsScreen;
    [Export] PackedScene sceneWinScreen;
    [Export] PackedScene sceneGameScreen;

    #endregion


    private List<PackedScene> scenesList;

    private List<Screen> sceneRefList;

    [Export] Node sceneContainerRef;

    // Info of the current player name and level unlocked
    //[Export] private CurrentPlayerData currentPlayerData;

    public enum SceneEnum
    {
        SplashScreen,
        TitleScreen,
        Collection,
        Help,
        Credit,
        WinScreen,
        GameScreen
    }

    public override void _Ready()
    {
        scenesList = new List<PackedScene> { sceneSplashScreen,  sceneTitleScreen, sceneCollectionScreen , sceneHelpScreen,
        sceneCreditsScreen,sceneWinScreen, sceneGameScreen  };
        CreateScene();
    }

    // Create all the scene at the start of the game 
    private void CreateScene()
    {
        sceneRefList = new List<Screen>();
        foreach (PackedScene lScene in scenesList)
        {
            Screen lCurentScene = (Screen)lScene.Instantiate();
            sceneContainerRef.AddChild(lCurentScene);
            lCurentScene.CloseScene();
            lCurentScene.Initialize(this);
            sceneRefList.Add(lCurentScene);
        }

        sceneRefList[1].LoadScene();

    }

    // On remplace 'void' par 'bool'
    public bool SwitchScreen(SceneEnum pSceneEnum)
    {

        Screen lCurrentScreen = sceneRefList[(int)pSceneEnum];

        //if (lCurrentScreen is WinScreen winScreen)
        //{
        //    winScreen.InitializeLevelPar(pCurrentLevelPar, pLevelId);
        //}

        lCurrentScreen.LoadScene();

        //if (lCurrentScreen is GameScreen gameScreen)
        //{
        //    gameScreen.gridManagerRef.CreateLevel(pLevelId);
        //}

        return true;
    }
}
