$(document).ready(function () {
    $('.slider').slick({
        dots: false,
        infinite: true,
        speed: 300,
        slidesToShow: 3,
        slidesToScroll: 1
    });
});

// Seleccionar el interruptor y agregar un evento de cambio
const switchBtn = document.querySelector('.switch__input');
switchBtn.addEventListener('change', function () {
    // Guardar el estado del interruptor en localStorage
    localStorage.setItem('switch', this.checked);
});

// Obtener el estado del interruptor guardado en localStorage
const modoNoche = localStorage.getItem('switch');

// Si el modo noche está habilitado, establecer el interruptor en el estado correcto
if (modoNoche === 'true') {
    switchBtn.checked = true;
}