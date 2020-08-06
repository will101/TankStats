namespace TankStats.Models
{
    public class UserStats
    {
        public Statistics statistics { get; set; }
        public int global_rating { get; set; }
    }

    public class Statistics
    {
        public All all { get; set; }
        public int trees_cut { get; set; }
    }


    public class All
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public float avg_damage_blocked { get; set; }
        public int explosion_hits { get; set; }
        public int max_damage_tank_id { get; set; }
        public TankDetails MaxDamageTank { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int hits_percents { get; set; }
        public int max_xp_tank_id { get; set; }
        public TankDetails MaxXpTank { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public int max_frags_tank_id { get; set; }
        public TankDetails MaxKillsTank { get; set; }
        public int frags { get; set; }
        public int max_damage { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public decimal win_percent { get; set; }
   }
}


