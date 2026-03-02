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
        // Demande à l'utilisateur d'entrer un nombre et le retourne sous forme d'entier
        private int GetUserGuess()
        {
            Console.Write("Veuillez entrer un nombre : ");
            int guess;
            // Boucle de validation pour s'assurer que l'utilisateur saisit un nombre entier valide
            while (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.WriteLine("Entrée invalide. Veuillez entrer un nombre entier : ");
                Console.Write("Veuillez entrer un nombre : ");
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
            // Génération du nombre cible (par exemple, entre 1 et 100)
            int target = GenerateRandomNumber(1, 100);
            bool found = false;
            // Boucle infinie jusqu'à ce que l'utilisateur trouve le nombre cible
            // (Assure un nombre infini de tentatives)
            while (!found)
            {
                int guess = GetUserGuess();
                found = CheckGuess(guess, target);
            }
            Console.WriteLine("Merci d'avoir joué !");
        }
    }
}