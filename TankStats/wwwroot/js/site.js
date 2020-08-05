/**
 * Search for the player using the wot api, and then return their stats. We'll then use some new bootstrap 4 components 
 * to display the data in a cool way
 * */
function SearchPlayer() {
    //get what the user typed in 
    var username = $("#Username").val();

    GetUsersStats(username);
    //display a message if we can't find the users stats, otherwise display the stats

}

function GetUsersStats(Username) {
    Username = Username.toLowerCase();
    var accountId;
    $.ajax({
        url: "/Home/GetUser?Username=" + Username,
        method: "GET",
        success: function (response) {
            if (response.data !== null) {
                accountId = response.account_id;

                //now we need to get some stats from them
                GetPersonalData(accountId);
            }
        },
        error: function (err) {
            console.log(err);
            //TODO: Handle errors nicely
        }
    });
}

//TODO: add async functions to make this code ALOT cleaner
function GetPersonalData(AccountId) {
    $.ajax({
        url: "/Home/GetUserStats?AccountId=" + AccountId,
        method: "GET",
        success: function (response) {
            // console.log(response);

            var usefulData = response.userStats.statistics.all;
            usefulData.trees_cut = response.userStats.statistics.trees_cut;
            usefulData.global_rating = response.userStats.global_rating;

            RenderUserStats(usefulData);
            RenderUserMedals(response.userMedals);
            RenderUserTanks(response.userTanks);
        },
        error: function (err) {
            console.log(err);
        }
    });
}

//TODO:Try and sprinkle some react or Angular in to make all these render sections of code much cleaner

function RenderUserStats(UserData) {
    //console.log("Stats", UserData);
    var htmlString = "";
    //headline stats
    htmlString += "<div class='row'>";
    htmlString += "<div class='col-xs-4'>";
    htmlString += "<h2>Headline stats</h2>";
    htmlString += "<table class='table table-striped table-hover'>";
    htmlString += "<tr><td><i class='fa fa-star-half-alt'></i> Overall rating</td><td>" + UserData.global_rating + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-gamepad'></i> Battles<td>" + UserData.battles + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-arrows-alt-v'></i> Wins/Losses</td><td>" + UserData.wins + "/" + UserData.losses + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-user-plus'></i> Survived battles</td><td>" + UserData.survived_battles + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-star'></i> Average xp per game</td><td>" + UserData.battle_avg_xp + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-binoculars'></i> Average assisted per game</td><td>" + UserData.avg_damage_assisted + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-stop'></i> Average damage blocked per game</td><td>" + UserData.avg_damage_blocked + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-percentage'></i> Hit percent</td><td>" + UserData.hits_percents + "%</td></tr>";
    htmlString += "</table></div>";

    //best stats
    htmlString += "<div class='col-xs-4'>";
    htmlString += "<h2>Best stats</h2>"
    htmlString += "<table class='table table-striped table-hover'>";
    htmlString += "<tr><td> Highest Damage dealt</td><td>" + UserData.max_damage + "hp <img src='" + UserData.maxDamageTank.images.small_icon + "'></img>" + UserData.maxDamageTank.name + "</td></tr>";
    htmlString += "<tr><td> Max kills</td><td>" + UserData.max_frags + " <img src='" + UserData.maxKillsTank.images.small_icon + "'></img>" + UserData.maxKillsTank.name + "</td></tr>";
    htmlString += "<tr><td> Highest xp game</td><td>" + UserData.max_xp + "xp <img src='" + UserData.maxXpTank.images.small_icon + "'></img>" + UserData.maxXpTank.name + "</td></tr>";
    htmlString += "</table></div>";

    //random stats
    htmlString += "<div class='col-xs-4'>";
    htmlString += "<h2>Random stats</h2>";
    htmlString += "<table class='table table-striped table-hover'>";
    htmlString += "<tr><td><i class='fa fa-skull-crossbones'></i> Total kills</td><td>" + UserData.frags + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-skull'></i> Total damage dealt</td><td>" + UserData.damage_dealt + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-times'></i> Total damage recieved</td><td>" + UserData.damage_received + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-binoculars'></i> Total tanks spotted</td><td>" + UserData.spotted + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-fire'></i> Total shots fired</td><td>" + UserData.shots + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-tree'></i> Trees pushed over</td><td>" + UserData.trees_cut + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-bomb'></i> HE hits recieved</td><td>" + UserData.explosion_hits_received + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-star'></i> Total xp earned</td><td>" + UserData.xp + "</td></tr>";
    htmlString += "</div>";

    $("#UserStats").html(htmlString);
}

function RenderUserTanks(UserTanks) {
    //console.log("Tanks", UserTanks);
    var htmlString = "";
    htmlString += "<table class='table table-striped table-hover'>";
    htmlString += "<tr><th>Tank</th><th>Description</th><th>Mastery Badge</th><th>Battles</th><th>Wins</th></tr>";

    for (var i = 0; i < UserTanks.length; i++) {
        htmlString += "<tr>";
        htmlString += "<td><img src='" + UserTanks[i].tank_details.images.small_icon + "'></img>" + UserTanks[i].tank_details.name + "</td>";
        htmlString += "<td>" + UserTanks[i].tank_details.description + "</td>";
        htmlString += "<td>" + UserTanks[i].masteryBadgeText + "</td>";
        htmlString += "<td>" + UserTanks[i].statistics.battles + "</td>";
        htmlString += "<td>" + UserTanks[i].statistics.wins + "</td>";
        htmlString += "</tr>";
    }

    htmlString += "</table>";

    $("#UserTanks").html(htmlString);
}

function RenderUserMedals(UserMedals) {
    var htmlString = "";
    htmlString += "<table class='table table-striped table-responsive table-hover'>";
    htmlString += "<tr><th></th><th>Medal</th><th>Description</th></tr>";

    for (var i = 0; i < UserMedals.medalsReceived.length; i++) {
        var currentIteration = UserMedals.medalsReceived[i];
        htmlString += "<tr>";
        htmlString += "<td><img src='" + currentIteration.medalImage + "'></img> <div id='medalsAchieved'><span class='badge badge-info text-center'>" + currentIteration.amountReceived + "</span></div></td>";
        htmlString += "<td>" + currentIteration.medalName + "</td>";
        htmlString += "<td>" + currentIteration.medalDescription + "<ul>" + currentIteration.medalCondition + "</ul> </td>";
        htmlString += "</tr>";
    }
    htmlString += "</table>";

    $("#UserMedals").html(htmlString);
}