var imagens = document.querySelectorAll("#divLugares img");
var botaoEsquerdo = document.getElementById("btnLeft");
var botaoDireito = document.getElementById("btnRight");
//Pilotos
var PrimeiroLBL = document.getElementById("PrimeiroLBL");
var SegundoLBL = document.getElementById("SegundoLBL");
var TerceiroLBL = document.getElementById("TerceiroLBL");
var QuartoLBL = document.getElementById("QuartoLBL");
var QuintoLBL = document.getElementById("QuintoLBL");
var SextoLBL = document.getElementById("SextoLBL");
var SetimoLBL = document.getElementById("SetimoLBL");
var OitavoLBL = document.getElementById("OitavoLBL");
var NonoLBL = document.getElementById("NonoLBL");
var DecimoLBL = document.getElementById("DecimoLBL");
var DecimoPrimeiroLBL = document.getElementById("DecimoPrimeiroLBL");
var DecimoSegundoLBL = document.getElementById("DecimoSegundoLBL");
var DecimoTerceiroLBL = document.getElementById("DecimoTerceiroLBL");
var DecimoQuartoLBL = document.getElementById("DecimoQuartoLBL");
var DecimoQuintoLBL = document.getElementById("DecimoQuintoLBL");
var DecimoSextoLBL = document.getElementById("DecimoSextoLBL");
var DecimoSetimoLBL = document.getElementById("DecimoSetimoLBL");
var DecimoOitavoLBL = document.getElementById("DecimoOitavoLBL");
var DecimoNonoLBL = document.getElementById("DecimoNonoLBL");
var UltimoLBL = document.getElementById("UltimoLBL");
//Lugares
var PrimeiroLugar = document.getElementById("PrimeiroLugar");
var SegundoLugar = document.getElementById("SegundoLugar");
var TerceiroLugar = document.getElementById("TerceiroLugar");
var QuartoLugar = document.getElementById("QuartoLugar");
var QuintoLugar = document.getElementById("QuintoLugar");
var SextoLugar = document.getElementById("SextoLugar");
var SetimoLugar = document.getElementById("SetimoLugar");
var OitavoLugar = document.getElementById("OitavoLugar");
var NonoLugar = document.getElementById("NonoLugar");
var DecimoLugar = document.getElementById("DecimoLugar");
var DecimoPrimeiroLugar = document.getElementById("DecimoPrimeiroLugar");
var DecimoSegundoLugar = document.getElementById("DecimoSegundoLugar");
var DecimoTerceiroLugar = document.getElementById("DecimoTerceiroLugar");
var DecimoQuartoLugar = document.getElementById("DecimoQuartoLugar");
var DecimoQuintoLugar = document.getElementById("DecimoQuintoLugar");
var DecimoSextoLugar = document.getElementById("DecimoSextoLugar");
var DecimoSetimoLugar = document.getElementById("DecimoSetimoLugar");
var DecimoOitavoLugar = document.getElementById("DecimoOitavoLugar");
var DecimoNonoLugar = document.getElementById("DecimoNonoLugar");
var UltimoLugar = document.getElementById("UltimoLugar");
//Tempos
var TempoPrimeiro = document.getElementById("TempoPrimeiro");
var TempoSegundo = document.getElementById("TempoSegundo");
var TempoTerceiro = document.getElementById("TempoTerceiro");
var TempoQuarto = document.getElementById("TempoQuarto");
var TempoQuinto = document.getElementById("TempoQuinto");
var TempoSexto = document.getElementById("TempoSexto");
var TempoSetimo = document.getElementById("TempoSetimo");
var TempoOitavo = document.getElementById("TempoOitavo");
var TempoNono = document.getElementById("TempoNono");
var TempoDecimo = document.getElementById("TempoDecimo");
var TempoDecimoPrimeiro = document.getElementById("TempoDecimoPrimeiro");
var TempoDecimoSegundo = document.getElementById("TempoDecimoSegundo");
var TempoDecimoTerceiro = document.getElementById("TempoDecimoTerceiro");
var TempoDecimoQuarto = document.getElementById("TempoDecimoQuarto");
var TempoDecimoQuinto = document.getElementById("TempoDecimoQuinto");
var TempoDecimoSexto = document.getElementById("TempoDecimoSexto");
var TempoDecimoSetimo = document.getElementById("TempoDecimoSetimo");
var TempoDecimoOitavo = document.getElementById("TempoDecimoOitavo");
var TempoDecimoNono = document.getElementById("TempoDecimoNono");
var TempoUltimo = document.getElementById("TempoUltimo");

var imagensOriginais = ["ImagensResultados/VerstappenPreSet.png",
    "ImagensResultados/PerezPreSet.png",
    "ImagensResultados/AlonsoPreSet.png",
    "ImagensResultados/RussellPreSet.png",
    "ImagensResultados/SainzPreSet.png",
    "ImagensResultados/HamiltonPreSet.png",
    "ImagensResultados/LeclercPreSet.png",
    "ImagensResultados/GaslyPreSet.png",
    "ImagensResultados/OconPreSet.png",
    "ImagensResultados/MagnussenPreSet.png",
];

var novasImagens = [
    "ImagensResultados/TsunodaPreSet.png",
    "ImagensResultados/StrollPreSet.png",
    "ImagensResultados/BottasPreSet.png",
    "ImagensResultados/AlbonPreSet.png",
    "ImagensResultados/HulkenbergPreSet.png",
    "ImagensResultados/ZhouPreSet.png",
    "ImagensResultados/NorrisPreSet.png",
    "ImagensResultados/DeVriesPreSet.png",
    "ImagensResultados/PiastriPreSet.png",
    "ImagensResultados/SargeantPreSet.png",
];

function alterarImagens() {
    for (var i = 0; i < imagens.length; i++) {
        // Altera as imagens
        imagens[i].src = novasImagens[i];
    }
}

// Função para mostrar todas as imagens novamente
function mostrarTodasImagens() {
    for (var i = 0; i < imagens.length; i++) {
        imagens[i].src = imagensOriginais[i];
    }
}

// Adiciona o evento de click ao botão direito
botaoDireito.addEventListener("click", alterarImagens);

// Adiciona o evento de click ao botão esquerdo
botaoEsquerdo.addEventListener("click", mostrarTodasImagens);



// Adiciona o evento de click ao botão esquerdo

botaoEsquerdo.addEventListener("click", exibirPrimeiroLBL);
botaoEsquerdo.addEventListener("click", exibirSegundoLBL);
botaoEsquerdo.addEventListener("click", exibirTerceiroLBL);
botaoEsquerdo.addEventListener("click", exibirQuartoLBL);
botaoEsquerdo.addEventListener("click", exibirQuintoLBL);
botaoEsquerdo.addEventListener("click", exibirSextoLBL);
botaoEsquerdo.addEventListener("click", exibirSetimoLBL);
botaoEsquerdo.addEventListener("click", exibirOitavoLBL);
botaoEsquerdo.addEventListener("click", exibirNonoLBL);
botaoEsquerdo.addEventListener("click", exibirDecimoLBL);

botaoEsquerdo.addEventListener("click", exibirPrimeiroLugar);
botaoEsquerdo.addEventListener("click", exibirSegundoLugar);
botaoEsquerdo.addEventListener("click", exibirTerceiroLugar);
botaoEsquerdo.addEventListener("click", exibirQuartoLugar);
botaoEsquerdo.addEventListener("click", exibirQuintoLugar);
botaoEsquerdo.addEventListener("click", exibirSextoLugar);
botaoEsquerdo.addEventListener("click", exibirSetimoLugar);
botaoEsquerdo.addEventListener("click", exibirOitavoLugar);
botaoEsquerdo.addEventListener("click", exibirNonoLugar);
botaoEsquerdo.addEventListener("click", exibirDecimoLugar);

botaoEsquerdo.addEventListener("click", exibirTempoPrimeiro);
botaoEsquerdo.addEventListener("click", exibirTempoSegundo);
botaoEsquerdo.addEventListener("click", exibirTempoTerceiro);
botaoEsquerdo.addEventListener("click", exibirTempoQuarto);
botaoEsquerdo.addEventListener("click", exibirTempoQuinto);
botaoEsquerdo.addEventListener("click", exibirTempoSexto);
botaoEsquerdo.addEventListener("click", exibirTempoSetimo);
botaoEsquerdo.addEventListener("click", exibirTempoOitavo);
botaoEsquerdo.addEventListener("click", exibirTempoNono);
botaoEsquerdo.addEventListener("click", exibirTempoDecimo);
// Adiciona o evento de click ao botão direito

botaoDireito.addEventListener("click", exibirDecimoPrimeiroLBL);
botaoDireito.addEventListener("click", exibirDecimoSegundoLBL);
botaoDireito.addEventListener("click", exibirDecimoTerceiroLBL);
botaoDireito.addEventListener("click", exibirDecimoQuartoLBL);
botaoDireito.addEventListener("click", exibirDecimoQuintoLBL);
botaoDireito.addEventListener("click", exibirDecimoSextoLBL);
botaoDireito.addEventListener("click", exibirDecimoSetimoLBL);
botaoDireito.addEventListener("click", exibirDecimoOitavoLBL);
botaoDireito.addEventListener("click", exibirDecimoNonoLBL);
botaoDireito.addEventListener("click", exibirUltimoLBL);

botaoDireito.addEventListener("click", exibirDecimoPrimeiroLugar);
botaoDireito.addEventListener("click", exibirDecimoSegundoLugar);
botaoDireito.addEventListener("click", exibirDecimoTerceiroLugar);
botaoDireito.addEventListener("click", exibirDecimoQuartoLugar);
botaoDireito.addEventListener("click", exibirDecimoQuintoLugar);
botaoDireito.addEventListener("click", exibirDecimoSextoLugar);
botaoDireito.addEventListener("click", exibirDecimoSetimoLugar);
botaoDireito.addEventListener("click", exibirDecimoOitavoLugar);
botaoDireito.addEventListener("click", exibirDecimoNonoLugar);
botaoDireito.addEventListener("click", exibirUltimoLugar);

botaoDireito.addEventListener("click", exibirTempoDecimoPrimeiro);
botaoDireito.addEventListener("click", exibirTempoDecimoSegundo);
botaoDireito.addEventListener("click", exibirTempoDecimoTerceiro);
botaoDireito.addEventListener("click", exibirTempoDecimoQuarto);
botaoDireito.addEventListener("click", exibirTempoDecimoQuinto);
botaoDireito.addEventListener("click", exibirTempoDecimoSexto);
botaoDireito.addEventListener("click", exibirTempoDecimoSetimo);
botaoDireito.addEventListener("click", exibirTempoDecimoOitavo);
botaoDireito.addEventListener("click", exibirTempoDecimoNono);
botaoDireito.addEventListener("click", exibirTempoUltimo);
// Pilotos
function exibirPrimeiroLBL() {
    PrimeiroLBL.style.display = "block";
    DecimoPrimeiroLBL.style.display = "none";
}

function exibirSegundoLBL() {
    SegundoLBL.style.display = "block";
    DecimoSegundoLBL.style.display = "none";
}

function exibirTerceiroLBL() {
    TerceiroLBL.style.display = "block";
    DecimoTerceiroLBL.style.display = "none";
}

function exibirQuartoLBL() {
    QuartoLBL.style.display = "block";
    DecimoQuartoLBL.style.display = "none";
}

function exibirQuintoLBL() {
    QuintoLBL.style.display = "block";
    DecimoQuintoLBL.style.display = "none";
}

function exibirSextoLBL() {
    SextoLBL.style.display = "block";
    DecimoSextoLBL.style.display = "none";
}

function exibirSetimoLBL() {
    SetimoLBL.style.display = "block";
    DecimoSetimoLBL.style.display = "none";
}

function exibirOitavoLBL() {
    OitavoLBL.style.display = "block";
    DecimoOitavoLBL.style.display = "none";
}

function exibirNonoLBL() {
    NonoLBL.style.display = "block";
    DecimoNonoLBL.style.display = "none";
}

function exibirDecimoLBL() {
    DecimoLBL.style.display = "block";
    UltimoLBL.style.display = "none";
}

function exibirDecimoPrimeiroLBL() {
    PrimeiroLBL.style.display = "none";
    DecimoPrimeiroLBL.style.display = "block";
}

function exibirDecimoSegundoLBL() {
    SegundoLBL.style.display = "none";
    DecimoSegundoLBL.style.display = "block";
}

function exibirDecimoTerceiroLBL() {
    TerceiroLBL.style.display = "none";
    DecimoTerceiroLBL.style.display = "block";
}

function exibirDecimoQuartoLBL() {
    QuartoLBL.style.display = "none";
    DecimoQuartoLBL.style.display = "block";
}

function exibirDecimoQuintoLBL() {
    QuintoLBL.style.display = "none";
    DecimoQuintoLBL.style.display = "block";
}

function exibirDecimoSextoLBL() {
    SextoLBL.style.display = "none";
    DecimoSextoLBL.style.display = "block";
}

function exibirDecimoSetimoLBL() {
    SetimoLBL.style.display = "none";
    DecimoSetimoLBL.style.display = "block";
}

function exibirDecimoOitavoLBL() {
    OitavoLBL.style.display = "none";
    DecimoOitavoLBL.style.display = "block";
}

function exibirDecimoNonoLBL() {
    NonoLBL.style.display = "none";
    DecimoNonoLBL.style.display = "block";
}

function exibirUltimoLBL() {
    DecimoLBL.style.display = "none";
    UltimoLBL.style.display = "block";
}
//Lugares
function exibirPrimeiroLugar() {
    DecimoPrimeiroLugar.style.display = "none";
    PrimeiroLugar.style.display = "block";
}

function exibirSegundoLugar() {
    DecimoSegundoLugar.style.display = "none";
    SegundoLugar.style.display = "block";
}

function exibirTerceiroLugar() {
    DecimoTerceiroLugar.style.display = "none";
    TerceiroLugar.style.display = "block";
}

function exibirQuartoLugar() {
    DecimoQuartoLugar.style.display = "none";
    QuartoLugar.style.display = "block";
}

function exibirQuintoLugar() {
    DecimoQuintoLugar.style.display = "none";
    QuintoLugar.style.display = "block";
}

function exibirSextoLugar() {
    DecimoSextoLugar.style.display = "none";
    SextoLugar.style.display = "block";
}

function exibirSetimoLugar() {
    DecimoSetimoLugar.style.display = "none";
    SetimoLugar.style.display = "block";
}

function exibirOitavoLugar() {
    DecimoOitavoLugar.style.display = "none";
    OitavoLugar.style.display = "block";
}

function exibirNonoLugar() {
    DecimoNonoLugar.style.display = "none";
    NonoLugar.style.display = "block";
}

function exibirDecimoLugar() {
    UltimoLugar.style.display = "none";
    DecimoLugar.style.display = "block";
}

function exibirDecimoPrimeiroLugar() {
    PrimeiroLugar.style.display = "none";
    DecimoPrimeiroLugar.style.display = "block";
}

function exibirDecimoSegundoLugar() {
    SegundoLugar.style.display = "none";
    DecimoSegundoLugar.style.display = "block";
}

function exibirDecimoTerceiroLugar() {
    TerceiroLugar.style.display = "none";
    DecimoTerceiroLugar.style.display = "block";
}

function exibirDecimoQuartoLugar() {
    QuartoLugar.style.display = "none";
    DecimoQuartoLugar.style.display = "block";
}

function exibirDecimoQuintoLugar() {
    QuintoLugar.style.display = "none";
    DecimoQuintoLugar.style.display = "block";
}

function exibirDecimoSextoLugar() {
    SextoLugar.style.display = "none";
    DecimoSextoLugar.style.display = "block";
}

function exibirDecimoSetimoLugar() {
    SetimoLugar.style.display = "none";
    DecimoSetimoLugar.style.display = "block";
}

function exibirDecimoOitavoLugar() {
    OitavoLugar.style.display = "none";
    DecimoOitavoLugar.style.display = "block";
}

function exibirDecimoNonoLugar() {
    NonoLugar.style.display = "none";
    DecimoNonoLugar.style.display = "block";
}

function exibirUltimoLugar() {
    DecimoLugar.style.display = "none";
    UltimoLugar.style.display = "block";
}
//Tempos
function exibirTempoPrimeiro() {
    TempoDecimoPrimeiro.style.display = "none";
    TempoPrimeiro.style.display = "block";
}

function exibirTempoSegundo() {
    TempoDecimoSegundo.style.display = "none";
    TempoSegundo.style.display = "block";
}

function exibirTempoTerceiro() {
    TempoDecimoTerceiro.style.display = "none";
    TempoTerceiro.style.display = "block";
}

function exibirTempoQuarto() {
    TempoDecimoQuarto.style.display = "none";
    TempoQuarto.style.display = "block";
}

function exibirTempoQuinto() {
    TempoDecimoQuinto.style.display = "none";
    TempoQuinto.style.display = "block";
}

function exibirTempoSexto() {
    TempoDecimoSexto.style.display = "none";
    TempoSexto.style.display = "block";
}

function exibirTempoSetimo() {
    TempoDecimoSetimo.style.display = "none";
    TempoSetimo.style.display = "block";
}

function exibirTempoOitavo() {
    TempoDecimoOitavo.style.display = "none";
    TempoOitavo.style.display = "block";
}

function exibirTempoNono() {
    TempoDecimoNono.style.display = "none";
    TempoNono.style.display = "block";
}

function exibirTempoDecimo() {
    TempoUltimo.style.display = "none";
    TempoDecimo.style.display = "block";
}

function exibirTempoDecimoPrimeiro() {
    TempoPrimeiro.style.display = "none";
    TempoDecimoPrimeiro.style.display = "block";
}

function exibirTempoDecimoSegundo() {
    TempoSegundo.style.display = "none";
    TempoDecimoSegundo.style.display = "block";
}

function exibirTempoDecimoTerceiro() {
    TempoTerceiro.style.display = "none";
    TempoDecimoTerceiro.style.display = "block";
}

function exibirTempoDecimoQuarto() {
    TempoQuarto.style.display = "none";
    TempoDecimoQuarto.style.display = "block";
}

function exibirTempoDecimoQuinto() {
    TempoQuinto.style.display = "none";
    TempoDecimoQuinto.style.display = "block";
}

function exibirTempoDecimoSexto() {
    TempoSexto.style.display = "none";
    TempoDecimoSexto.style.display = "block";
}

function exibirTempoDecimoSetimo() {
    TempoSetimo.style.display = "none";
    TempoDecimoSetimo.style.display = "block";
}

function exibirTempoDecimoOitavo() {
    TempoOitavo.style.display = "none";
    TempoDecimoOitavo.style.display = "block";
}

function exibirTempoDecimoNono() {
    TempoNono.style.display = "none";
    TempoDecimoNono.style.display = "block";
}

function exibirTempoUltimo() {
    TempoDecimo.style.display = "none";
    TempoUltimo.style.display = "block";
}