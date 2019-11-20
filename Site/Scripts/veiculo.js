$(document).ready(function () {
        
    $("#anoFabricacao").change(function () {
        $('#loadingAno').show();//testar depois
        $("#anoModelo").empty();
        
        if ($("#anoFabricacao").val() != 0) {
            $.ajax({
                type: 'POST',
                url: "/Admin/Veiculos/ListAnoMax",
                dataType: 'json',
                data: { anoMin: $("#anoFabricacao").val() },
                success: function (anoMinMax) {
    
    
                    $.each(anoMinMax, function (i, ano) {
                        $("#anoModelo").append('<option value="' + ano.AnoLista + '">' + ano.AnoLista + '</option>');
                        
                    });

                    $('#loadingAno').hide(); 
                },
                error: function (ex) {
                    alert('Ocorreu em nossa busca de ano modelo verifique sua conexão de internet.' + ex);
                }
            });
        }
        return false;
    }),
    
    
    $("#tipo").change(function () {
        $('#loadingMarca').show();
        $("#marca").empty();

        $("#anoInicio").append('<option value="">' + " - TODOS - " + '</option>');
        $("#anoFim").append('<option value="">' + " - TODOS - " + '</option>');

        if ($("#tipo").val() != 0) {
            $.ajax({
                type: 'POST',
                url: "/Admin/Veiculos/ListMarca",
                dataType: 'json',
                data: { tipo: $("#tipo").val() },

                success: function (marcas) {

                    $.each(marcas, function (i, marca) {

                        $("#marca").append('<option value="' + marca.IdMarca + '">' + marca.Nome + '</option>');
                    });
                    $('#loadingMarca').hide(); 
                },
                error: function (ex) {
                    alert('Ocorreu em nossa busca de marcas verifique sua conexão de internet.' + ex);
                }
            });

        }
        return false;
    })

    
});

$(document).ready(function () {

    var idVeiculo = $("#IdVeiculo").val();
    var pagina = $("#hddPagina").val();
    //var idVeiculo = 83;
    console.log(idVeiculo);

    if (idVeiculo !== "0") {
        $('#upload').show();
        $("#fileuploader").uploadFile({

            url: "/admin/Veiculos/Upload?id=" + idVeiculo,
            fileName: "myfile",
            showPreview: false,
            previewHeight: "100px",
            previewWidth: "100px",
            acceptFiles: "image/*",
            autoSubmit: true,
            sequential: true,
            sequentialCount: 1,

            maxFileCountErrorStr: "Não foi gravado. O máximo de Arquivos por vez é:",
            //maxFileSize: 1048576,
            maxFileSize: 2097152,//2mb
            sizeErrorStr: "Esta imagem ultrapassou o limite de: ",
            maxFileCount: 15,

            afterUploadAll: function (obj) {
                //if ($("#hddAcao").val() === 'editar') {
                //    var paginaRetorno = $("#hddPagina").val();
                location.reload();
                $(location).attr('href', '/admin/veiculos/editar/' + idVeiculo + "?p=" + pagina)
                //$(location).attr('href', '/painel/veiculos?pagina=' + paginaRetorno)

                //} else {
                //    location.reload();
                //    //$(location).attr('href', '/painel/veiculos')
                //    $(location).attr('href', '/veiculos')
                //}
            }
        });

    } else {
        $('#upload').hide();
    }

});