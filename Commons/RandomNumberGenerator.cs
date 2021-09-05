using System;


namespace CSharpApi.Commons
{
    public class RandomNumberGenerator
    {
        private readonly Random _random = new Random();

        /// <summary>
        /// Generates a random integer
        /// </summary>
        /// <param name=min">The minimum value for the range of random number</param>
        /// <param name=max">The maximum value for the range of random number</param>
        /// <returns>int</returns>
        public int GenerateId(int min=0, int max=100000)
        {
            
            return _random.Next(min, max);
        }

}
}
