using Komodo_Claims_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Komodo_Claims_Tests
{
    [TestClass]
    public class UnitTest1
    {
        ClaimRepo _claimRepo;
        Claim _claim;
        Queue<Claim> _claimItems;
        
        [TestInitialize]
        public void Arrange()
        {
            _claimRepo = new ClaimRepo();
            _claim = new Claim(1, ClaimType.Car, "crash", 400.00m, new DateTime(2020, 12, 15), new DateTime(2020, 12, 16));
            _claimRepo.EnqueueToDatabase(_claim);
            _claimItems = _claimRepo.GetAllClaims();
        }
       

        [TestMethod]
        public void EnqueueToDatabase()
        {
            int expected = 1;
            Assert.AreEqual(expected, _claimItems.Count);

        }

        [TestMethod]
        public void GetAllClaims()
        {
            //Arrange
          Claim  _claim1 = new Claim(1, ClaimType.Car, "crash", 400.00m, new DateTime(2020, 12, 15), new DateTime(2020, 12, 16));
          Claim  _claim2 = new Claim(1, ClaimType.Car, "crash", 400.00m, new DateTime(2020, 12, 15), new DateTime(2020, 12, 16));

            _claimRepo.EnqueueToDatabase(_claim1);
            _claimRepo.EnqueueToDatabase(_claim2);

            int expected = 3;

            //Assert
            Assert.AreEqual(expected, _claimItems.Count);
        }

        [TestMethod]
        public void UpdateClaim()
        {
            Claim newClaim = new Claim(1, ClaimType.Home, "crash", 400.00m, new DateTime(2020, 12, 15), new DateTime(2020, 12, 16));

            _claimRepo.UpdateClaim(1, newClaim);

            Assert.IsTrue(newClaim.ClaimType == ClaimType.Home);
        }

        [TestMethod]
        public void ViewCurrentClaim()
        {
            Claim claim = _claimRepo.ViewCurrentClaim();
            Assert.IsTrue(claim.ClaimType == ClaimType.Car && claim.ClaimID==1);
        }

        [TestMethod]
        public void DequeueClaim()
        {
            int expected = 0;
            _claimRepo.DequeueClaim();
            Assert.AreEqual(expected, _claimItems.Count);
        }
    }
}
