myConcert.controller("myConcertController", function($scope,  $http, myConcertModel){
	$scope.notas = myConcertModel.getNotas();
})