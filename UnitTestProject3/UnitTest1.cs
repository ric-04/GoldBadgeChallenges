using Komodo_Badges_Repo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        BadgeRepo _badgeRepo;
        Badge _badge;
        Dictionary<int, Badge> _badgesDict;

        [TestInitialize]

        public void Arrange()
        {
            _badgeRepo = new BadgeRepo();
            _badge = new Badge(1, new List<string> { "A1", "A2", "A3" });
            _badgeRepo.AddToDatabase(_badge);
            _badgesDict = _badgeRepo.GetAllBadges();
        }

        [TestMethod]
        public void AddToDatabase()
        {
            int expected = 1;
            Assert.AreEqual(expected, _badgesDict.Count);
        }

        [TestMethod]
        public void GetAllBadges()
        {
           Badge _badge1 = new Badge(1, new List<string> { "A1", "A2", "A3","A4" });
           Badge _badge2 = new Badge(1, new List<string> { "A2", "A3", "A4" });
           Badge _badge3 = new Badge(1, new List<string> { "A3", "A4", "A5" });

            _badgeRepo.AddToDatabase(_badge1);
            _badgeRepo.AddToDatabase(_badge2);
            _badgeRepo.AddToDatabase(_badge3);

            int expected = 4;
            Assert.AreEqual(expected, _badgesDict.Count);
        }

        [TestMethod]
        public void UpdateBadges()
        {
            Badge _badge1 = new Badge(1, new List<string> { "A1", "A2", "A3", "A4" });

            bool isSuccessful= _badgeRepo.UpdateBadge(1, _badge1);

            // Console.WriteLine & Output to get visual clues for troubleshooting
            Console.WriteLine(_badgesDict.Count);
            Console.WriteLine(_badgeRepo.GetBadgeByKey(1));
            Console.WriteLine($"{_badge1.BadgeID}");

            foreach (var door in _badge1.Doors)
            {
                Console.WriteLine(door);
            }
            Assert.IsTrue(isSuccessful);
        }

        [TestMethod]
        public void GetBadgeByKey()
        {
            Badge _badge1 = new Badge(1, new List<string> { "A1", "A2", "A3"});
            Badge _badge2= new Badge(1, new List<string> { "A2", "A3", "A4"});
            Badge _badge3 = new Badge(1, new List<string> { "A3", "A4", "A5"});
            Badge _badge4 = new Badge(1, new List<string> { "A4", "A5", "A6"});

            _badgeRepo.AddToDatabase(_badge1);
            _badgeRepo.AddToDatabase(_badge2);
            _badgeRepo.AddToDatabase(_badge3);
            _badgeRepo.AddToDatabase(_badge4);
            
            foreach (var item in _badgesDict.Keys)
            {
                Console.WriteLine(item);
            }

            Assert.IsTrue(_badgesDict.ContainsKey(2));
        }

        [TestMethod]
        public void RemoveDoor()
        {
           bool isSuccessful = _badgeRepo.RemoveDoor(1, "A1");
            Assert.IsTrue(isSuccessful);
        }
    }
}