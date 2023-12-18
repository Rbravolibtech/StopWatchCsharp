using System;

namespace StopwatchApp
{
    public class Stopwatch
    {
        private DateTime _startTime;
        private DateTime _stopTime;
        private bool _isRunning;

        public void Start()
        {
            if (_isRunning)
            {
                throw new InvalidOperationException("Stopwatch is already running.");
            }

            _startTime = DateTime.Now;
            _isRunning = true;
            Console.WriteLine("Stopwatch started.");
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                throw new InvalidOperationException("Stopwatch is not running.");
            }

            _stopTime = DateTime.Now;
            _isRunning = false;
            Console.WriteLine("Stopwatch stopped. Duration: " + GetDuration());
        }

        private TimeSpan GetDuration()
        {
            return _stopTime - _startTime;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();

            try
            {
                stopwatch.Start();
                // Simulate some work
                System.Threading.Thread.Sleep(2000);
                stopwatch.Stop();

                // Simulate some more work
                System.Threading.Thread.Sleep(1000);

                // Start and stop again
                stopwatch.Start();
                System.Threading.Thread.Sleep(1500);
                stopwatch.Stop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
