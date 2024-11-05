using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class TeamModel
    {
        // ---Properties---
        public int Id { get; set; }
        public string? TeamName { get; set; }
        public  List<PersonModel>? TeamMembers { get; set; } = new List<PersonModel>();

        public List<PrizeModel>? Prizes { get; set; } = new List<PrizeModel>();
        public List<MatchupModel>? Matchups { get; set; } = new List<MatchupModel>();


        // ---Methods---
        public int TeamSize() => TeamMembers.Count;

        public void AddMember(PersonModel person)
        {
            TeamMembers.Add(person);
        }


    }
}
