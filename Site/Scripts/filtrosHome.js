//function OpenLoading() {
//    loading = document.getElementById("loading");
//    loading.style.display = "block";
//}

//function CloseLoading() {
//    setTimeout(function () {
//        loading = document.getElementById("loading");
//        loading.style.display = "none";
//    }, 600);

//}

$(document).ready(function () {

    $("#tipo").change(function () {
        $('#loadingWeb').show();//testar depois
        $("#marca").empty();
        $("#anoInicio").empty();
        $("#anoFim").empty();

        $("#marca").append('<option value="">' + " - TODOS - " + '</option>');
        $("#anoInicio").append('<option value="0">' + " - TODOS - " + '</option>');
        $("#anoFim").append('<option value="">' + " - TODOS - " + '</option>');

        if ($("#tipo").val() != 0) {
            $.ajax({
                type: 'POST',
                dataType: 'json',
                url: "/Veiculos/ListMarca",
                data: { tipo: $("#tipo").val() },

                success: function (marcas) {

                    $.each(marcas, function (i, marca) {

                        $("#marca").append('<option value="' + marca.Nome + '">' + marca.Nome + ' (' + marca.QtdVeiculo + ')' + '</option>');
                    });
                    $('#loadingWeb').hide(); //testar depois
                },
                error: function (ex) {

                    alert('Ocorreu em nossa busca.' + ex);
                }
            });
        }
        return false;
    })
});

$(document).ready(function () {

    $("#marca").change(function () {
        $('#loadingWeb').show();
        $("#anoInicio").empty();
        $("#anoFim").empty();
        $("#anoInicio").append('<option value="0">' + " - TODOS - " + '</option>');
        $("#anoFim").append('<option value="">' + " - TODOS - " + '</option>');

        if ($("#marca").val() != 0) {
            $.ajax({

                type: 'POST',
                dataType: 'json',
                url: "/Veiculos/ListAnoFiltro",
                data: { marca: $("#marca").val() },

                success: function (anoMinMax) {

                    $.each(anoMinMax, function (i, ano) {
                        $("#anoInicio").append('<option value="' + ano.AnoLista + '">' + ano.AnoLista + '</option>');
                        //$("#anoFim").append('<option value="' + ano.AnoLista + '">' + ano.AnoLista + '</option>');
                        //$("#anoInicio").append('<option value="' + city.Value + '">' + city.Text + '</option>');
                        $('#loadingWeb').hide();
                    });
                },
                error: function (ex) {
                    alert('Ocorreu em nossa busca filtro marca.' + ex);
                }
            });
        }
        return false;
    })
});


$(document).ready(function () {

    $("#anoInicio").change(function () {
        $('#loadingWeb').show();
        $("#anoFim").empty();
        $("#anoFim").append('<option value="">' + " - TODOS - " + '</option>');
        if ($("#anoInicio").val() != 0) {
            $.ajax({
                type: 'POST',
                url: "/Veiculos/ListAnoMax",
                dataType: 'json',
                data: { anoMin: $("#anoInicio").val(), marca: $("#marca").val() },
                success: function (anoMinMax) {

                    $.each(anoMinMax, function (i, ano) {
                        $("#anoFim").append('<option value="' + ano.AnoLista + '">' + ano.AnoLista + '</option>');
                        $('#loadingWeb').hide();
                    });
                },
                error: function (ex) {
                    alert('Ocorreu em nossa busca.' + ex);
                }
            });
        }
        return false;
    })
});





$(document).ready(
      function () {
          var urlDestino = '/veiculos';


          $("#tipo").change(
          function () {
              console.log('/veiculos?tipo=' + $("#tipo").val().toLowerCase()),
              urlDestino = '/veiculos?tipo=' + $("#tipo").val().toLowerCase()
          });
          $("#marca").change(function () {
              console.log('/veiculos?tipo=' + $("#tipo").val().toLowerCase() + '&marca=' + $("#marca").val().toLowerCase()),
              urlDestino = '/veiculos?tipo=' + $("#tipo").val().toLowerCase() + '&marca=' + $("#marca").val().toLowerCase()
          });
          $("#anoInicio").change(function () {
              console.log('/veiculos?tipo=' + $("#tipo").val().toLowerCase() + '&marca=' + $("#marca").val().toLowerCase() + '&anoInicio=' + $("#anoInicio").val()),
              urlDestino = '/veiculos?tipo=' + $("#tipo").val().toLowerCase() + '&marca=' + $("#marca").val().toLowerCase() + '&anoInicio=' + $("#anoInicio").val()
          }),
          $("#anoFim").change(function () {
              console.log('/veiculos?tipo=' + $("#tipo").val().toLowerCase() + '&marca=' + $("#marca").val().toLowerCase() + '&anoInicio=' + $("#anoInicio").val() + '&anoFim=' + $("#anoFim").val()),
              urlDestino = '/veiculos?tipo=' + $("#tipo").val().toLowerCase() + '&marca=' + $("#marca").val().toLowerCase() + '&anoInicio=' + $("#anoInicio").val() + '&anoFim=' + $("#anoFim").val()
          })

          $("#btnBuscar").click(
         function () {

             console.log(urlDestino)
             window.location.href = urlDestino            
         });
      });


// script para excludao onde e preciso enviar o nome do contreller o id do item e o nome que sera exibido no modal
$(document).ready(
      function () {
          var id = 0;
          var controller;
          $(".lkbExcluir").click(
               function () {
                   id = $(this).attr("data-id");
                   var nome = $(this).attr("data-nome");
                   controller = $(this).attr("data-controller");
                   //console.log(id);
                   //console.log(controller);
                   $("#nomeItem").html(nome);
               });
          $("#btnConfirmar").click(
              //OpenLoading()
          function () {
              //console.log(id);
              $.ajax(
                  {
                      dataType: "json",
                      contentType: 'application/json',
                      type: "GET",
                      url: "/Admin/" + controller + "/Excluir",
                      data: { 'id': id },

                      success: function (dados) {
                          //CloseLoading();
                          location.reload();
                      },
                      error: function (dados) {
                          //alert(dados);
                          //CloseLoading();
                          location.reload();
                      }
                  });
          })
      });
