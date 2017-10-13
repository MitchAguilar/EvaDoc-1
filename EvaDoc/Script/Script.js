function ConsultarEvaluacion(id,est,eval) {
    axios.get("../Vista/DetalleEvaluar.aspx?id=" + id+"&Estado="+est+"&Evaluar="+eval).then((resul) => {
        document.getElementById("criterios").innerHTML = resul.data;
    }).catch(error=> {
    });
}

function GuardarCalificacion(id) {
    var guardar = true;
    for (var i = 0; i < document.getElementsByName("crit").length; i++) {
        if (document.getElementsByName("crit")[i].value == "-1") {
            guardar = false;
        }
    }
    
    if (guardar) {
        for (var i = 0; i < document.getElementsByName("crit").length; i++) {
            axios.get("../Vista/Calificar.aspx?id=" + id + "&idcrit=" + document.getElementsByName("idcrit")[i].textContent + "&valor=" + document.getElementsByName("crit")[i].value + "&just=" + document.getElementsByName("just")[i].value).then((resul) => {
            }).catch(error=> {
            });
        }
        alert("Se Guardo exitosamente, se redireccionara");
        window.location = "DocumentoCalificar.aspx";
    } else {
        alert("Te falto un item para calificar");
    }
   
}