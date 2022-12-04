
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
        Playerdamage1,
        Playerdamage2, 
        MonsterSound,
        PlayerHitSound,
        Feuerknistern,
        Schnarchen1,
        Schnarchen2,
        Grillenzirpen,
        Footsteps,

    }
}