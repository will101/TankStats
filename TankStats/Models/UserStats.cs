namespace TankStats.Models
{
    public class UserStats
    {
        public string client_language { get; set; }
        public int last_battle_time { get; set; }
        public int account_id { get; set; }
        public int created_at { get; set; }
        public int updated_at { get; set; }
        public object _private { get; set; }
        public int global_rating { get; set; }
        public int clan_id { get; set; }
        public Statistics statistics { get; set; }
        public string nickname { get; set; }
        public int logout_at { get; set; }
    }

    public class Statistics
    {
        public Clan clan { get; set; }
        public All all { get; set; }
        public Regular_Team regular_team { get; set; }
        public int trees_cut { get; set; }
        public Company company { get; set; }
        public Stronghold_Skirmish stronghold_skirmish { get; set; }
        public Stronghold_Defense stronghold_defense { get; set; }
        public Historical historical { get; set; }
        public Team team { get; set; }
        public object frags { get; set; }
    }

    public class Clan
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public float avg_damage_blocked { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public float avg_damage_assisted_track { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public float avg_damage_assisted_radio { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class All
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public float avg_damage_blocked { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public int max_damage_tank_id { get; set; }
        public TankDetails MaxDamageTank { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public int max_xp_tank_id { get; set; }
        public TankDetails MaxXpTank { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public int max_frags_tank_id { get; set; }
        public TankDetails MaxKillsTank { get; set; }
        public float avg_damage_assisted_track { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public float avg_damage_assisted_radio { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int max_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class Regular_Team
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public float avg_damage_blocked { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public object max_damage_tank_id { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public object max_xp_tank_id { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public object max_frags_tank_id { get; set; }
        public float avg_damage_assisted_track { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public float avg_damage_assisted_radio { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int max_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class Company
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public float avg_damage_blocked { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public float avg_damage_assisted_track { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public float avg_damage_assisted_radio { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class Stronghold_Skirmish
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public int max_xp_tank_id { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public int max_frags_tank_id { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int max_damage_tank_id { get; set; }
        public int max_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class Stronghold_Defense
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public object max_xp_tank_id { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public object max_frags_tank_id { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public object max_damage_tank_id { get; set; }
        public int max_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class Historical
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public float avg_damage_blocked { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public object max_damage_tank_id { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public object max_xp_tank_id { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public object max_frags_tank_id { get; set; }
        public float avg_damage_assisted_track { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public float avg_damage_assisted_radio { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int max_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }

    public class Team
    {
        public int spotted { get; set; }
        public int battles_on_stunning_vehicles { get; set; }
        public int max_xp { get; set; }
        public float avg_damage_blocked { get; set; }
        public int direct_hits_received { get; set; }
        public int explosion_hits { get; set; }
        public int piercings_received { get; set; }
        public int piercings { get; set; }
        public int max_damage_tank_id { get; set; }
        public int xp { get; set; }
        public int survived_battles { get; set; }
        public int dropped_capture_points { get; set; }
        public int hits_percents { get; set; }
        public int draws { get; set; }
        public int max_xp_tank_id { get; set; }
        public int battles { get; set; }
        public int damage_received { get; set; }
        public float avg_damage_assisted { get; set; }
        public int max_frags_tank_id { get; set; }
        public float avg_damage_assisted_track { get; set; }
        public int frags { get; set; }
        public int stun_number { get; set; }
        public float avg_damage_assisted_radio { get; set; }
        public int capture_points { get; set; }
        public int stun_assisted_damage { get; set; }
        public int max_damage { get; set; }
        public int hits { get; set; }
        public int battle_avg_xp { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int damage_dealt { get; set; }
        public int no_damage_direct_hits_received { get; set; }
        public int max_frags { get; set; }
        public int shots { get; set; }
        public int explosion_hits_received { get; set; }
        public float tanking_factor { get; set; }
    }


}


