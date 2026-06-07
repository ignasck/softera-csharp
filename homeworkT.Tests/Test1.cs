using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using homeworkT;

namespace homeworkT.Tests
{
    [TestClass]
    public class TaskUtilsTests
    {
        [TestMethod]
        public void CalculateResults_ValidData_ReturnsCorrectScores()
        {
            // 1. Arrange (Pasiruošiam testinius duomenis)
            var participants = new List<Data>
            {
                new Data(1, new int[] { 5, 5 }), // 1 kategorija = 10 taškų
                new Data(2, new int[] { 10 })    // 2 kategorija = 10 taškų
            };
            int totalParticipants = 5;

            // 2. Act (Iškviečiam  metodą iš Program.cs)
            int[] results = TaskUtils.CalculateResults(participants, totalParticipants, out bool isValid);

            // 3. Assert (Tikrinam ar teisingai suskaičiavo)
            Assert.IsTrue(isValid);
            Assert.AreEqual(10, results[1]);
            Assert.AreEqual(10, results[2]);
            Assert.AreEqual(0, results[3]);
        }

        [TestMethod]
        public void MinMax_IgnoresZeros_FindsCorrectMinAndMax()
        {
            // 1. Arrange (Sukuriam testinį rezultatų masyvą)
            int[] testScores = new int[11];
            testScores[2] = 100; // Max kategorija
            testScores[5] = 20;  // Min kategorija
            testScores[8] = 0;   // Nežaista kategorija (turi ignoruoti!)

            // 2. Act (Iškviečiam MinMax metodą)
            TaskUtils.MinMax(testScores, out int min, out int max, out string maxCat, out string minCat);

            // 3. Assert (Tikrinam ar teisingai rado min ir max, ignoruodamas 0)
            Assert.AreEqual(100, max);
            Assert.AreEqual("2", maxCat);  
            Assert.AreEqual(20, min);
            Assert.AreEqual("5", minCat);  
        }
    }
}