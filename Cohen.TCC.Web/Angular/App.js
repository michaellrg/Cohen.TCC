var app = angular.module("veiculoApp", []);

app.controller("veiculoCtrl", function ($scope, $http) {
    $http.get('/Veiculos/GetTodosVeiculos/')
    .success(function (resul) {
        $scope.veiculos = resul;
    })
    .error(function (data) {
        console.log(data);
    });
    $scope.veiculo = $scope.veiculos;
      $scope.SelecionaVeiculo = function (veiculo) {
        $scope.veiculo = veiculo;
    }





    $http.get('/Veiculos/GetTiposVeiculos/')
       .success(function (resul) {
           $scope.tipos = resul;
       })
       .error(function (data) {
           console.log(data);
       })

    $scope.tipo = $scope.tipos;
    $scope.TodosTipos = function (tipo) {
        $scope.tipo = tipo;
    }






      $scope.IncluiVeiculo = function (tipo) {
          
          $http.post('/Veiculos/AdicionaVeiculo/', { tipo })
        .success(function (result) {
            $scope.veiculos = result;
            delete $scope.tipo;
            $scope.TodosVeiculos();
        })
        .error(function (data) {
            console.log(data)
        });
    }

    $scope.AlteraVeiculo = function (veiculo) {
        $http.post('/Veiculos/AtualizaVeiculo/', { veiculo })
        .success(function (result) {
            $scope.veiculos = result;
            $scope.TodosVeiculos();
        })
        .error(function (data) {
            console.log(data)
        });
    }

    $scope.DeletaVeiculo = function (veiculo) {
        $http.post('/Veiculos/DeletaVeiculo/', { veiculo })
        .success(function (result) {
            $scope.veiculos = result;
            $scope.TodosVeiculos();
        })
        .error(function (data) {
            console.log(data)
        });
    }


        $scope.TodosVeiculos = function () {
            $http.get('/Veiculos/GetTodosVeiculos/')
           .success(function (resul) {
               $scope.veiculos = resul;
           })
           .error(function (data) {
               console.log(data);
           });
        }


        $scope.TodosTipos = function () {
            $http.get('/Veiculos/GetTiposVeiculos/')
           .success(function (resul) {
               $scope.tipos = resul;
           })
           .error(function (data) {
               console.log(data);
           });
        }
});

