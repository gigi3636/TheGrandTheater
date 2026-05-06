using Godot;
using System.Collections.Generic; 

public static class TextParser
{
    public static Dictionary<string, string> ChargerDictionnaireDepuisTxt(string cheminFichier)
    {
        var dictionnaire = new Dictionary<string, string>();

        if (!FileAccess.FileExists(cheminFichier)) return dictionnaire;

        using var fichier = FileAccess.Open(cheminFichier, FileAccess.ModeFlags.Read);

        while (!fichier.EofReached())
        {
            string ligne = fichier.GetLine().Trim();

            if (string.IsNullOrEmpty(ligne) || !ligne.Contains(';')) continue;

            string[] parties = ligne.Split(';', 2);

            string cle = parties[0].Trim();
            string texte = parties[1].Trim();

            dictionnaire[cle] = texte;
        }

        return dictionnaire;
    }
}