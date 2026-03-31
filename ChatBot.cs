using CyberSecurity_Awareness_Bot;
using System;
using System.Media;
using System.Threading;

namespace CyberSecurityBot
{
    public class ChatBot
    {
        private User user = new User();

        public void Start()
        {
            PlayVoiceGreeting();
            DisplayLogo();
            GetUserName();
            WelcomeMessage();
            ChatLoop();
        }

        private void PlayVoiceGreeting()
        {
            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync(); // Plays before continuing
            }
            catch
            {
                Console.WriteLine("⚠️ Audio file not found.");
            }
        }

        private void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("===========================================");
            Console.WriteLine("   🔐 CYBERSECURITY AWARENESS BOT 🔐");
            Console.WriteLine("===========================================");

            Console.WriteLine(@"
      /\
     /  \    🔒
    /----\   STAYING 
   /      \   SAFE
  /        \  ONLINE
 /    ____  \
            ");

            Console.ResetColor();
        }

        private void GetUserName()
        {
            Console.Write("\nEnter your name: ");
            user.Name = Console.ReadLine();

            // Input validation
            while (string.IsNullOrWhiteSpace(user.Name))
            {
                Console.Write("Name cannot be empty. Try again: ");
                user.Name = Console.ReadLine();
            }
        }

        private void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            TypeEffect($"\nHello {user.Name}! 👋 Welcome to the Cybersecurity Awareness Bot.");
            Console.ResetColor();
        }

        private void ChatLoop()
        {
            string input;

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n{user.Name}: ");
                Console.ResetColor();

                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    InvalidResponse();
                    continue;
                }

                // String manipulation
                input = input.ToLower().Trim();

                if (input.Contains("exit"))
                {
                    Goodbye();
                    break;
                }

                Respond(input);
            }
        }

        private void Respond(string input)
        {
            if (input.Contains("how are you"))
            {
                TypeEffect("I'm just a bot, but I'm here to keep you safe online! 😊");
            }
            else if (input.Contains("purpose"))
            {
                TypeEffect("My purpose is to educate you about cybersecurity and help you stay safe online.");
            }
            else if (input.Contains("what can i ask"))
            {
                TypeEffect("You can ask me about password safety, phishing, and safe browsing.");
            }
            else if (input.Contains("password"))
            {
                TypeEffect("Use strong passwords with uppercase, lowercase, numbers, and symbols. Never reuse passwords!");
            }
            else if (input.Contains("phishing"))
            {
                TypeEffect("Phishing is when attackers trick you into giving personal info. Always verify emails and links.");
            }
            else if (input.Contains("browsing"))
            {
                TypeEffect("Always use secure websites (HTTPS) and avoid clicking suspicious links.");
            }
            else
            {
                InvalidResponse();
            }
        }

        private void InvalidResponse()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            TypeEffect("I didn’t quite understand that. Could you rephrase?");
            Console.ResetColor();
        }

        private void Goodbye()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            TypeEffect($"Goodbye {user.Name}! Stay safe online! 🔐");
            Console.ResetColor();
        }

        // Typing effect
        private void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
    }
}