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

    var pontosPrimeiroLabels = document.getElementsByClassName('PontosPrimeiro');
    for (var k = 0; k < pontosPrimeiroLabels.length; k++) {
        pontosPrimeiroLabels[k].style.display = 'none';
    }

    var pontosUltimoLabels = document.getElementsByClassName('PontosUltimo');
    for (var l = 0; l < pontosUltimoLabels.length; l++) {
        pontosUltimoLabels[l].style.display = 'block';
    }

    var lblPrimeiroLabels = document.getElementsByClassName('lblPrimeiro');
    for (var m = 0; m < lblPrimeiroLabels.length; m++) {
        lblPrimeiroLabels[m].style.display = 'none';
    }

    var lblUltimoLabels = document.getElementsByClassName('lblUltimo');
    for (var n = 0; n < lblUltimoLabels.length; n++) {
        lblUltimoLabels[n].style.display = 'block';
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

    var pontosPrimeiroLabels = document.getElementsByClassName('PontosPrimeiro');
    for (var k = 0; k < pontosPrimeiroLabels.length; k++) {
        pontosPrimeiroLabels[k].style.display = 'block';
    }

    var pontosUltimoLabels = document.getElementsByClassName('PontosUltimo');
    for (var l = 0; l < pontosUltimoLabels.length; l++) {
        pontosUltimoLabels[l].style.display = 'none';
    }

    var lblPrimeiroLabels = document.getElementsByClassName('lblPrimeiro');
    for (var m = 0; m < lblPrimeiroLabels.length; m++) {
        lblPrimeiroLabels[m].style.display = 'block';
    }

    var lblUltimoLabels = document.getElementsByClassName('lblUltimo');
    for (var n = 0; n < lblUltimoLabels.length; n++) {
        lblUltimoLabels[n].style.display = 'none';
    }
    event.preventDefault();
}