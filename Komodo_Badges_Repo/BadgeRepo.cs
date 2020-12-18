using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Badges_Repo
{
    public class BadgeRepo
    {
        private readonly Dictionary<int, Badge> _dictionaryBadgeDatabase
            = new Dictionary<int, Badge>();

        int Count = 0;
        // Create
        public void AddToDatabase(Badge badge)
        {
            // Count ++ <- This prevent duplicate same key values.
            Count++;
            _dictionaryBadgeDatabase.Add(Count, badge); // <- Want to use Count here instead of BadgeID, "automate" this to prevent errors in program.
        }

        // Read
        public Dictionary<int, Badge> GetAllBadges()
        {
            return _dictionaryBadgeDatabase;
        }

        // Update
        public bool UpdateBadge(int dictKey, Badge newBadge)
        {
            Badge oldBadge = GetBadgeByKey(dictKey);
            if (oldBadge != null)
            {
                oldBadge.BadgeID = newBadge.BadgeID;
                oldBadge.Doors = newBadge.Doors;
               
                return true;
            }
            else
            {
                return false;
            }
        }
        // Remember, KEYS & VALUES, are attached together.
        // Helper Method
        public Badge GetBadgeByKey(int dictKey)
        {
            foreach (var badge in _dictionaryBadgeDatabase)
            {
                if (badge.Key == dictKey)
                {
                    return badge.Value;
                }
            }
            return null;
        }

        // Delete
        // Helper Method
        public bool RemoveDoor(int dictKey, string doorName)
        {
            Badge badge = GetBadgeByKey(dictKey);
            if (badge != null)
            {
                foreach (var door in badge.Doors)
                {
                    if (door == doorName)
                    {
                        badge.Doors.Remove(door);
                        return true;
                    }
                }
            }
            return false;   
        }
    }
}