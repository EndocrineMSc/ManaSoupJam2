
//The EnumCollections just needs to be in the project, no GameObject needed
//Can be freely change to suit the project, calls need to be changed
namespace EnumCollection
{   
    public enum GameState
    {
        MainMenu,
        Credits,
        Settings,
        HighscoreMenu,
        Intro,
        Starting,
        Victory,
        GameOver,
        NewGame,
        Quit,
    }

    public enum Track
    {
        MainMenu,
        GameTrackOne,
        GameTrackTwos,
    }

    public enum SFX
    {
        ButtonClick,
        Eule,
        PlayerHitSound,
        PlayerHitSound2,
        MonsterSound,
        Playerdamage1, 
        Feuerknistern,
        Schnarchen1,
        Schnarchen2,
        Grillenzirpen,
        Footsteps,

    }
}