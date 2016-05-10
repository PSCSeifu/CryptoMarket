//ClientController.js

(function () {

    "use strict";

    angular.module("app-clients")
    .controller("ClientController", ClientController)

    function ClientController($http) {
        var vm = this;

        vm.clients = [];
        
        //vm.newClient = {};

        vm.errorMessage = "";
        vm.isBusy = true;

        $http.get("/api/clients")
            .then(function (response) {
                //Success            
                angular.copy(response.data, vm.clients);
            }, function (error) {
                //Failure
                vm.errorMessage = "failed to get data " + error;
            })
            .finally(function () {
                vm.isBusy = false;
            });

        vm.addTrip = function () {
            vm.isBusy = true;
            //ensure errror message is cleared 
            vn.errorMessage = "";

            $http.post("/api/clients", vm.newClient)
            .then(function (response) {

                vm.clients.push(response.data);
                //Clear out object once data is posted
                vm.newClient = {};
            }, function () {
                vm.errorMessage = "Failed to save new Client";
            })
            .finally(function () {
                vm.isBusy = false;
            })
        }

    }
   
})();