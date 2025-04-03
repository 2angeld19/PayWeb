window.modalHelper = {
    showModal: function (modalId) {
        var modalElement = document.getElementById(modalId);
        if (modalElement) {
            var modal = new bootstrap.Modal(modalElement);
            modal.show();
        } else {
            console.error('Elemento modal no encontrado');
        }
    }
};