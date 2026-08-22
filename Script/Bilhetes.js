    const treinos = document.getElementById("treinos");
    const qualificacao = document.getElementById("qualificacao");
    const corrida = document.getElementById("corrida");
    const fimDeSemana = document.getElementById("fim-de-semana");

    const treinosContent = document.getElementById("treinos-content");
    const qualificacaoContent = document.getElementById("qualificacao-content");
    const corridaContent = document.getElementById("corrida-content");
    const fimDeSemanaContent = document.getElementById("fim-de-semana-content");



    // Ocultar a div "treinos-content"
    treinosContent.style.display = "none";
    qualificacaoContent.style.display = "none";
    corridaContent.style.display = "none";
    fimDeSemanaContent.style.display = "none";
    
    treinos.addEventListener("click", function () {
        toggleContent(treinosContent);
    });

    qualificacao.addEventListener("click", function () {
        toggleContent(qualificacaoContent);
    });

    corrida.addEventListener("click", function () {
        toggleContent(corridaContent);
    });

    fimDeSemana.addEventListener("click", function () {
        toggleContent(fimDeSemanaContent);
    });

function toggleContent(content) {
        const allContents = document.querySelectorAll(".content");
        if (content.style.display == "block") {
            content.style.display = "none";
            showOtherContents();
        } else {
            allContents.forEach((c) => {
                if (c.id !== content.id) {
                    c.style.display = "none";
                }
            });

            content.style.display = "block";
        }
}
