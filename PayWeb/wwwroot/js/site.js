(function () {
    'use strict';

    // Fetch all the forms we want to apply custom Bootstrap validation styles to
    var forms = document.querySelectorAll('.needs-validation');

    // Loop over them and prevent submission
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault();
                    event.stopPropagation();
                }

                form.classList.add('was-validated');
            }, false);
        });

    // Auto-focus on the next field when the current field is valid and Enter is pressed
    var inputs = document.querySelectorAll('input, select, textarea');
    inputs.forEach(function (input, index) {
        input.addEventListener('keydown', function (event) {
            if (event.key === 'Enter' && input.checkValidity()) {
                event.preventDefault();
                var nextInput = inputs[index + 1];
                if (nextInput) {
                    nextInput.focus();
                }
            }
        });
    });

    // Global error handler
    window.addEventListener('error', function (event) {
        console.error('Error occurred: ', event.error);
        // Send the error to the server
        fetch('/log', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({ message: event.error.message, stack: event.error.stack })
        });
    });
})();

// Function to add highlight class on focus
function AddHighlight(event) {
    event.target.classList.add('input-highlight');
}

// Function to remove highlight class on blur
function RemoveHighlight(event) {
    event.target.classList.remove('input-highlight');
}