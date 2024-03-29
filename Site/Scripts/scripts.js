$(document).ready(function () {

    $(".img-responsive").fadeOut(1000, function () {
        //$(this).attr('src', "");
        //BuscarCaptcha();
    });

});
$(window).load(function () {
    $(".img-responsive").fadeIn(1000);
});


function getParameterByName(name, url) {
    if (!url) url = window.location.href;
    name = name.replace(/[\[\]]/g, "\\$&");
    var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
        results = regex.exec(url);
    if (!results) return null;
    if (!results[2]) return '';
    return decodeURIComponent(results[2].replace(/\+/g, " "));
}

$(function () {
    var sortOrder = getParameterByName('so');
    var currentSort = getParameterByName('cs');


    //console.log(sortOrder);
    switch (sortOrder) {

        case 'modelo':
            if (sortOrder == currentSort) {
                document.getElementById('orderModelo').innerHTML = '<i class="fa fa-sort-desc"></i>';
            } else {
                document.getElementById('orderModelo').innerHTML = '<i class="fa fa-sort-asc"></i>';
            }
            break;
        case 'ano':
            if (sortOrder == currentSort) {
                document.getElementById('orderAno').innerHTML = '<i class="fa fa-sort-desc"></i>';
            } else {
                document.getElementById('orderAno').innerHTML = '<i class="fa fa-sort-asc"></i>';
            }
            break;
        case 'marca':
            if (sortOrder == currentSort) {
                document.getElementById('orderMarca').innerHTML = '<i class="fa fa-sort-desc"></i>';
            } else {
                document.getElementById('orderMarca').innerHTML = '<i class="fa fa-sort-asc"></i>';
            }
            break;
        case 'tipo':
            if (sortOrder == currentSort) {
                document.getElementById('orderTipo').innerHTML = '<i class="fa fa-sort-desc"></i>';
            } else {
                document.getElementById('orderTipo').innerHTML = '<i class="fa fa-sort-asc"></i>';
            }
            break;
        case 'nome':
            if (sortOrder == currentSort) {
                document.getElementById('orderNome').innerHTML = '<i class="fa fa-sort-desc"></i>';
            } else {
                document.getElementById('orderNome').innerHTML = '<i class="fa fa-sort-asc"></i>';
            }
            break;
        case 'email':
            if (sortOrder == currentSort) {
                document.getElementById('orderEmail').innerHTML = '<i class="fa fa-sort-desc"></i>';
            } else {
                document.getElementById('orderEmail').innerHTML = '<i class="fa fa-sort-asc"></i>';
            }
            break;

        default:
            break;

    }

});



// para que o menu lateral do adm recolha e mostre corretamente 
$(function () {
    $('.navbar-toggle-sidebar').click(function () {
        $('.navbar-nav').toggleClass('slide-in');
        $('.side-body').toggleClass('body-slide-in');
        $('#search').removeClass('in').addClass('collapse').slideUp(200);
    });

    $('#search-trigger').click(function () {
        $('.navbar-nav').removeClass('slide-in');
        $('.side-body').removeClass('body-slide-in');
        $('.search-input').focus();
    });
});


// para mudara a classe active item de posisao de acordo com a navegacao
//usado na parte adm no menu lateral
$(function () {
    var path = window.location.pathname;
    if (path != "/") {
        $(".navbar-nav li").removeClass("active");
        $(".navbar-nav li").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active");
            }
        });
    }
});
$(function () {
    var path = window.location.pathname;
    //console.log('passei')
    if (path != "/") {
        $(".top-menu .nav .navbar-nav li a").removeClass("active scroll");
        $(".top-menu .nav .navbar-nav li a").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active scroll");
            }
        });
    } else {
        $(".top-menu .nav .navbar-nav li a").each(function () {
            var href = $(this).children().first().attr("href");
            if (path == href) {
                $(this).addClass("active scroll");
            }
        });
    }
});





$('#CEP').change(function (e) {    
    e.preventDefault();
    $("#Logradouro").val('');
    $("#Bairro").val('');
    $("#Cidade").val('');
    //$("Estado").val('');

    var cep = $('#CEP').val().replace("-", "");
    $.getJSON("http://cep.republicavirtual.com.br/web_cep.php?cep=" + cep + "  &formato=json", {}, function (data) {
        if (data.resultado_txt == 'sucesso - cep completo') {
            $("#Logradouro").val(data.tipo_logradouro + ' ' + data.logradouro);
            $("#Bairro").val(data.bairro);
            $("#Cidade").val(data.cidade);
            $("#estado").val(data.uf);
        }
    });
});

//script para mover para o topo
$(document).ready(function () {
    $().UItoTop({ easingType: 'easeOutQuart' });
});





// daqui para baixo sao coisas do template



//para mostrar e recolher o menu quando estiver em layouts pequenos
$("span.menu").click(function () {
    $(".top-menu").slideToggle("slow", function () {
        // Animation complete.
    });
});

//todo esse jQuery � por causa do template
jQuery(document).ready(function ($) {

    $('.services_nav_list li').click(function () {

        var selected = $(this).data('service');

        if (!$('.view[data-service="' + selected + '"]').hasClass("active")) {

            $('.services_nav_list').find('li.active').removeClass("active");
            $('.view.active').removeClass("active");
            $('.services_nav_list li[data-service="' + selected + '"]').addClass("active");
            $('.view[data-service="' + selected + '"]').addClass("active");

        } else {

            return false;

        }

        $('.service_wrapper').css("height", height);

    });

    $('.next').click(function (e) {
        e.preventDefault();

        var active = $('.service_wrapper').find('.view.active');
        var selected = active.data("service");

        if (selected >= 5) {
            return false;
        } else {
            active.removeClass("active");
            $('.view[data-service="' + (selected + 1) + '"]').addClass("active");
        }

        var height = $('.view.active').height();

        $('.service_wrapper').css("height", height);

    });

    $('.previous').click(function (e) {
        e.preventDefault();

        var active = $('.service_wrapper').find('.view.active');
        var selected = active.data("service");

        if (selected <= 1) {
            return false;
        } else {
            active.removeClass("active");
            $('.view[data-service="' + (selected - 1) + '"]').addClass("active");
        }

        var height = $('.view.active').height();

        $('.service_wrapper').css("height", height);

    });

    $('.selectors_wrapper li').click(function () {

        var selected = $(this).data('selector');

        if (!$('.standard[data-selector="' + selected + '"]').hasClass("active")) {

            $('.selectors_wrapper').find('li.active').removeClass("active");
            $('.standard.active').removeClass("active");
            $('.selectors_wrapper li[data-selector="' + selected + '"]').addClass("active");
            $('.standard[data-selector="' + selected + '"]').addClass("active");

            var height2 = $('.standard.active').height();
            $('.standard_content').css("height", height2);

        } else {

            return false;

        }

    });


    $(function () {

        var height = $('.view.active').height();
        height2 = $('.standard.active').height();

        $('.service_wrapper').css("height", height);
        $('.standard_content').css("height", height2);

    });

    $(window).resize(function () {

        var height = $('.view.active').height();
        height2 = $('.standard.active').height();

        $('.service_wrapper').css("height", height);
        $('.standard_content').css("height", height2);

    });

    // Check if browser supports HTML5 input placeholder
    function supports_input_placeholder() {
        var i = document.createElement('input');
        return 'placeholder' in i;

        var x = document.createElement('textarea');
        return 'placeholder' in x;
    }

    // Change input text on focus
    if (!supports_input_placeholder()) {
        jQuery('.wpcf7-text').each(function () {
            var self = jQuery(this);
            var value = jQuery.trim(self.val());
            if (value == '') self.val(self.attr('placeholder'));
        });
        jQuery('.wpcf7-text').focus(function () {
            var self = jQuery(this);
            if (self.val() == self.attr('placeholder')) self.val('');
        }).blur(function () {
            var self = jQuery(this);
            var value = jQuery.trim(self.val());
            if (value == '') self.val(self.attr('placeholder'));
        });

        jQuery('.wpcf7-textarea').each(function () {
            var self = jQuery(this);
            var value = jQuery.trim(self.val());
            if (value == '') self.val(self.attr('placeholder'));
        });
        jQuery('.wpcf7-textarea').focus(function () {
            var self = jQuery(this);
            if (self.val() == self.attr('placeholder')) self.val('');
        }).blur(function () {
            var self = jQuery(this);
            var value = jQuery.trim(self.val());
            if (value == '') self.val(self.attr('placeholder'));
        });


    }

});
