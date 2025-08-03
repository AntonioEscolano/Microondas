// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//const { event } = require("jquery");

// Write your JavaScript code.

$("#iniciar").on("click", function () {
    var _mensagens = "";
    var _status = $("#status").val().trim();
    var _potencia = $("#potencia").val().trim();
    const _tempo = document.getElementById('tempo');
    const _tempoFormato = document.getElementById('tempoFormato');

    console.log(`Tempo: ${_tempo.value}, Potência: ${_potencia}, Status: ${_status}`);

    _status = (_tempo.value > 0 && _tempo.value <=120) && (_potencia > 0 && _potencia <= 12) ? true : false;

    $.ajax({
        type: "POST",
        url: "Home/RecebeDados",
        data: {
            "_dados.tempo": _tempo.value,
            "_dados.potencia": _potencia,
            "_dados.status": _status
        },
        success: function (response) {

            //Retorno dos dados
            console.log(`Tempo: ${response.tempoDefinido}, Potência: ${response.potencia}, Status: ${response.status}`);

            _tempo.style.display = "none";
            _tempoFormato.style.display = "inline-block";

            _tempo.value = response.tempo;
            _tempoFormato.value = response.tempoDefinido;

            $("#status").val(response.status);

            if (response.status == true) {
                _mensagens = "Funcionando, aguarde!";
            } else {
                if (response.mensagemTempo != null) {
                    _mensagens = " *" + response.mensagemTempo + "\n";
                    mudarCampoTempo();
                }
                _mensagens += (response.mensagemPotencia != null) ? " *" + response.mensagemPotencia : " ";
            }

            $("#potencia").val(response.potencia);
            $("#mensagens").text(_mensagens); // Atualiza o campo de mensagem com a resposta do servidor
        },
        error: function (xhr, status, error) {
            console.error(error);
        }
    });
});

//Ação de click no campo Tempo
$("#tempoFormato").on("click", function () {
    mudarCampoTempo();
});

//Limpar campos INPUT
$("#pausarCancelar").on("click", function () {
    var _status = $("#status").val();

    if (_status != "true") {
        $("#status").val("");
        $("#tempo").val(0);
        $("#tempoFormato").val("00:00");
        $("#potencia").val(0);
        $("#mensagens").text("");
    } else {
        $("#status").val("false");
        $("#mensagens").text("Aquicimento pausado!");
    }
});

//Transição de campo INPUT para entrada de dados
function mudarCampoTempo() {
    const _tempo = document.getElementById('tempo');
    const _tempoFormato = document.getElementById('tempoFormato');
    _tempo.style.display = "inline-block";
    _tempoFormato.style.display = "none";

    setTimeout(() => {
        $("#tempo").trigger('click');
    }, 1500);
}

window.onload = function () {
    const _tempoFormato = document.getElementById('tempoFormato');
    _tempoFormato.style.display = "none !important" ;
};