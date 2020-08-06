using System;
using System.ComponentModel.Design;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TankStats.Data.Repositories;
using TankStats.Extensions;
using TankStats.Models;
using TankStats.Models.ViewModels;

namespace TankStats.Services
{
    public class MedalService
    {
        private readonly MedalRepository _medalRepository;

        public MedalService(MedalRepository medalRepository)
        {
            _medalRepository = medalRepository;
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
        public async Task<UserMedalsViewModel> FormatMedals(UserMedals UserMedals)
        {
            Medals allMedals = await _medalRepository.GetAllMedals();
            UserMedalsViewModel vm = new UserMedalsViewModel();

            //go through each property and figure out which medal it is, based on its name
            foreach (PropertyInfo prop in UserMedals.achievements.GetType().GetProperties())
            {
                int amountRecieved;
                MedalInformation medalInfo;
                string propertyName = prop.Name.ToLower();

                /*Here we have match the number of medals achieved up with the medal information. Have to do to this with a switch at the moment but ideally would like to change this to be different.
                The reason we have to do it in a switch is because some of the medal names are called something different in the api*/
                switch (propertyName)
                {
                    case "medalbrothersinarms":
                        amountRecieved = UserMedals.achievements.medalBrothersInArms;
                        medalInfo = FormatMedal(allMedals.MedalBrothersInArms);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "defender":
                        amountRecieved = UserMedals.achievements.defender;
                        medalInfo = FormatMedal(allMedals.Defender);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "scout":
                        amountRecieved = UserMedals.achievements.scout;
                        medalInfo = FormatMedal(allMedals.Scout);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "medalradleywalters":
                        amountRecieved = UserMedals.achievements.medalRadleyWalters;
                        medalInfo = FormatMedal(allMedals.MedalRadleyWalters);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "maingun": //this medal is called high calibre in the game
                        amountRecieved = UserMedals.achievements.mainGun;
                        medalInfo = FormatMedal(allMedals.HighCalibre);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "warrior": //this medal is called topgun in the game
                        amountRecieved = UserMedals.achievements.warrior;
                        medalInfo = FormatMedal(allMedals.TopGun);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "supporter": //this medal is called confederate in the game
                        amountRecieved = UserMedals.achievements.supporter;
                        medalInfo = FormatMedal(allMedals.Confederate);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "medalkolobanov":
                        amountRecieved = UserMedals.achievements.medalKolobanov;
                        medalInfo = FormatMedal(allMedals.Kolobanovs);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "fighter":
                        amountRecieved = UserMedals.achievements.fighter;
                        medalInfo = FormatMedal(allMedals.Fighter);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    case "duelist":
                        amountRecieved = UserMedals.achievements.duelist;
                        medalInfo = FormatMedal(allMedals.Duelist);
                        AddMedalToViewModel(vm, amountRecieved, medalInfo);
                        break;
                    default:
                        //it hasn't found any of the medals
                        break;
                }
            }

            return vm;
        }


        public void AddMedalToViewModel(UserMedalsViewModel Vm, int AmountRecieved, MedalInformation MedalInfo)
        {
            Vm.MedalsReceived.Add(new UserMedalsReceived()
            {
                AmountReceived = AmountRecieved,
                MedalInformation = MedalInfo
            });
        }

        public MedalInformation FormatMedal(MedalInformation MedalInfo)
        {
            string formattedName = MedalInfo.name;

            formattedName = formattedName.FirstCharToUpper();
            formattedName = formattedName.Replace("Medal", "");
            formattedName = formattedName.AddSpace();

            string condition = FormatMedalCondition(MedalInfo.condition);
            MedalInfo.condition = condition;
            MedalInfo.name = formattedName;

            return MedalInfo;
        }

        public string FormatMedalCondition(string Condition)
        {
            Condition = Condition.Replace("•", "<li>");
            Condition = Condition.Replace(".", "</li>");

            return Condition;
        }
    }
}
