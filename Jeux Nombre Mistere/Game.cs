// Ce code définit la classe Game qui contient la logique du jeu "Jeu du Nombre Mystère".
using System;
//Declaration de l'espace de noms pour organiser le code et éviter les conflits de noms
namespace JeuxNombreM
{
    // La classe Game encapsule toute la logique du jeu, y compris la génération du nombre mystère, la gestion des entrées utilisateur et les vérifications des propositions
    internal class Game
    {
        // Instance de la classe Random pour générer des nombres aléatoires
        private Random random = new Random();
        // Génère et retourne un nombre aléatoire entre min et max (inclus)
        private int GenerateRandomNumber(int min, int max)
        {
            return random.Next(min, max + 1);
        }
        // Demande à l'utilisateur d'entrer un nombre et le retourne sous forme d'entier (avec validation des bornes)
        private int GetUserGuess(int min, int max)
        {
            Console.Write($"Veuillez entrer un nombre entre {min} et {max} : ");
            int guess;
            // Boucle de validation pour s'assurer que l'utilisateur saisit un nombre entier valide
            while (!int.TryParse(Console.ReadLine(), out guess) || guess < min || guess > max)
            {
                Console.WriteLine($"Entrée invalide. Le nombre doit être compris entre {min} et {max}.");
                Console.Write($"Veuillez entrer un nombre entre {min} et {max} : ");
            }
            return guess;
        }
        // Compare la proposition de l'utilisateur avec le nombre cible et affiche un message
        private bool CheckGuess(int guess, int target)
        {
            if (guess < target)
            {
                Console.WriteLine("C'est plus grand !");
                return false;
            }
            else if (guess > target)
            {
                Console.WriteLine("C'est plus petit !");
                return false;
            }
            else
            {
                Console.WriteLine("Bravo ! Vous avez trouvé le nombre mystère !");
                return true;
            }
        }
        // Exécute la logique principale du jeu avec un nombre infini de tentatives
        internal void Start()
        {
            // Définition des bornes
            int min = 1;
            int max = 100;
            
            // Génération du nombre cible (par exemple, entre 1 et 100)
            int target = GenerateRandomNumber(min, max);
            bool found = false;
            // Boucle infinie jusqu'à ce que l'utilisateur trouve le nombre cible
            // (Assure un nombre infini de tentatives)
            while (!found)
            {
                int guess = GetUserGuess(min, max);
                found = CheckGuess(guess, target);
            }
            Console.WriteLine("Merci d'avoir joué !");
        }
    }
}