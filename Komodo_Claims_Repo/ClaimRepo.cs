using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Claims_Repo
{
    public class ClaimRepo
    {
        private readonly Queue<Claim> _claimDatabase = new Queue<Claim>();

        // Create
        public void EnqueueToDatabase(Claim claim)
        {
            _claimDatabase.Enqueue(claim);
        }

        // Read
        public Queue<Claim> GetAllClaims()
        {
            return _claimDatabase;
        }

        // Update (Not sure if this is needed, can't tell if it's on the assignment.)
        public bool UpdateClaim(int oldClaimID, Claim newClaim)
        {
            Claim oldClaim = GetClaimByID(oldClaimID);
            if (oldClaim != null)
            {
                oldClaim.ClaimID = newClaim.ClaimID;
                oldClaim.ClaimType = newClaim.ClaimType;
                oldClaim.Description = newClaim.Description;
                oldClaim.ClaimAmount = newClaim.ClaimAmount;
                oldClaim.DateOfIncident = newClaim.DateOfIncident;
                oldClaim.DateOfClaim = newClaim.DateOfClaim;
                oldClaim.IsValid = newClaim.IsValid;
                return true;
            }
            else
            {
                return false;
            }
        }

        private Claim GetClaimByID(int oldClaimID)
        {
            foreach (var claim in _claimDatabase)
            {
                if (claim.ClaimID == oldClaimID)
                {
                    return claim;
                }
            }
            return null;
        }

        // Delete
        public bool DequeueClaim()
        {
            if (_claimDatabase.Count>0)
            {
                _claimDatabase.Dequeue();
                return true;
            }
            else
            {
                return false;
            }   
        }

        // Helper Method
        public Claim ViewCurrentClaim()
        {
           return  _claimDatabase.Peek();
        }

        // Helper Method
        public bool IsClaimValid(DateTime inputDateofIncident, DateTime inputDateofClaim,int validationTimeInDays)
        {
            int answer = inputDateofIncident.Day - inputDateofClaim.Day;
          //Console.WriteLine("answer:" + " "+answer);
            if (answer <= validationTimeInDays && answer>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //other version using a Timespan
        public bool IsClaimValid2(DateTime inputDateofIncident, DateTime inputDateofClaim, int validationTimeInDays)
        {
            var answer = inputDateofIncident - inputDateofClaim;
            //Console.WriteLine("answer:" + " "+answer);
            var condition = TimeSpan.FromDays(answer.Days);

            if (condition.Days <= validationTimeInDays && condition.Days >0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}