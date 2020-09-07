/*handles the form submit for the search box*/
function searchPlayer() {
    var username = $("#Username").val();
    var server = $("#Server").val();
    clearData();
    showOverlay();
    getUsersStats(username, server);
}

/**Searches for the player that the user has entered into the form */
function getUsersStats(Username, Server) {
    Username = Username.toLowerCase();
    $.ajax({
        url: "/Home/GetUser?Username=" + Username + "&Server=" + Server,
        method: "GET",
        success: function (response) {
            if (response !== null && response !== void (response)) {
                getPersonalData(response.account_id); //now we need to get some stats from them
            }
            else {
                showErrorMessage("An error occured whilst trying to find this user. Please make sure you typed a valid username in from the " + Server + " server");
            }
        },
        error: function (err) {
            showErrorMessage("An error occured whilst trying to find this user. Please make sure you typed a valid username in from the " + Server + " server", err);
        }
    });
}

/**
 * Does the api call to get the user stats and then calls the render methods
 */
function getPersonalData(AccountId) {
    var server = $("#Server").val();
    $.ajax({
        url: "/Home/GetUserStats?AccountId=" + AccountId,
        method: "GET",
        success: function (response) {
            if (response !== null && response !== void (response)) {
                console.log(response);
                var usefulData = response.userStats.statistics.all;
                usefulData.trees_cut = response.userStats.statistics.trees_cut;
                usefulData.global_rating = response.userStats.global_rating;

                hideOverlay();
                renderUserStats(usefulData);
                renderUserMedals(response.userMedals);
                renderUserTanks(response.userTanks);
            }
            else {
                showErrorMessage("An error occured getting this users statistics. Please make sure you entered a valid username for a player on the "+ server  +" server");
            }
        },
        error: function (err) {
            showErrorMessage("An error occured getting this users statistics. Please make sure you entered a valid username for a player on the " + server +" server", err);
        }
    });
}

/**
 * Builds the HTML for the top 3 columns of the webpage
 */
function renderUserStats(UserData) {
    // console.log("Stats", UserData);
    var htmlString = "";
    //headline stats
    htmlString += " <div class='row padTop10 ellipsis'>";
    htmlString += "<div class='col-xs-4 padColumnSmall'>";
    htmlString += "<h2>Headline stats</h2>";
    htmlString += "<table class='table table-striped table-hover'>";
    htmlString += "<tr><td><i class='fa fa-star-half-alt'></i> Overall rating</td><td>" + UserData.global_rating + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-gamepad'></i> Battles<td>" + UserData.battles + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-arrows-alt-v'></i> Win percentage</td><td>" + UserData.win_percent + "%</td></tr>";
    htmlString += "<tr><td><i class='fa fa-user-plus'></i> Survived battles</td><td>" + UserData.survived_battles + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-star'></i> Average xp per game</td><td>" + UserData.battle_avg_xp + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-binoculars'></i> Average assisted per game</td><td>" + UserData.avg_damage_assisted + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-stop'></i> Average damage blocked per game</td><td>" + UserData.avg_damage_blocked + "</td></tr>";
    htmlString += "<tr><td><i class='fa fa-percentage'></i> Hit percent</td><td>" + UserData.hits_percents + "%</td></tr>";
    htmlString += "</table></div>";

    //best stats
    htmlString += "<div class='col-xs-4 padColumnSmall'>";
    htmlString += "<h2>Best stats</h2>"
    htmlString += "<table class='table table-striped table-hover'>";
    htmlString += "<tr><td> Highest Damage dealt</td><td>" + UserData.max_damage + "hp <img title='" + UserData.maxDamageTank.name + "' class='tankStatImg' src='" + UserData.maxDamageTank.images.small_icon + "'></img></td></tr>";
    htmlString += "<tr><td> Max kills</td><td>" + UserData.max_frags + " kills <img title='" + UserData.maxKillsTank.name + "' class='tankStatImg' src='" + UserData.maxKillsTank.images.small_icon + "'></img></td></tr>";
    htmlString += "<tr><td> Highest xp game</td><td>" + UserData.max_xp + "xp <img title='" + UserData.maxXpTank.name + "' class='tankStatImg' src='" + UserData.maxXpTank.images.small_icon + "'></img></td></tr>";
    htmlString += "</table></div>";

    //random stats
    htmlString += "<div class='col-xs-4 padColumnSmall'>";
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

/**
 * Builds the HTML for the 'your top 10 most popular tanks' section of the webpage
 */
function renderUserTanks(UserTanks) {
    //console.log("Tanks", UserTanks);
    var htmlString = "";
    htmlString += "<h3 class='padTop10'>Your top 10 most popular tanks</h3>";
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

/**
 * Builds the HTML for the medals section of the webpage
 */
function renderUserMedals(UserMedals) {
    //console.log(UserMedals);
    var htmlString = "";
    htmlString += "<h3 class='padTop10'>Epic Medals</h3>";
    htmlString += "<table class='table table-striped table-responsive table-hover'>";
    htmlString += "<tr><th></th><th>Medal</th><th>Description</th></tr>";

    for (var i = 0; i < UserMedals.medalsReceived.length; i++) {
        var currentIteration = UserMedals.medalsReceived[i];
        htmlString += "<tr>";
        htmlString += "<td><img src='" + currentIteration.medalInformation.image + "'></img> <div id='MedalsAchieved'><span class='badge badge-info text-center'>" + currentIteration.amountReceived + "</span></div></td>";
        htmlString += "<td>" + currentIteration.medalInformation.name + "</td>";
        htmlString += "<td>" + currentIteration.medalInformation.description + "<ul>" + currentIteration.medalInformation.condition + "</ul> </td>";
        htmlString += "</tr>";
    }
    htmlString += "</table>";

    $("#UserMedals").html(htmlString);
}


function showOverlay() {
    $("#Overlay").show();
}

function hideOverlay() {
    $("#Overlay").hide();
}

function showErrorMessage(ErrorMessage, err) {
    console.log("Error ", err);
    $("#ApiErrors").append(ErrorMessage).show();
    hideOverlay();
}

function clearData() {
    $("#UserStats, #UserTanks, #UserMedals, #ApiErrors").empty();
}