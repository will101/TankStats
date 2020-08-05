﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TankStats.Data;
using TankStats.Data.Repositories;
using TankStats.Extensions;
using TankStats.Models;
using TankStats.Models.ViewModels;
using static TankStats.TankConstants;

/** TODO:
 * Refactor medals section from line 103 to 176
 * Split apiHelper class out into more useful files if necessary
 * Add comparison for up to 3 players
 * Add win ratio and wn8 if you can find calculations for them
 * Overhaul front end with react or angular
 * */

namespace TankStats.Services
{
    public class ApiService
    {
        private readonly UserRepository _userRepository;
        private readonly TankRepository _tankRepository;
        private readonly MedalRepository _medalRepository;
        private readonly StatisticsRepository _statisticsRepository;

        public ApiService(UserRepository userRepository, StatisticsRepository statisticsRepository, TankRepository tankRepository, MedalRepository medalRepository)
        {
            _userRepository = userRepository;
            _tankRepository = tankRepository;
            _medalRepository = medalRepository;
            _statisticsRepository = statisticsRepository;
        }


        public async Task<User> GetPersonalData(string Username)
        {
            User foundUser = await _userRepository.GetPersonalData(Username);

            return foundUser;
        }

        public async Task<UserStats> GetUserStats(string AccountId)
        {
            UserStats serializedStats = await _statisticsRepository.GetUserStats(AccountId);

            //add tank names in 
            All all = serializedStats.statistics.all;
            all.MaxDamageTank = await _tankRepository.GetTankById(all.max_damage_tank_id);
            all.MaxKillsTank = await _tankRepository.GetTankById(all.max_frags_tank_id);
            all.MaxXpTank = await _tankRepository.GetTankById(all.max_xp_tank_id);

            return serializedStats;
        }

        public async Task<List<UserTanks>> GetUserTanks(string AccountId)
        {
            List<UserTanks> tanks = await _tankRepository.GetUserTanks(AccountId);

            //go through each tank returned and get the tank details - name and image
            await GetTankDetails(tanks);

            return tanks;
        }

        public async Task<UserMedalsViewModel> GetUserMedals(string AccountId)
        {
            UserMedals medals = await _medalRepository.GetUserMedals(AccountId);
            UserMedalsViewModel formattedMedals = await FormatMedals(medals);

            return formattedMedals;
        }

        /// <summary>
        /// Filter the useful medals into a list.
        /// Useful medals we want to find: topgun, defender,scout,radley walters,high caliber, kamikaze, bia
        /// </summary>
        public async Task<UserMedalsViewModel> FormatMedals(UserMedals Medals)
        {

            int brothersInArms = Medals.achievements.medalBrothersInArms;
            int defender = Medals.achievements.defender;
            int scout = Medals.achievements.scout;
            int radWalters = Medals.achievements.medalRadleyWalters;
            int highCalibre = Medals.achievements.mainGun;
            int topgun = Medals.achievements.warrior;
            int confederate = Medals.achievements.supporter;
            int kolobanovs = Medals.achievements.medalKolobanov;
            int fighter = Medals.achievements.fighter;
            int duelist = Medals.achievements.duelist;


            Medals allMedals = await _medalRepository.GetAllMedals();
            UserMedalsViewModel vm = new UserMedalsViewModel();

            //TODO: Refactor below section as it is massive!
            /* 
             * 
             * */


            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = brothersInArms,
                MedalCondition = FormatMedalCondition(allMedals.MedalBrothersInArms.condition),
                MedalDescription = allMedals.MedalBrothersInArms.description,
                MedalImage = allMedals.MedalBrothersInArms.image,
                MedalName = FormatMedalName(allMedals.MedalBrothersInArms.name)
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = defender,
                MedalCondition = FormatMedalCondition(allMedals.Defender.condition),
                MedalDescription = allMedals.Defender.description,
                MedalImage = allMedals.Defender.image,
                MedalName = FormatMedalName(allMedals.Defender.name)
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = scout,
                MedalCondition = FormatMedalCondition(allMedals.Scout.condition),
                MedalDescription = allMedals.Scout.description,
                MedalImage = allMedals.Scout.image,
                MedalName = FormatMedalName(allMedals.Scout.name)
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = radWalters,
                MedalCondition = FormatMedalCondition(allMedals.MedalRadleyWalters.condition),
                MedalDescription = allMedals.MedalRadleyWalters.description,
                MedalImage = allMedals.MedalRadleyWalters.image,
                MedalName = FormatMedalName(allMedals.MedalRadleyWalters.name)
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = highCalibre,
                MedalCondition = FormatMedalCondition(allMedals.HighCalibre.condition),
                MedalDescription = allMedals.HighCalibre.description,
                MedalImage = allMedals.HighCalibre.image,
                MedalName = "High calibre"
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = topgun,
                MedalCondition = FormatMedalCondition(allMedals.TopGun.condition),
                MedalDescription = allMedals.TopGun.description,
                MedalImage = allMedals.TopGun.image,
                MedalName = "Top gun"
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = confederate,
                MedalCondition = FormatMedalCondition(allMedals.Confederate.condition),
                MedalDescription = allMedals.Confederate.description,
                MedalImage = allMedals.Confederate.image,
                MedalName = "Confederate"
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = kolobanovs,
                MedalCondition = FormatMedalCondition(allMedals.Kolobanovs.condition),
                MedalDescription = allMedals.Kolobanovs.description,
                MedalImage = allMedals.Kolobanovs.image,
                MedalName = FormatMedalName(allMedals.Kolobanovs.name)
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = fighter,
                MedalCondition = FormatMedalCondition(allMedals.Fighter.condition),
                MedalDescription = allMedals.Fighter.description,
                MedalImage = allMedals.Fighter.image,
                MedalName = FormatMedalName(allMedals.Fighter.name)
            });
            vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = duelist,
                MedalCondition = FormatMedalCondition(allMedals.Duelist.condition),
                MedalDescription = allMedals.Duelist.description,
                MedalImage = allMedals.Duelist.image,
                MedalName = FormatMedalName(allMedals.Duelist.name)
            });

            return vm;

        }

        public async Task<List<UserTanks>> GetTankDetails(List<UserTanks> UserTanks)
        {
            foreach (UserTanks tank in UserTanks)
            {
                TankDetails tankDetails = await _tankRepository.GetTankById(tank.tank_id);
                MasteryBadgeLevels tankMastery = (MasteryBadgeLevels)tank.mark_of_mastery;
                tank.MasteryBadgeText = FormatMedalName(tankMastery.ToString());
                tank.tank_details = tankDetails;
            }

            return UserTanks;
        }

        public string FormatMedalName(string MedalName)
        {
            string formattedName = MedalName;

            formattedName = formattedName.FirstCharToUpper();
            formattedName = formattedName.Replace("Medal", "");


            //before each capital letter, add a space
            string capitalizedCorrectly = Regex.Replace(formattedName, "([a-z])([A-Z])", "$1 $2");

            return capitalizedCorrectly;
        }

        public string FormatMedalCondition(string Condition)
        {
            Condition = Condition.Replace("•", "<li>");
            Condition = Condition.Replace(".", "</li>");

            return Condition;
        }




    }
}