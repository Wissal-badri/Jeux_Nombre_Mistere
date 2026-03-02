//IMportation de l'espace de noms System pour utiliser les fonctionnalités de base du langage C# (comme Console)
using System;
//Declaration de l'espace de noms pour organiser le code et éviter les conflits de noms
namespace JeuxNombreM;
//Declaration de la classe Program qui contient le point d'entrée du programme
class Program
{
    static void Main(string[] args)
    {
        // Affichage d'un message de bienvenue pour le joueur
        Console.WriteLine("=== Bienvenue dans le jeu du nombre mystère ! ===");
        
        // Création d'une instance de la classe Game pour commencer le jeu
        Game game = new Game();
        game.Start();
    }
}