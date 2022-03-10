function getPeople() {
    $.get("/Ajax/GetPeople", null, function (data) {
        $("#PersonList").html(data);
    });
}

function getPersonById() {
    var PersonId = document.getElementById("PersonIdInput").value;
    $.post("/Ajax/FindPersonById", { personId: PersonId }, function (data) {
        $("#PersonList").html(data);
    });
}

function deletePersonById() {
    var PersonId = document.getElementById("PersonIdInput").value;
    $.post("/Ajax/DeletePersonById", { personId: PersonId }, function (data) {

    })
        .done(function () {
            document.getElementById("errorMsg").innerHTML = "Successfully deleted Person";
        })
        .failk(function () {
            document.getElementById("errorMsg").innerHTML = "Could not delete Person";
        });
}