using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RetrieveWorkerData;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections;
using System.Text.RegularExpressions;

namespace WorkersDataUnitTests
{ 
    [TestClass]
    public class UnitTestWorkerData
    {
        [TestMethod]
        public void CorrectUpperCase()
        {
            //Arrange data
            Dictionary<string, string> examples = new Dictionary<string, string>() {
                { "Iwona", "iwona" }, //regular name
                { "Patrice-Ariel", "PATRICE-ARIEL" }, //double name

                { "Raczkowska-Rój", "raczkowska-rój" }, //double-barrelled surname
                { "Crav-O-Lerouy", "crav-o-lerouy" },
                { "Thurlow-Cumming", "thurlow-cumming" },

                { "Coeur D'Borguex", "coeur d'borguex" },
                { "O'Docolores", "o'docolores" },
                { "O'Brien", "o'brien" },

                { "Le Goff", "LE GOFF" },
                { "De Mello Breyner Andersen", "DE MELLO BREYNER ANDERSEN" }

                //MacDonald, McKeyneh

            };

            foreach(var person in examples)
            {
                //Assert
                Assert.AreEqual( person.Key, person.Value.SurnameNameFormat());
            }
           
        }


        [TestMethod]
        public void TestFindWorkerDataInString()
        {

        Dictionary<worker, string> workers = new Dictionary<worker, string>()
            {
                { new worker("Elżbieta", "Newman", 4 ), @"Elżbieta Newman dep 4" },
                { new worker("Jonathan", "Newman", 4 ), @"Jonathan Newman 04.png" },
                { new worker("Blake", "Evans", 1 ), @"BLAKE EVANS dep no 1" } ,
                { new worker("Eve", "Raczkowska-Rój", 12 ), @"eve raczkowska-rój dep12.png" },
                { new worker("Barthélemy", "Derocles", 908 ), @"Barthélemy Derocles dep 908" },
                { new worker("Patrice-Ariel", "Bruguière", 0 ), @"Patrice-Ariel Bruguière" }
            };

            foreach (var person in workers)
            {
                var formatted = RetrieveWorkerData.Program.FindWorkerDataInString(person.Value);
                Assert.IsTrue(formatted == person.Key);
            }

        }

        [TestMethod]
        public void DeleteUnnecessaryWhitespaces()
        {
            //Arrange data
            Dictionary<string, string> examples = new Dictionary<string, string>() {
                { "Iwona ", "Iwona" }, //regular name
                { "Patrice -  Ariel", "Patrice-Ariel" }, //double name
                { "Raczkowska - Rój", "Raczkowska-Rój" }, //double-barrelled surname
                { "Crav - O - Lerouy", "Crav-O-Lerouy" },
                { "Thurlow  -Cumming  -Bruce ", "Thurlow-Cumming-Bruce"},
                { "o '     Brien", "O'Brien"},
                { "De      Mello  Breyner  Andersen", "De Mello Breyner Andersen"}
            };

            foreach (var e in examples)
            {
                string result = Regex.Replace(e.Key, @"\s+", " ");
                result = result.Trim();
                Assert.AreEqual(e.Value, result);
            }
          
        }


    }
}
