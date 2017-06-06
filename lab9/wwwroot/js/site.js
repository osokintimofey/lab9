'use strict';
class User {
    constructor(id, firstname, lastname, city, date, age) {
        this.id = id;
        this.firstname = firstname;
        this.lastname = lastname;
        this.city = city;
        this.date = date;
        this.age = age;
    }
}

class ViewModel {
    constructor() {
        this.localusers = ko.observableArray();
    }
};

var viewmodel = new ViewModel();

viewmodel.refresh = function () {
    $.ajax({
        url: 'api/get',
        type: 'GET',
        contentType: "application/json",
        success: function (users) {
            viewmodel.localusers.removeAll();
            $.each(users, function (index, user) {
                viewmodel.localusers.push(new User(user['id'], user['firstname'],
                    user['lastname'], user['city'], user['date'], user['age']));
            });
        }
    });
}

viewmodel.add = function () {
    var userFirstname = $('#firstname').val();
    var userLastname = $('#lastname').val();
    var userCity = $('#city').val();
    var userDate = $('#date').val();
    var userAge = $('#age').val();

    $.ajax({
        url: "Home/Post/user",
        contentType: "application/json",
        method: "POST",
        data: JSON.stringify({
            firstname: userFirstname,
            lastname: userLastname,
            city: userCity,
            date: userDate,
            age: userAge
        }),
        success: function (user) {
            viewmodel.refresh();
        }
    })
}

ko.applyBindings(viewmodel);
viewmodel.refresh();