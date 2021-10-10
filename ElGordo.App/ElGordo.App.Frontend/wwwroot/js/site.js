
// Validad que haya un numero en los campos numericos
function validaNumero(event) {
    return (event.charCode >= 48 && event.charCode <= 57) ? true : false;
}

//Funcion JQuery que oculta el boton carrito de compras y muestra la lista de compras
function OcultarLista(){
    $("#ticket").hide("500");
    $("#cart").show("500");
}

//Funcion JQuery que oculta la lista de compras y muetra el boton carrito de compras
function MostrarLista(){
    $("#ticket").show("500");
    $("#cart").hide("500");
}

//Lista que almacena los items seleccionados

//Función que agrega el punto decimal a los numeros
function moneda(val) {
    while (/(\d+)(\d{3})/.test(val.toString())) {
        val = val.toString().replace(/(\d+)(\d{3})/, '$1' + '.' + '$2');
    }
    return val;
}

// eliminar activities.pop();

//Activar los tooltip de bootstrap para mostrar globos on hover
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
  })

