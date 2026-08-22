function redirectToPage(url) {
    window.location.href = url;
}

function btnRightClick(event) {
    var preSetImages = document.getElementsByClassName('PreSet');
    for (var i = 0; i < preSetImages.length; i++) {
        preSetImages[i].style.display = 'none';
    }

    var preSetEscondidoImages = document.getElementsByClassName('PreSetEscondido');
    for (var j = 0; j < preSetEscondidoImages.length; j++) {
        preSetEscondidoImages[j].style.display = 'block';
    }

    var lblPrimeiroLabels = document.getElementsByClassName('lblPrimeiroNome');
    for (var m = 0; m < lblPrimeiroLabels.length; m++) {
        lblPrimeiroLabels[m].style.display = 'none';
    }

    var lblUltimoLabels = document.getElementsByClassName('lblDecimoPrimeiroNome');
    for (var n = 0; n < lblUltimoLabels.length; n++) {
        lblUltimoLabels[n].style.display = 'block';
    }

    var tempoPrimeiroLabels = document.getElementsByClassName('lblPrimeiroTempo');
    for (var k = 0; k < tempoPrimeiroLabels.length; k++) {
        tempoPrimeiroLabels[k].style.display = 'none';
    }

    var tempoUltimoLabels = document.getElementsByClassName('lblDecimoPrimeiroTempo');
    for (var l = 0; l < tempoUltimoLabels.length; l++) {
        tempoUltimoLabels[l].style.display = 'block';
    }

    var lugaresPrimeiroLabels = document.getElementsByClassName('lblPrimeiro');
    for (var k = 0; k < lugaresPrimeiroLabels.length; k++) {
        lugaresPrimeiroLabels[k].style.display = 'none';
    }

    var lugaresUltimoLabels = document.getElementsByClassName('lblDecimoPrimeiro');
    for (var l = 0; l < lugaresUltimoLabels.length; l++) {
        lugaresUltimoLabels[l].style.display = 'block';
    }
    event.preventDefault();
}

function btnLeftClick(event) {
    var preSetImages = document.getElementsByClassName('PreSet');
    for (var i = 0; i < preSetImages.length; i++) {
        preSetImages[i].style.display = 'block';
    }

    var preSetEscondidoImages = document.getElementsByClassName('PreSetEscondido');
    for (var j = 0; j < preSetEscondidoImages.length; j++) {
        preSetEscondidoImages[j].style.display = 'none';
    }

    var lblPrimeiroLabels = document.getElementsByClassName('lblPrimeiroNome');
    for (var m = 0; m < lblPrimeiroLabels.length; m++) {
        lblPrimeiroLabels[m].style.display = 'block';
    }

    var lblUltimoLabels = document.getElementsByClassName('lblDecimoPrimeiroNome');
    for (var n = 0; n < lblUltimoLabels.length; n++) {
        lblUltimoLabels[n].style.display = 'none';
    }

    var tempoPrimeiroLabels = document.getElementsByClassName('lblPrimeiroTempo');
    for (var k = 0; k < tempoPrimeiroLabels.length; k++) {
        tempoPrimeiroLabels[k].style.display = 'block';
    }

    var tempoUltimoLabels = document.getElementsByClassName('lblDecimoPrimeiroTempo');
    for (var l = 0; l < tempoUltimoLabels.length; l++) {
        tempoUltimoLabels[l].style.display = 'none';
    }

    var lugaresPrimeiroLabels = document.getElementsByClassName('lblPrimeiro');
    for (var k = 0; k < lugaresPrimeiroLabels.length; k++) {
        lugaresPrimeiroLabels[k].style.display = 'block';
    }

    var lugaresUltimoLabels = document.getElementsByClassName('lblDecimoPrimeiro');
    for (var l = 0; l < lugaresUltimoLabels.length; l++) {
        lugaresUltimoLabels[l].style.display = 'none';
    }
    event.preventDefault();
}