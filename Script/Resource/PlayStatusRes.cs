using Godot;
using System;

public partial class PlayStatusRes : Resource
{
    public enum PlayStatusEnum 
    {
        NONE = 0,
        IntroDialogue,// Introduction de la piece , prologue  1
        Act1Presentation, // Leve de rideau Explique la premiere epreuve a faire , partir vers le chateau 2
        Act1Gameplay,// Gameplay , 1 phrase durant la run 2
        Act1Entracte, // Fermeture de rideau petite conclusion de la run 3
        Act2Presentation, // Leve de rideau Explique la deuxieme epreuve a faire , survivre la nuit sur le camp de fortune 4
        Act2Gameplay,// Gameplay , 1 phrase durant la run en fonction de ce qui se passe 4
        Act2Entracte, // Fermeture de rideau petite conclusion de la run 5
        Act3Presentation,// Leve de rideau Explique la troisieme epreuve a faire , grimper le chateau 6
        Act3Gameplay,// Gameplay, 1 phrase durant la run 6
        Act3Conclusion, // le joueur rencontre la princesse , cinematique de fin en fonction de la run en entier 7
        Epilogue // Fermeture de rideau , petit texte de la naratrice , transition vers le title screen . 8
    }

    public CurrentPlayStatus currentPlay { get; private set; }

    public void StartNewRun()
    {
        currentPlay = new CurrentPlayStatus(PlayStatusEnum.NONE);
    }

    public void OnCurrentPlayEnd()
    {
        currentPlay.NextPlay();
    }

}
