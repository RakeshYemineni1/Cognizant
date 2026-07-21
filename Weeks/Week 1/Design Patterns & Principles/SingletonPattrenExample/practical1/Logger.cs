using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        // Private static instance of itself
        private static Logger? _instance;
        private static readonly object _lock = new object();

        // Ensure the constructor of Logger is private
        private Logger()
        {
        }

        // Public static method to get the instance of the Logger class
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logger();
                    }
                }
            }
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[Log]: {message}");
        }
    }
}
