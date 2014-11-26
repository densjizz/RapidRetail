using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoreTest
{
    [TestClass]
    public class RessourceTest
    {
        [TestMethod]
        public void RessourceBoard_SellRemove_Test()
        {
            //Arrange
            RessourceBoard b = new RessourceBoard();


            //Act
            b.RemoveRessource(b.Metal);
            int money1 = b.SellRessource(b.Metal);

            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            int money2 = b.SellRessource(b.Metal);
            b.SellRessource(b.Metal);

            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            int money3 = b.SellRessource(b.Metal);
            b.SellRessource(b.Metal);
            b.SellRessource(b.Metal);


            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            b.RemoveRessource(b.Metal);
            int transact8 = b.SellRessource(b.Metal);
            int transact7 = b.SellRessource(b.Metal);
            int transact6 = b.SellRessource(b.Metal);
            int transact5 = b.SellRessource(b.Metal);
            int transact4 = b.SellRessource(b.Metal);
            int transact3 = b.SellRessource(b.Metal);
            int transact2 = b.SellRessource(b.Metal);
            int transact1 = b.SellRessource(b.Metal);



            //Assert
            Assert.IsTrue(money1 == 1);
            Assert.IsTrue(money2 == 2);
            Assert.IsTrue(money3 == 2);


            Assert.IsTrue(transact1 == 1);
            Assert.IsTrue(transact2 == 2);
            Assert.IsTrue(transact3 == 2);
            Assert.IsTrue(transact4 == 3);
            Assert.IsTrue(transact5 == 3);
            Assert.IsTrue(transact6 == 4);
            Assert.IsTrue(transact7 == 4);
            Assert.IsTrue(transact8 == 5);

        }
    }
}
