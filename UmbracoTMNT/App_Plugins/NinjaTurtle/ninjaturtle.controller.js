/// <reference path="https://ajax.googleapis.com/ajax/libs/angularjs/1.2.3/angular.min.js" />
angular.module("umbraco").controller("Nojaf.NinjaTurtleEditor", ninjaCtrl);

function ninjaCtrl($scope, dialogService, imageHelper) {
    $scope.colors = ["#55497B", "#246E91", "#7B2228", "#DF572D"];
    $scope.weapons = ["katana's", "bo-staf", "sais", "nunchaku's"];

    if ($scope.model.value === undefined || $scope.model.value === "") {
        $scope.model.value = {
            Name: "",
            Color: "",
            Weapon: "",
            Info: "",
            SmallImage: "",
            BackgroundImage: ""
        };
    }

    $scope.openMediaPickerSmallImage = function () {
        dialogService.mediaPicker({ callback: doneSmallImage });
    };

    $scope.openMediaPickerBg = function () {
        dialogService.mediaPicker({ callback: doneBg });
    }


    function doneSmallImage(data) {
        console.log(data);
        $scope.model.value.SmallImage = data.properties[0].value;
    }

    function doneBg(data)
    {
        $scope.model.value.BackgroundImage = data.properties[0].value;
    }

}