using Newtonsoft.Json;

namespace TankStats.Models
{
    public class UserMedals
    {
        public Achievements achievements { get; set; } //Achievements earned
        public Frags frags { get; set; } //Achievement progress
        public MaxSeries max_series { get; set; } //Maximum values of achievement series
    }

    public class Achievements
    {
        public int medalCarius { get; set; }
        public int medalHalonen { get; set; }
        public int aimer { get; set; }
        public int invader { get; set; }
        public int armorPiercer { get; set; }
        public int medalEkins { get; set; }

        [JsonProperty("06YearsOfService")]
        public int SixYearsOfService { get; set; }

        public int medalKay { get; set; }
        public int duelist { get; set; }
        public int newMeritPM2 { get; set; }
        public int readyForBattleLT { get; set; }
        public int defender { get; set; }
        public int medalLeClerc { get; set; }
        public int demolition { get; set; }
        public int supporter { get; set; }
        public int steelwall { get; set; }
        public int medalBrothersInArms { get; set; }
        public int medalAbrams { get; set; }
        public int armoredFist { get; set; }
        public int medalPoppel { get; set; }
        public int medalPascucci { get; set; }
        public int reliableComrade { get; set; }
        public int luckyDevil { get; set; }
        public int battlePassCommonPr_2 { get; set; }
        public int mainGun { get; set; }
        public int BattlePassCommonPr_1 { get; set; }
        public int Fest19Offspring { get; set; }
        public int sinai { get; set; }
        public int TenYearsCountdownStageMedal { get; set; }
        public int sniper { get; set; }
        public int bonecrusher { get; set; }
        public int scout { get; set; }
        public int titleSniper { get; set; }
        public int ironMan { get; set; }
        public int warrior { get; set; }
        public int even { get; set; }
        public int medalKolobanov { get; set; }
        public int medalLehvaslaiho { get; set; }
        public int beasthunter { get; set; }
        public int handofdeath { get; set; }
        public int medalRadleyWalters { get; set; }
        public int readyForBattleMT { get; set; }
        public int raider { get; set; }
        public int sniper2 { get; set; }
        public int arsonist { get; set; }
        public int charmed { get; set; }
        public int TenYearsCountdownParticipant { get; set; }
        public int fighter { get; set; }
        public int medalLavrinenko { get; set; }
        public int impenetrable { get; set; }
        public int sturdy { get; set; }
        public int kamikaze { get; set; }
        public int medalOrlik { get; set; }
        public int battleCitizen { get; set; }
        public int WFC2014 { get; set; }
        public int shootToKill { get; set; }
        public int medalDumitru { get; set; }
        public int evileye { get; set; }
        public int firstMerit { get; set; }
        public int medalKnispel { get; set; }
    }

    public class Frags
    {
        public int crucialShotMedal { get; set; }
        public int prematureDetonationMedal { get; set; }
        public int sentinelMedal { get; set; }
        public int infiltratorMedal { get; set; }
        public int fightingReconnaissanceMedal { get; set; }
        public int fireAndSteelMedal { get; set; }
        public int reliableComrade { get; set; }
        public int wolfAmongSheepMedal { get; set; }
        public int heavyFireMedal { get; set; }
        public int bruteForceMedal { get; set; }
        public int guerrillaMedal { get; set; }
        public int promisingFighterMedal { get; set; }
        public int pyromaniacMedal { get; set; }
        public int geniusForWarMedal { get; set; }
        public int sinai { get; set; }
        public int beasthunter { get; set; }
        public int pattonValley { get; set; }
    }

    public class MaxSeries
    {
        public int armorPiercer { get; set; }
        public int titleSniper { get; set; }
        public int tacticalBreakthrough { get; set; }
        public int invincible { get; set; }
        public int victoryMarch { get; set; }
        public int deathTrack { get; set; }
        public int EFC2016 { get; set; }
        public int diehard { get; set; }
        public int WFC2014 { get; set; }
        public int handOfDeath { get; set; }
    }
}
